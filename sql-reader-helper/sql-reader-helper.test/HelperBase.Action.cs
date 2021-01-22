using Moq;
using NUnit.Framework;
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
    public class HelperBaseAction
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
		public void CreateActionHelper()
		{
			using(var helper = new SqlHelper(MockDataReader.Object))
			{
				helper.Read<string>("C").Action(t =>
				{
					t.Data = t.Read();
				});
			}
		}
		[Test]
		public void GetColumnValueWithGeneric()
		{

		}
	}
}
