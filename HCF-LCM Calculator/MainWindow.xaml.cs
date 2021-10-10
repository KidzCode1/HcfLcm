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

			primes.Add(1);

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

		private void tbxNumber1_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!loaded)
				return;
			if (int.TryParse(tbxNumber1.Text, out int result))
			{
				lbFactors1.ItemsSource = GetPrimeFactors(result);
			}
		}

		private void tbxNumber2_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!loaded)
				return;
			if (int.TryParse(tbxNumber2.Text, out int result))
			{
				lbFactors2.ItemsSource = GetPrimeFactors(result);
			}
		}
	}
}
