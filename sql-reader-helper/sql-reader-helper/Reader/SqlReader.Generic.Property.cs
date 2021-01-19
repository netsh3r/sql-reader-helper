using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader.Reader
{
	public class SqlReader<T,TProperty>
	{
		private IDictionary<string, object> property;
		public SqlReader(string propertyName)
		{
			property.Add(propertyName,default(T));
		}
		public SqlReader<T, TProperty> Column(string ColumnName)
		{
			return this;
		}
	}
}
