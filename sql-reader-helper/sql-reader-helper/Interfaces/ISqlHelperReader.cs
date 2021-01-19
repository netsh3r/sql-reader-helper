using SqlHelperReader.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader
{
	interface ISqlHelperReader
	{
		/// <summary>
		/// Считать свойство
		/// </summary>
		/// <typeparam name="T">тип</typeparam>
		/// <param name="fieldName">название колонки</param>
		/// <returns>объект выбранного типа</returns>
		T Reader<T>(string fieldName);
		/// <summary>
		/// Изменить свойство в зависимости от полученного объекта
		/// </summary>
		/// <param name="newData"></param>
		/// <returns></returns>
		SqlReader SetData(object newData);
		/// <summary>
		/// Считать свойство
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="FieldName"></param>
		/// <returns></returns>
		T Read<T>(string FieldName);
	}
}
