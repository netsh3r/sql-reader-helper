using SqlHelperReader.Reader;
using System;
using System.Data.Common;

namespace SqlHelperReader
{
	public class SqlReader<T> : SqlReader
	{
		/// <summary>
		/// Конструктор для сохранения свойства dataReader
		/// </summary>
		/// <param name="DataReader"></param>
		public SqlReader(DbDataReader DataReader) : base(DataReader)
		{
		}
		public SqlReader(DbDataReader DataReader, T tProperty) : base(DataReader)
		{
		}
		public SqlReader(DbDataReader DataReader,string ColumnName) : base(DataReader,ColumnName)
		{
			base.Data = base.Read<T>(ColumnName);
		}
		/// <summary>
		/// Полученное значение
		/// </summary>
		public T Value
		{
			get
			{
				return (T)base.Data;
			}
		}
		public SqlReader<T> Column(string ColumnName)
		{
			base.ColumnName = ColumnName;
			return this;
		}
		/// <summary>
		/// считать запись в зависимости от результата
		/// </summary>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		public new SqlReader<T> Read(string FieldName)
		{
			//if(string.IsNullOrEmpty())
			base.Data = base.Read<T>(FieldName);
			return this;
		}
		/// <summary>
		/// Выполнить логику чтения данных
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		public SqlReader<T> Action(Action<SqlReader<T>> action)
		{
			action(this);
			return this;
		}


	}
}