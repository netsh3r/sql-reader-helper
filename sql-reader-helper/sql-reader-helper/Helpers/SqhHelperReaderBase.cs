using SqlHelperReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader
{
	/// <summary>
	/// Базовый класс для чтения данных sql
	/// </summary>
	public abstract class SqlReaderBase : ISqlHelperReaderBase
	{
		public DbDataReader DataReader { get; set; }
		public string ColumnName { get; set; }
		public SqlReaderBase(DbDataReader DataReader)
		{
			this.DataReader = DataReader;
		}
		public SqlReaderBase(DbDataReader DataReader,string ColumnName)
		{
			this.DataReader = DataReader;
			this.ColumnName = ColumnName;
		}
		/// <summary>
		/// Получить значение sql определенного типа
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		public abstract T Read<T>(string FieldName);
		/// <summary>
		/// Полученный результат чтения записи
		/// </summary>
		public object Data { get; set; }
	}
}
