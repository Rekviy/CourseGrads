using CourseGrads.Data;
using CourseGrads.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CourseGrads.Data {
	public static class ChangeTrackerHelper {
		

		public static dynamic CreateTracker(Type modelType) {
			var getTable = typeof(UniversityDBHelper)
				 .GetMethods(BindingFlags.Public | BindingFlags.Static)
				 .First(m =>
				 	m.Name == nameof(UniversityDBHelper.GetTable) &&
				 	m.IsGenericMethodDefinition &&
				 	m.GetGenericArguments().Length == 1 &&
				 	m.GetParameters().Length == 1 &&
					m.GetParameters()[0].ParameterType == typeof(DbContext))
				 .MakeGenericMethod(modelType);


			var castMethod = typeof(Enumerable).GetMethod("Cast", BindingFlags.Public | BindingFlags.Static)!
				.MakeGenericMethod(modelType);

			var toListMethod = typeof(Enumerable).GetMethod("ToList", BindingFlags.Public | BindingFlags.Static)!
				.MakeGenericMethod(modelType);

			var list = toListMethod.Invoke(null, new object[] { castMethod.Invoke(null, new object[] { (IList)getTable.Invoke(null, [new UniversityContext()]) }) });

			var param = Expression.Parameter(modelType, "x");
			var tempSel = Expression.Lambda(typeof(Func<,>).MakeGenericType(modelType, typeof(object)), Expression.Invoke(Expression.Constant(GetKeyOf(modelType)), param), param);
			dynamic keySel = tempSel.Compile();

			dynamic tracker = Activator.CreateInstance(typeof(ChangeTracker<>).MakeGenericType(modelType))!;

			tracker.Initialize(list, keySel);

			return tracker;
		}

		public static readonly Dictionary<Type, Func<object, object>> _keyMap =
		new Dictionary<Type, Func<object, object>>() {
			[typeof(Speciality)] = o => ((Speciality)o).SpecialityId,
			[typeof(Group)] = o => ((Group)o).GroupId,
			[typeof(Graduate)] = o => ((Graduate)o).DipNum,
			[typeof(Thesis)] = o => ((Thesis)o).DipNum,
			[typeof(Professor)] = o => ((Professor)o).ProfessorId,
			[typeof(Subject)] = o => ((Subject)o).SubjectId,
			[typeof(SubjectGraduate)] = o => (((SubjectGraduate)o).DipNum, ((SubjectGraduate)o).SubjectId),
		};

		public static Func<object, object> GetKeyOf(Type modelType)
			=> _keyMap.TryGetValue(modelType, out var keySelector) ? keySelector : throw new InvalidOperationException($"No key selector for {modelType.Name}");

		public static bool IsDefaultValue(object value) {
			if (value == null) return true;

			switch (value) {
				case int i:
					return i == 0;
				case long l:
					return l == 0L;
				case string s:
					return string.IsNullOrEmpty(s);
				case ValueTuple vt:
					return true;
				case ITuple tuple:
					return IsDefaultTuple(tuple);
				default:
					return IsDefaultForType(value);
			}
		}

		private static bool IsDefaultTuple(ITuple tuple) {
			for (int i = 0; i < tuple.Length; i++) {
				if (!IsDefaultValue(tuple[i]))
					return false;
			}
			return true;
		}

		private static bool IsDefaultForType(object value) {
			var type = value.GetType();
			if (!type.IsValueType) return false;

			var defaultValue = Activator.CreateInstance(type);
			return Equals(value, defaultValue);
		}
	}
}
