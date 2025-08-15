using System;
using Microsoft.Maui.Controls;

namespace AppCalculadora
{
    public partial class CalculadoraMarcal : ContentPage
    {
        string currentEntry = "";
        string operatorEntry = "";
        double firstNumber = 0;
        double secondNumber;

        public CalculadoraMarcal()
        {
            InitializeComponent();
        }

        void OnNumberClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentEntry += button.Text;

            if (!string.IsNullOrEmpty(operatorEntry))
            {
                displayLabel.Text = firstNumber.ToString() + " " + operatorEntry + " " + currentEntry;
            }
            else
            {
                displayLabel.Text = currentEntry;
            }
        }


        void OnOperatorClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operatorEntry = button.Text == "X" ? "*" : button.Text;

            if (double.TryParse(currentEntry.Replace(',', '.'), out firstNumber))
            {
                currentEntry = "";
                displayLabel.Text = firstNumber.ToString() + " " + operatorEntry;
            }
        }

        void OnDecimalClicked(object sender, EventArgs e)
        {
            if (!currentEntry.Contains(","))
            {
                currentEntry += ",";
                displayLabel.Text = currentEntry;
            }
        }

        void OnClearClicked(object sender, EventArgs e)
        {
            currentEntry = "";
            firstNumber = 0;
            operatorEntry = "";
            displayLabel.Text = "0";
        }

        void OnEqualsClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentEntry.Replace(',', '.'), out secondNumber))
            {
                double result = 0;

                switch (operatorEntry)
                {
                    case "+": result = firstNumber + secondNumber; break;
                    case "-": result = firstNumber - secondNumber; break;
                    case "*": result = firstNumber * secondNumber; break;
                    case "/":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber;
                        else
                        {
                            displayLabel.Text = "Erro";
                            return;
                        }
                        break;
                }

                currentEntry = result.ToString().Replace('.', ',');
                displayLabel.Text = currentEntry;
                operatorEntry = "";
            }
        }

        void OnBackspaceClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentEntry))
            {
                currentEntry = currentEntry.Substring(0, currentEntry.Length - 1);
                if (currentEntry == "")
                    displayLabel.Text = "0";
                else
                    displayLabel.Text = currentEntry;
            }
        }
    }
}
