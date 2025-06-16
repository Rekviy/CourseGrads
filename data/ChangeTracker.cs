using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseGrads.Data {

	public class ChangeTracker<T> where T : INotifyPropertyChanged {
		public BindingList<T> List { get; private set; }
		public HashSet<T> Added { get; } = new();
		private HashSet<T> Pending_Added { get; } = new();
		public HashSet<T> Modified { get; } = new();
		public HashSet<T> Deleted { get; } = new();
		public Func<T, object> KeyOf { get; private set; }

		public void Initialize(IEnumerable<T> initialItems, Func<T, object> keySelector) {
			UnsubscribeAll();
			List = new BindingList<T>(initialItems.ToList());
			foreach (var item in List.ToList()) {
				item.PropertyChanged += OnItemPropertyChanged!;
			}
			List.ListChanged += OnListChanged!;
			KeyOf = keySelector;
		}
		public List<T> Merge(List<T> toMerge) {
			toMerge.RemoveAll(item => Deleted.Any(d => KeyOf(d).Equals(KeyOf(item))));

			foreach (var mod in Modified) {
				var idx = toMerge.FindIndex(item => KeyOf(item).Equals(KeyOf(mod)));
				if (idx >= 0) toMerge[idx] = mod;
			}

			toMerge.AddRange(Added);

			return toMerge;
		}
		public void HandleRowDeleting(T item) {
			item.PropertyChanged -= OnItemPropertyChanged!;
			if (!Added.Remove(item)) {
				Modified.Remove(item);
				Deleted.Add(item);
			}
		}

		public void ClearChanges() {
			Added.Clear(); Modified.Clear(); Deleted.Clear();
		}

		public T? ConvertTo(object entity) {
			if (entity is T)
				return (T)entity;

			return default(T);
		}
		public Type GetEntityType() {
			return typeof(T);
		}
		private void UnsubscribeAll() {
			if (List != null) {
				foreach (var item in List.ToList())
					item.PropertyChanged -= OnItemPropertyChanged!;
				List.ListChanged -= OnListChanged!;
			}
		}
		private void OnListChanged(object s, ListChangedEventArgs e) {
			
			switch (e.ListChangedType) {
				case ListChangedType.ItemAdded:
					var newItem = List[e.NewIndex];
					var newKey = KeyOf(newItem);
					newItem.PropertyChanged += OnItemPropertyChanged!;
					if (ChangeTrackerHelper.IsDefaultValue(newKey))
						Pending_Added.Add(newItem);
					else
						Added.Add(newItem);
					break;
				case ListChangedType.ItemChanged:
					var item = List[e.NewIndex];
					var key = KeyOf(item);
					if (Pending_Added.Contains(item)) {
						if (!ChangeTrackerHelper.IsDefaultValue(key)) {
							Pending_Added.Remove(item);
							Added.Add(item);
						}
					}
					else if(!Added.Contains(item))
						Modified.Add(item);
					break;
			}
		}
		private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e) {
			var item = (T)sender;
			if (!Added.Contains(item)||!Pending_Added.Contains(item)) Modified.Add(item);
		}

	}
}
