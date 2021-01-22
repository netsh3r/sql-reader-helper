using Moq;
using NUnit.Framework;
using sql_reader_helper.test.Mocks;
using sql_reader_helper.test.Mocks.Entity;
using SqlHelperReader.Generic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_reader_helper.test
{
	[TestFixture]
	public class HelperBaseGenericTest
	{
		private Mock<DbDataReader> MockDataReader;
		[SetUp]
		public void Init()
		{
			MockDataReader = MockData.GetDbDataReader();
		}
		[Test]
		public void CreateGenericHelperBase()
		{
			using (var helper = new SqlHelper<MockUser>(MockDataReader.Object))
			{
				Assert.IsNotNull(helper);
			}
		}
		[Test]
		public void GetPropertyWithColumn()
		{
			using(var helper = new SqlHelper<MockUser>(MockDataReader.Object))
			{
				helper.Property(t => t.Name).Column("C");
				var model = helper.GetValue();
				Assert.IsNotNull(model);
				Assert.AreEqual(model.Name, "123");
			}
		}
		[Test]
		public void GetPropertyWithColumnByName()
		{
			using (var helper = new SqlHelper<MockUser>(MockDataReader.Object))
			{
				helper.Property<string>("Name").Column("C");
				var model = helper.GetValue();
				Assert.IsNotNull(model);
				Assert.AreEqual(model.Name, "123");
			}
		}
		[Test]
		public void GetPropertyWithColumnAndAction()
		{
			using (var helper = new SqlHelper<MockUser>(MockDataReader.Object))
			{
				helper.Property(t=> t.Name).Column("C").Action(c=> 
				{
					var value = c.Value;
				});
				var model = helper.GetValue();
				Assert.IsNotNull(model);
				Assert.AreEqual(model.Name, "123");
			}
		}
	}
}
