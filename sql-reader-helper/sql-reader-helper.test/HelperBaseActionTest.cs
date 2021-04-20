using Moq;
using NUnit.Framework;
using sql_reader_helper.test.Mocks;
using SqlHelperReader;
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
				helper.Read<string>().Action(t =>
				{
					c = t.Read<string>("c");
				});
				Assert.AreEqual(c,"123"); 
			}
		}
		[Test]
		public void GetColumnWithActionAndWithoutParams()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				string c = helper.Read<string>().Action(t =>
				{
					t.Read<string>("c");
				});
				Assert.AreEqual(c, "123");
			}
		}
		[Test]
		public void GetColumnWithActionAsParams()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				Assert.AreEqual((string)helper.Read<string>().Action(t =>
				{
					t.Read<string>("c");
				}), "123");
			}
		}
		[Test]
		public void GetColumnWithActionWithValue()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				Assert.AreEqual(helper.Read<string>().Action(t =>
				{
					t.Read<string>("c");
				}).Value, "123");
			}
		}
		[Test]
		public void GetColumnWithoutAction()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				object c = (string)helper.Read<string>("c");
				Assert.AreEqual(c, "123");
			}
		}
		[Test]
		public void GetColumnWithoutActionWithProperty()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				string c = helper.Read<string>("c");
				Assert.AreEqual(c, "123");
			}
		}
	}
}
