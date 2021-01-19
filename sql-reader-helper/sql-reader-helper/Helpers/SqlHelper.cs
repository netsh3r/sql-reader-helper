using SqlHelperReader.Reader;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader
{
	public class SqlHelper : SqlHelperBase
	{
		private SqlReader sqlReader;
		public SqlHelper(DbDataReader dbReader) : base(dbReader) 
		{
			this.sqlReader = new SqlReader(dbReader);
		}

		private string Read(string columnName)
		{
			sqlReader.Read
			return null;
		}

		private T Read<T>(string columnName)
		{
			return default(T);
		}
	}
}
