using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelper.Interfaces
{
	/// <summary>
	/// Базовый класс для чтения данных sql
	/// </summary>
	interface ISqlHelperReaderBase
	{
		/// <summary>
		/// Получить значение sql определенного типа
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		T Read<T>(string FieldName);
		/// <summary>
		/// Полученный результат чтения записи
		/// </summary>
		object Data { get; set; }
	}
}
