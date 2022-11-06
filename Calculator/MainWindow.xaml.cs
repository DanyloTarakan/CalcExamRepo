using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AnalizerClass;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();

            try
            {
                if (content == "=")
                    Calculate();
                else if (content == "+/-")
                    NumberInversion();
                else if (content == "mod")
                    textBoxExample.Text += "%";
                else
                    textBoxExample.Text += content;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBoxExample.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBoxExample.Text = textBoxExample.Text.Remove(textBoxExample.Text.Length - 1);
        }
        double numberRes,numberM=0;
        private void Calculate()
        {
            numberRes = Analizer.Calculate(textBoxExample.Text);
            textBoxExample.Text = numberRes.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            numberM = numberRes;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            numberM = 0;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            char c = textBoxExample.Text.Last();
            if (c == '*' || c == '+' || c == '-' || c == '/')
                textBoxExample.Text += numberM.ToString();

        }
        private void NumberInversion()
        {
            if(textBoxExample.Text != String.Empty)
            {
                int length = textBoxExample.Text.Split(new char[] { ' ', '+', '*', '/' }).Length;
                if (length == 1)
                {
                    if (textBoxExample.Text[0] != '-')
                        textBoxExample.Text = textBoxExample.Text.Insert(0, "-");
                    else
                        textBoxExample.Text = textBoxExample.Text.Remove(0, 1);
                }
            }
        }
    }
}
