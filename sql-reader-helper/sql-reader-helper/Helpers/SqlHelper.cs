using sql_reader_helper.Reader;
using SqlHelper.Interfaces;
using SqlHelper.Reader;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelper
{
	/// <summary>
	/// Помощник
	/// </summary>
	public class SqlHelper : ISqlHelper
	{
		private static DbDataReader _dataReader;
		/// <summary>
		/// Получить класс хелпер
		/// </summary>
		/// <param name="DataReader"></param>
		/// <returns></returns>
		public static SqlHelper Create(DbDataReader DataReader)
		{
			_dataReader = DataReader;
			return new SqlHelper();
		}

		/// <summary>
		/// Получть класс для чтения результата
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public SqlReader<T> Read<T>()
		{
			return new SqlReader<T>(_dataReader);
		}
		/// <summary>
		/// получить результат в зависимости от типа
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		public T Read<T>(string FieldName)
		{
			try
			{
				var helper = new SqlHelperReader(_dataReader);
				return helper.Reader<T>(FieldName);
			}
			catch (Exception e)
			{
				return default(T);
			}
		}
	}
}
