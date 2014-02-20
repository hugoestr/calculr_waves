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
using System.Diagnostics;
using System.ComponentModel;
using MathNet.Numerics;

using calculator_wht;


namespace WaveStructure
{
     class Program
    {
         public void Main(string[] args)
         {
             double lambda, h, H;
             lambda = Double.Parse(box_L.Text);
             lambda = Convert.ToDouble(box_L.Text);
             H = Double.Parse(box_H.Text);
             H = Convert.ToDouble(box_H.Text);
             h = Double.Parse(box_h.Text);
             h = Convert.ToDouble(box_h.Text);

             double g, rho, k, omega, c, cg, T, kh, u, E, P;
             g = 9.807;
             rho = 1000;
             k = 2 * Math.PI / lambda;
             kh = k * h;
             
             omega = Math.Sqrt(g * k * Math.Tanh(kh));
             
             c = omega / k;
             cg = c / 2 * (1 + (2 * kh / Math.Sinh(2 * kh)));
             
             T = 2 * Math.PI / omega;
             
             E = rho * g * Math.Pow(H, 2) / 8;
             
             double Hs;
             
             Hs = Math.Sqrt(2) * H;
             P = (rho * Math.Pow(g, 2)) / (32 * Math.PI) * T * Math.Pow(Hs, 2) / 2;
             
             u = g * H * k / (2 * omega);

             string WaveState;

             int value = Convert.ToInt32(kh);
             if (value >= Math.PI)
             {
                 WaveState = "Deep";
             }
             else if (value <= Math.PI / 10)
             {
                 WaveState = "Shallow";
             }
             else
             {
                 WaveState = "Intermediate";
             }
             
             k = Math.Round(k, 3);
             omega = Math.Round(omega, 3);
             T = Math.Round(T, 2);
             c = Math.Round(c, 2);
             cg = Math.Round(cg, 2);
             E = Math.Round(E, 2);
             Hs = Math.Round(Hs, 2); 
             P = Math.Round(P, 2);
             u = Math.Round(u, 3);
              
              Console.ReadKey();
        }
    }
}
