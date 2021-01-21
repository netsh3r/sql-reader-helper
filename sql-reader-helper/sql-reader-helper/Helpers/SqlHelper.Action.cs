using SqlHelperReader.Reader;
using SqlHelperReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseHelper = SqlHelperReader;

namespace SqlHelperReader.Action
{
	/// <summary>
	/// Помощник чтения данных из бд
	/// </summary>
	public class SqlHelper : SqlHelperBase
	{
		public SqlHelper(DbDataReader dataReader) : base(dataReader) { }

		/// <summary>
		/// Получить класс для чтения результата
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public SqlReader<T> Read<T>()
		{
			return Read<T>(string.Empty);
		}
		/// <summary>
		/// получить класс для чтения результата
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ColumnName">название колонки</param>
		/// <returns></returns>
		public SqlReader<T> Read<T>(string ColumnName)
		{
			return new SqlReader<T>(base.dataReader, ColumnName);
		}
		/// <summary>
		/// Получить значение свойства
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ColumnName"></param>
		/// <param name="param"></param>
		/// <returns></returns>
		public bool Read<T>(string ColumnName,out T param)
		{
			try
			{
				param = Read<T>(ColumnName).Value;
				if(param != null)
				{
					return true;
				}
			}
			catch(Exception ex)
			{
				param = default(T);
				Console.WriteLine(ex.Message);
			}
			return false;
		}
	}
}
