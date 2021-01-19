using SqlHelperReader.Reader;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader.Helpers
{
	public sealed class SqlHelper<T> : IDisposable where T: new() 
	{
		private DbDataReader _dataReader;
		private T _model;
		public SqlHelper(DbDataReader dataReader)
		{
			this._dataReader = dataReader;
			this._model = new T();
		}
		public SqlReader<T, TProperty> Property<TProperty>(Expression<Func<T,TProperty>> expression)
		{
			var name = TypeExtension.GetPropertyName(expression);
			return new SqlReader<T, TProperty>(name);
		}

		public T GetValue()
		{
			return _model;
		}

		public void Dispose()
		{
			_dataReader.Close();
		}
	}
}
