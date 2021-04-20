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
	public static class SqlHelperAction
	{
		public static SqlReader<T> Action<T>(this SqlReader<T> reader)
		{
			return reader;
		}
	}
}
