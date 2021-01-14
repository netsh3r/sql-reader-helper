using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelper.Reader
{
	public class SqlHelperReader : SqlHelperReaderBase
	{
		/// <summary>
		/// конструктор для хранения переменной dataReader
		/// </summary>
		/// <param name="DataReader"></param>
		public SqlHelperReader(DbDataReader DataReader) : base(DataReader)
		{
		}

		/// <summary>
		/// Считать свойство
		/// </summary>
		/// <typeparam name="T">тип</typeparam>
		/// <param name="fieldName">название колонки</param>
		/// <returns>объект выбранного типа</returns>
		public T Reader<T>(string fieldName)
		{
			return Read<T>(fieldName);
		}
		/// <summary>
		/// Изменить свойство в зависимости от полученного объекта
		/// </summary>
		/// <param name="newData"></param>
		/// <returns></returns>
		public SqlHelperReader SetData(object newData)
		{
			base.Data = newData;
			return this;
		}

		public override T Read<T>(string FieldName)
		{
			int FieldIndex;
			try { FieldIndex = DataReader.GetOrdinal(FieldName); }
			catch { return default(T); }

			if (DataReader.IsDBNull(FieldIndex))
			{
				return default(T);
			}
			else
			{
				object readData = DataReader.GetValue(FieldIndex);
				if (readData is T)
				{
					return (T)readData;
				}
				else
				{
					try
					{
						return (T)Convert.ChangeType(readData, typeof(T));
					}
					catch (InvalidCastException)
					{
						return default(T);
					}
				}
			}
		}
	}
}
