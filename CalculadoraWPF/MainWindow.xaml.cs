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

namespace CalculadoraWPF
{
    public enum OperationSelected
    {
        Sum,
        Subtract,
        Multiplication,
        Division
    };

    public partial class MainWindow : Window
    {
        
        double previousNumber, result;
        OperationSelected operationSelected;

        public MainWindow()
        {
            InitializeComponent();

            signDelete.Click += Delete_Click;
            signPercentage.Click += SignPercentage_Click;
            signEqual.Click += SignEqual_Click;
            signDecimal.Click += SignDecimal_Click;
            signRoot.Click += SignRoot_Click;

        }

        private void SignRoot_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultBar.Text.ToString(), out previousNumber))
            {
                previousNumber = Math.Sqrt(previousNumber);
                resultBar.Text = $"{previousNumber}";
            }
        }

        private void SignDecimal_Click(object sender, RoutedEventArgs e)
        {
            resultBar.Text = resultBar.Text.ToString().Contains(",") ? resultBar.Text : $"{resultBar.Text},";
        }

        private void SignEqual_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultBar.Text.ToString(), out newNumber))
            {
                switch(operationSelected)
                {
                    case OperationSelected.Sum:
                        result = Calculator.Sum(previousNumber, newNumber);
                        break;

                    case OperationSelected.Subtract:
                        result = Calculator.Subtract(previousNumber, newNumber);
                        break;

                    case OperationSelected.Multiplication:
                        result = Calculator.Multiplication(previousNumber, newNumber);
                        break;

                    case OperationSelected.Division:
                        result = Calculator.Division(previousNumber, newNumber);
                        break;
                }
            }

            resultBar.Text = $"{result}";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // It shows the 0 on the screen and saves the previous value in the variable previousNumber
            if (double.TryParse(resultBar.Text.ToString(), out previousNumber))
            {
                resultBar.Text = "0";
            }

            // Select the operation you want to perform by pressing the button
            operationSelected = sender == signMultiplication ? OperationSelected.Multiplication : operationSelected;
            operationSelected = sender == signDivision ? OperationSelected.Division : operationSelected;
            operationSelected = sender == signSum ? OperationSelected.Sum : operationSelected;
            operationSelected = sender == signSubtract ? OperationSelected.Subtract : operationSelected;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int valueSelected = int.Parse((sender as Button).Content.ToString());
            
            if(resultBar.Text.Length < 11)
            {
                if (resultBar.Text.ToString() == "0")
                {
                    resultBar.Text = $"{valueSelected}";
                }
                else
                {
                    resultBar.Text = $"{resultBar.Text}{valueSelected}";
                }
            }
            else
            {
                MessageBox.Show(
                    "No se puede ingresar más de 11 números",
                    "Operación incorrecta",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }

        }

        private void SignPercentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultBar.Text.ToString(), out previousNumber))
            {
                previousNumber = previousNumber / 100;
                resultBar.Text = $"{previousNumber}";
            }
        }

        private void SignNegative_Click(object sender, RoutedEventArgs e)
        {
            // Convert the result to negative
            if(double.TryParse(resultBar.Text.ToString(), out previousNumber))
            {
                previousNumber = previousNumber * -1;
                resultBar.Text = $"{previousNumber}";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Clear result on screen
            resultBar.Text = "0";
        }

        }
    }
