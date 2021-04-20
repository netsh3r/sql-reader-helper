using NUnit.Framework;
using sql_reader_helper.Dictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_reader_helper.test
{
	[TestFixture]
	public class SqlReaderDictionary
	{
		[Test]
		public void GetPropertyReader()
		{
			var list = new List<IDictionary<string, object>>();
			list.Add(new Dictionary<string, object>() { { "123", 123 } });
			var reader = new SqlReader(list[0]);
			var result = reader.Read<int>("123");
			Assert.AreEqual(result, 123);
		}
	}
}
