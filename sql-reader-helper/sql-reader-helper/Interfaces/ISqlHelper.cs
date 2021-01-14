using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelper.Interfaces
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
		T Read<T>(string FieldName);
	}
}
