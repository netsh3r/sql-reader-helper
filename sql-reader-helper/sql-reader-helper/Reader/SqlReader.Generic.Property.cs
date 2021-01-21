using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader.Reader
{
	public class SqlReader<T,TProperty> : SqlReader<T>
	{
		public SqlReader(DbDataReader dataReader, string propertyName) : base(dataReader)
		{
			base.ColumnName = propertyName;
		}
		public new SqlReader<T> Column(string ColumnName)
		{
			return base.Column(ColumnName);
		}
	}
}
