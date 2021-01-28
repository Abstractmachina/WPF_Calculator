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

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOp;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedVal = int.Parse((sender as Button).Content.ToString());

            if (result_label.Content.ToString() == "0")
            {
                result_label.Content = $"{selectedVal}";
            }
            else result_label.Content = $"{result_label.Content}{selectedVal}";
        }



        #region Operations
        private void Button_comma_Click(object sender, RoutedEventArgs e)
        {
            if (result_label.Content.ToString().Contains("."))
            {
                //do nothing
            }
            else
            {
                result_label.Content = $"{result_label.Content}.";
            }
            
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(result_label.Content.ToString(), out result))
            {
                switch (selectedOp)
                {
                    case SelectedOperator.Addition:
                        result += lastNumber;
                        break;
                    case SelectedOperator.Subtraction:
                        result = lastNumber - result;
                        break;
                    case SelectedOperator.Multiplication:
                        result *= lastNumber;
                        break;
                    case SelectedOperator.Division:
                        result = lastNumber / result;
                        break;
                    default:
                        break;
                }

                result_label.Content = result;
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(result_label.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                result_label.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(result_label.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                result_label.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            result_label.Content = "0";
        }

        

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(result_label.Content.ToString(), out lastNumber))
            {
                result_label.Content = "0";
            }
            if (sender == button_multiplication) selectedOp = SelectedOperator.Multiplication;
            if (sender == button_division) selectedOp = SelectedOperator.Division;
            if (sender == button_addition) selectedOp = SelectedOperator.Addition;
            if (sender == button_subtraction) selectedOp = SelectedOperator.Subtraction;
        }
    }

    #endregion
}
