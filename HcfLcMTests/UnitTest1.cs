using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HCF_LCM_Calculator;

namespace HcfLcMTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void FactorTests()
		{
			Assert.IsTrue(3.IsFactorOf(12));
			Assert.IsTrue(7.IsFactorOf(56));
			Assert.IsFalse(5.IsFactorOf(8));
		}
	}
}
