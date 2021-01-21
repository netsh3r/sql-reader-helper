using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_reader_helper.test.Mocks.Entity
{
	internal class MockUser:Entity<int>
	{
		public string Name { get; set; }
	}
}
