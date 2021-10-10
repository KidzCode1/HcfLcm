using System;
using System.Linq;

namespace HCF_LCM_Calculator
{
	public static class ExtensionMethods
	{
		public static bool IsFactorOf(this int testNumber, int number)
		{
			return number % testNumber == 0;  // % (mod, or modulus) means remainder after an integer divide operation.
		}
	}
}
