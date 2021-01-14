using SqlHelper.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelper
{
	/// <summary>
	/// Базовый класс для чтения данных sql
	/// </summary>
	public abstract class SqlHelperReaderBase : ISqlHelperReaderBase
	{
		public DbDataReader DataReader;
		public SqlHelperReaderBase(DbDataReader DataReader)
		{
			this.DataReader = DataReader;
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
