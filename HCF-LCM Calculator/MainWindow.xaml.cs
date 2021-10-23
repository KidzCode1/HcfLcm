using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCF_LCM_Calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		bool loaded;
		int commonFactorProduct;
		int list1Product;
		int list2Product;
		public MainWindow()
		{
			InitializeComponent();
			loaded = true;
		}

		public static List<int> GetPrimeFactors(int originalNumber)
		{
			var primes = new List<int>();
			if (originalNumber == 0)
				return primes;

			//primes.Add(1);

			int testNumber = 2;

			int number = CollectPrimes(originalNumber, testNumber, primes);

			for (testNumber = 3; testNumber <= originalNumber; testNumber += 2)
				number = CollectPrimes(number, testNumber, primes);

			return primes;
		}

		private static int CollectPrimes(int number, int testNumber, List<int> primes)
		{
			while (testNumber.IsFactorOf(number))
			{
				primes.Add(testNumber);
				number = number / testNumber;  // number == ???
			}

			return number;
		}

		void FindCommonFactors()
		{
			if (int.TryParse(tbxNumber1.Text, out int result1))
			{
				lbFactors1.ItemsSource = GetPrimeFactors(result1);
			}

			if (int.TryParse(tbxNumber2.Text, out int result2))
			{
				lbFactors2.ItemsSource = GetPrimeFactors(result2);
			}


			List<int> list1 = lbFactors1.ItemsSource as List<int>;
			if (list1 == null)
				return;

			List<int> list2 = lbFactors2.ItemsSource as List<int>;
			if (list2 == null)
				return;

			List<int> results = new List<int>();

			foreach (int item in list1)
				if (list2.Contains(item))
				{
					results.Add(item);
					list2.Remove(item);
				}

			foreach (int item in results)
			{
				list1.Remove(item);
			}

			lbCommonFactors.ItemsSource = results;
			commonFactorProduct = GetProduct(results);
			list1Product = GetProduct(list1);
			list2Product = GetProduct(list2);
			tbMiddleProduct.Text = $"{commonFactorProduct}";
			tbLeftProduct.Text = $"{list1Product}";
			tbRightProduct.Text = $"{list2Product}";
			tbHCFAnswer.Text = $"HCF = {commonFactorProduct}";
			tbLCMAnswer.Text = $"LCM = {list1Product} * {commonFactorProduct} * {list2Product} = {commonFactorProduct * list1Product * list2Product}";

		}

		int GetProduct(List<int> list)
		{
			
			int answer = 1;
			foreach (int item in list) // 1, 2 * 3 * 4 * 5.....
			{
				answer = answer * item;
			}

			return answer;
		}

		private void tbxNumber_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!loaded)
				return;

			FindCommonFactors();
		}
	}
}
