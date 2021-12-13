using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalculadoraWPF
{
    public class Calculator
    {
        public static double Sum(double previousNumber, double newNumber)
        {
            return previousNumber + newNumber;
        }

        public static double Subtract(double previousNumber, double newNumber)
        {
            return previousNumber - newNumber;
        }

        public static double Multiplication(double previousNumber, double newNumber)
        {
            return previousNumber * newNumber;
        }

        public static double Division(double previousNumber, double newNumber)
        {
            if(newNumber == 0)
            {
                MessageBox.Show(
                    "No se puede dividir entre 0",
                    "Operación incorrecta",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                return 0;

            } 
                return previousNumber / newNumber;
        }
    }
}
