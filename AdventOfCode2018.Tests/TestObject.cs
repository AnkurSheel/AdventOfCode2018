using System.Collections.Generic;

namespace AdventOfCode2018.Tests
{
	class TestObject<T1, T2>
	{
		public List<T1> Data { get; set; }
	
		public T2 Result { get; set; }
	}
}