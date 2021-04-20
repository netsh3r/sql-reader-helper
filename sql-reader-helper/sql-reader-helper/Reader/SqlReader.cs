using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader.Reader
{
	public class SqlReader : SqlReaderBase
	{
		/// <summary>
		/// конструктор для хранения переменной dataReader
		/// </summary>
		/// <param name="DataReader"></param>
		public SqlReader(DbDataReader DataReader) : base(DataReader)
		{
		}
		
		public SqlReader(DbDataReader DataReader,string ColumnName) : base(DataReader,ColumnName)
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
		internal SqlReader SetData(object newData)
		{
			base.Data = newData;
			return this;
		}

		internal void SetData()
		{
			base.Data = Read(base.ColumnName);
		}
		/// <summary>
		/// Получить данные из бд
		/// </summary>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		internal object Read(string FieldName)
		{
			int FieldIndex;
			try { 
				FieldIndex = DataReader.GetOrdinal(FieldName);

				if (!DataReader.IsDBNull(FieldIndex))
				{
					return DataReader.GetValue(FieldIndex);
				}
			}
			catch { 
				return null; 
			}

			return null;
		}
		/// <summary>
		/// Получить данные из бд определенного типа
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		public override T Read<T>(string FieldName)
		{
			object readData = Read(FieldName);
			SetData(readData);
			if(readData != null)
			{
				if(readData is T)
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

			return default(T);
		}

		public override SqlReader<T> Read<T>()
		{
			return new SqlReader<T>(base.DataReader);
		}
	}
}
