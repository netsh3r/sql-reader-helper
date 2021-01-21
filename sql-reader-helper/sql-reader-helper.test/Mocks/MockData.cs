using Moq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_reader_helper.test.Mocks
{
	internal class MockData
	{
		public static Mock<DbDataReader> GetDbDataReader()
		{

			bool readToggle = true;
			var MockDataReader = new Mock<DbDataReader>();
			MockDataReader.Setup(t => t.Read()).Returns(() => readToggle)
				.Callback(() => readToggle = false);
			MockDataReader.Setup(t => t[0]).Returns("123");
			MockDataReader.Setup(t => t["c"]).Returns("123");
			MockDataReader.Setup(t => t.GetValue(0)).Returns("123");
			return MockDataReader;
		}
	}
}
