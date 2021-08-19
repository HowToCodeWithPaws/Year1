using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sem25;

namespace UnitTestProject1
{
	[TestClass]
	public class CompanyTest
	{
		[TestMethod]
		public void TestPlusOperator()
		{
			Company a = new Company("a",1);
			Company b = new Company("b",1);

			Company res = a + b;
			Company exp = new Company("a & b", 2);

			Assert.AreEqual(res, exp);
		}
		[TestMethod]
		public void TestNotEquals()
		{
			Company a = new Company("a", 1);
			Company b = new Company("b", 1);

			Assert.AreEqual(a, b);
		}
		[TestMethod]
		public void TestEquals()
		{
			Company a = new Company("a", 1);
			Company b = new Company("a", 1);

			Assert.AreEqual(a, b);
		}
	}

}
