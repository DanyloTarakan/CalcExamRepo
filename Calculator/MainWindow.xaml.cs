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
            textBoxExample.Text += (sender as Button).Content;

            if ((sender as Button).Content.ToString() == "=")
                Calculate();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBoxExample.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBoxExample.Text = textBoxExample.Text.Remove(textBoxExample.Text.Length - 1);
        }

        private void Calculate()
        {
            textBoxExample.Text = Analizer.Calculate(textBoxExample.Text).ToString();
        }
    }
}
