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

		public object Read(string columnName)
		{
			return sqlReader.Read<object>(columnName);
		}

		public T Read<T>(string columnName)
		{
			return sqlReader.Read<T>(columnName);
		}

		public SqlReader<T> Read<T>()
		{
			return sqlReader.Read<T>();
		}
	}
}
