using SqlHelper.Reader;
using System;
using System.Data.Common;

namespace SqlHelper
{
	public class SqlReader<T> : SqlHelperReader
	{
		/// <summary>
		/// Конструктор для сохранения свойства dataReader
		/// </summary>
		/// <param name="DataReader"></param>
		public SqlReader(DbDataReader DataReader) : base(DataReader)
		{
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
		/// <summary>
		/// считать запись в зависимости от результата
		/// </summary>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		public SqlReader<T> Read(string FieldName)
		{
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
			//new SqlReader<T>(base.DataReader)
			action(this);
			return this;
		}
	}
}