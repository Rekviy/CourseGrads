SELECT CONSTRAINT_NAME  
FROM   INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE  TABLE_NAME = ''  -- Table Name
       AND TABLE_SCHEMA = 'dbo'  -- change it if table is in some other schema 
       AND CONSTRAINT_TYPE = 'PRIMARY KEY' 

ALTER TABLE --table
drop constraint --constr
drop table --table
