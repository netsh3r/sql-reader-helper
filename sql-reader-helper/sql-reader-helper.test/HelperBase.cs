using NUnit.Framework;
using SqlHelperReader;
using System;

namespace sql_reader_helper.test
{
	[TestFixture]
	public class HelperBase
	{
		[Test]
		public void CreateHelperBase()
		{
			using(var helper = new SqlHelper(null))
			{
				Assert.IsNotNull(helper);
			}
		}
	}
}
