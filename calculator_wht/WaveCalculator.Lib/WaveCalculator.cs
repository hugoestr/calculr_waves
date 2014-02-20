using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WaveCalculator.Lib
{
    public class WaveCalculator
    {
        public WaveState Calculate(double lambda, double H, double h)
        {
            var result = new WaveState();
            double g, RhoWater, k, omega, c, cg, T, kh, u, E, P, Hs, f;

             g = 9.807;
             RhoWater = 1000;
             k = 2 * Math.PI / lambda;
             kh = k * h;
             
             omega = Math.Sqrt(g * k * Math.Tanh(kh));
             
             c = omega / k;
             cg = c / 2 * (1 + (2 * kh / Math.Sinh(2 * kh)));
             
             T = 2 * Math.PI / omega;
             f = 1 / T;
             E = RhoWater * g * Math.Pow(H, 2) / 8;

             Hs = Math.Sqrt(2) * H;
             P = (RhoWater * Math.Pow(g, 2)) / (32 * Math.PI) * T * Math.Pow(Hs, 2) / 2;
             u = g * H * k / (2 * omega);

            // Base properties of waves
            result.state = getState(kh);
            result.omega = omega;
            result.T = T;
            result.f = f;
            result.k = k;
            // Derived values
            result.P = P;
            result.u = u;
            result.Hs = Hs;
            result.c = c;
            result.cg = cg;
            result.E = E;
          
            return result;
        }
     
        private string getState(double kh)
        {
            var result = "";
            
            int value = Convert.ToInt32(kh);
            if (value >= Math.PI)
            {
                result = "deep";
            }
            else if (value <= Math.PI / 10)
            {
                result = "shallow";
            }
            else
            {
                result = "intermediate";
            }

            return result;
        }

    }
}
