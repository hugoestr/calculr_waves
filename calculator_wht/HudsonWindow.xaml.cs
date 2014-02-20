using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

using WaveCalculator.Lib;
using WaveCalculator.Controls;



namespace calculator_wht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 

    public partial class HudsonWindow : Window
    {
        Calculator Hudsoncalculator;
        public HudsonWindow()
        {
            InitializeComponent();
            Hudsoncalculator = new Calculator();
        }

        private void hbox_L_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            var L = double.Parse(hbox_L.Text);
            var h = double.Parse(hbox_h.Text);
            var alpha = double.Parse(hbox_alpha.Text);
            var KD = double.Parse(hbox_KD.Text);
            var l = double.Parse(hbox_l.Text);

            alpha = (Math.PI / 180) * alpha;

            var result = Hudsoncalculator.Calculate(L, l, h);
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

   


}
