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
		public IDictionary<string, object> DictionaryReader;
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
		public SqlReaderBase(IDictionary<string, object> dictionaryReader)
		{
			this.DictionaryReader = dictionaryReader;
		}
		/// <summary>
		/// Получить значение sql определенного типа
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		public abstract T Read<T>(string FieldName);
		/// <summary>
		/// Получить значение через Action
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public abstract SqlReader<T> Read<T>();
		/// <summary>
		/// Полученный результат чтения записи
		/// </summary>
		public object Data { get; set; }
	}
}
