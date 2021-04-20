using SqlHelperReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_reader_helper.Dictionary
{
	/// <summary>
	/// Чтение данных из бд
	/// </summary>
	public class SqlReader : SqlReaderBase
	{
		public SqlReader(IDictionary<string, object> dictionaryReader) : base(dictionaryReader) { }
		
		//</inheritdoc>
		public override T Read<T>(string FieldName)
		{
			return (T)base.DictionaryReader[FieldName];
		}

		public override SqlReader<T> Read<T>()
		{
			throw new NotImplementedException();
		}
	}
}
