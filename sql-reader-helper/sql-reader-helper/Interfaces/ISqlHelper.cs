using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader.Interfaces
{
	interface ISqlHelper
	{
		/// <summary>
		/// Получть класс для чтения результата
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		SqlReader<T> Read<T>();
		/// <summary>
		/// получить результат в зависимости от типа
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		bool Read<T>(string FieldName,out T param);
	}
}
