using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader
{
	public class SqlHelperBase : IDisposable
	{
		protected DbDataReader dataReader;
		public SqlHelperBase(DbDataReader dataReader)
		{
			this.dataReader = dataReader;
		}
		public void Dispose()
		{
			if(dataReader != null)
			{
				dataReader.Close();
			}
			
		}
	}
}
