using Moq;
using NUnit.Framework;
using SqlHelperReader;
using System;
using System.Data.Common;

namespace sql_reader_helper.test
{
	[TestFixture]
	public class HelperBase
	{
		private Mock<DbDataReader> MockDataReader;
		[SetUp]
		public void Init()
		{
			bool readToggle = true;
			MockDataReader = new Mock<DbDataReader>();
			MockDataReader.Setup(t => t.Read()).Returns(() => readToggle)
				.Callback(() => readToggle = false);
			MockDataReader.Setup(t => t[0]).Returns("123");
			MockDataReader.Setup(t => t["c"]).Returns("123");
			MockDataReader.Setup(t => t.GetValue(0)).Returns("123");
		}
		[Test]
		public void CreateHelperBase()
		{
			using(var helper = new SqlHelper(null))
			{
				Assert.IsNotNull(helper);
			}
		}
		[Test]
		public void GetColumnValueWithoutType()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				var c = helper.Read("c");
				Assert.IsNotNull(c);
				Assert.IsTrue(c is string);
			}
		}
		[Test]
		public void GetColumnValueWithType()
		{
			using (var helper = new SqlHelper(MockDataReader.Object))
			{
				var c = helper.Read<string>("c");
				Assert.IsNotNull(c);
				Assert.IsTrue(c is string);
			}
		}
	}
}
