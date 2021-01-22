using SqlHelperReader.Helpers;
using SqlHelperReader.Reader;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperReader.Generic
{
	public sealed class SqlHelper<T> : SqlHelperBase where T: new() 
	{
		//private DbDataReader _dataReader;
		private IDictionary<string,SqlReader> sqlReaderModel;
		private T _model;
		public SqlHelper(DbDataReader dataReader):base(dataReader)
		{
			sqlReaderModel = new Dictionary<string, SqlReader>();
			this._model = new T();
		}
		public SqlReader<T, TProperty> Property<TProperty>(Expression<Func<T,TProperty>> expression)
		{
			var name = TypeExtension.GetPropertyName(expression);
			var reader = new SqlReader<T, TProperty>(base.dataReader,name);
			sqlReaderModel.Add(name,reader);
			return reader;
		}

		public SqlReader<T, TProperty> Property<TProperty>(string propertyName)
		{
			var reader = new SqlReader<T, TProperty>(base.dataReader, propertyName);
			sqlReaderModel.Add(propertyName, reader);
			return reader;
		}

		public SqlReader<T, TProperty> Property<TProperty>(TProperty property, string propertyName)
		{
			var reader = new SqlReader<T, TProperty>(base.dataReader, propertyName);
			sqlReaderModel.Add(propertyName, reader);
			return reader;
		}

		public T GetValue()
		{
			foreach(var read in sqlReaderModel)
			{
				var modelType = _model.GetType().GetProperty(read.Key);
				read.Value.SetData();
				modelType.SetValue(_model, read.Value.Data);
			}
			return _model;
		}
	}
}
