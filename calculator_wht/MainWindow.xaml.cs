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
    public class Person : INotifyPropertyChanged
    {
        private string name;
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        public Person()
        {
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                //Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Name");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public partial class MainWindow : Window
    {
        Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        private void box_L_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            var h = double.Parse(box_h.Text);
            var H = double.Parse(box_H.Text);
            var L = double.Parse(box_L.Text);

            var result = calculator.Calculate(L, H, h);
            
            Result.Content = result.state;
            ResultWaveT.Content = Math.Round(result.T, 2);
            ResultWavef.Content = Math.Round(result.f, 2);
            ResultDispR.Content = Math.Round(result.omega, 3);
            ResultWavek.Content = Math.Round(result.k, 3);

            Resultu.Content = Math.Round(result.u, 2);
            ResultHs.Content = Math.Round(result.Hs, 2);
            Resultc.Content = Math.Round(result.c, 2);
            Resultcg.Content = Math.Round(result.cg, 2);
            ResultE.Content = Math.Round(result.E, 2);
            ResultP.Content = Math.Round(result.P, 2);
        }
        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            HudsonWindow secondWindow = new HudsonWindow();
            secondWindow.Show();

        }


 
        
    }

   


}
