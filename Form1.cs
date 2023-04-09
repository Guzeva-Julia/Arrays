using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huzeva_Lab18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ОДНОВИМІРНИЙ МАСИВ
        private void butCalculate_Click(object sender, EventArgs e)
        {
            // Отримання рядка введеного користувачем.
            string input = ElementsTextBoxes.Text;

            // Розділення рядка на числа та збереження їх у масив.
            string[] inputNumbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = inputNumbers.Length;
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = double.Parse(inputNumbers[i]);
            }

            // Розрахунок кількості від'ємних елементів.
            int negativeCount = 0;
            foreach (double element in array)
            {
                if (element < 0)
                {
                    negativeCount++;
                }
            }
            lblNegativeCount.Text = $" {negativeCount}";

            // Розрахунок суми модулів елементів після мінімального за модулем елементу.
            double minAbsValue = Math.Abs(array[0]);
            int minIndex = 0;
            for (int i = 1; i < n; i++)
            {
                double absValue = Math.Abs(array[i]);
                if (absValue < minAbsValue)
                {
                    minAbsValue = absValue;
                    minIndex = i;
                }
            }

            double sum = 0;
            for (int i = minIndex + 1; i < n; i++)
            {
                sum += Math.Abs(array[i]);
            }
            lblSuma.Text = $"Сума елементів після мінімального за модулем елементу: {sum}";
        }
        //ДВОВИМІРНИЙ МАСИВ
        private void butCalc_Click(object sender, EventArgs e)
        {
            int rows = int.Parse(txtRows.Text);
            int cols = int.Parse(txtCols.Text);
            double[,] array = new double[rows, cols];

            // Читання елементів масиву
            string[] input = txtArray.Text.Split(' ');
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = double.Parse(input[i * cols + j]);
                }
            }

            // Виведення на екран всього масиву
            string output = " ";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    output += array[i, j] + " ";
                }
                output += "\n";
            }
            lblArrayOutput.Text = output;

            // Виведення на екран усіх елементів другого стовбця масиву
            output = " ";
            for (int i = 0; i < rows; i++)
            {
                output += array[i, 1] + "\n";
            }
            lblIIColumnOutput.Text = output;

            // Виведення на екран усіх елементів m-го рядка масиву
            int m = int.Parse(txtRowNumber.Text) - 1; //-1 щоб рядок дійсно рахував з першої строки.
            if (m >= 0 && m < rows)
            {
                output = "";
                for (int j = 0; j < cols; j++)
                {
                    output += array[m, j] + " ";
                }
                lblMRowOutput.Text = output;
            }
            else
            {
                lblMRowOutput.Text = "Некоректний номер рядка";
            }
        }

     }
    
}
