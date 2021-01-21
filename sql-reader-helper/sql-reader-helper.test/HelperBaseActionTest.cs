using Moq;
using NUnit.Framework;
using sql_reader_helper.test.Mocks;
using SqlHelperReader.Action;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_reader_helper.test
{
	[TestFixture]
	public class HelperBaseActionTest
	{
		private Mock<DbDataReader> MockDataReader;
		[SetUp]
		public void Init()
		{
			MockDataReader = MockData.GetDbDataReader();
		}

		[Test]
		public void CreateActionHelperBase()
		{
			using(var helper = new SqlHelper(MockDataReader.Object))
			{
				Assert.IsNotNull(helper);
			}
		}

		[Test]
		public void GetColumnWithAction()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				string c = string.Empty;
				helper.Read<string>("c").Action(t=>
				{
					c = t.Value;
				});
				Assert.AreEqual(c,"123"); 
			}
		}
		[Test]
		public void GetColumnWithoutAction()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				string c = helper.Read<string>("c").Value;
				Assert.AreEqual(c, "123");
			}
		}
		[Test]
		public void GetColumnWithoutActionWithProperty()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				string c;
				helper.Read<string>("c",out c);
				Assert.AreEqual(c, "123");
			}
		}
	}
}
