using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics;


namespace WaveCalculator.Lib
{
    class HudsonCalculator
    {
        public HudsonState Calculate(double L, double h, double alpha, double KD, double l)
        {
            var result = new HudsonState();
            double beta, HudsonForce, RhoRock, RhoWater, NS, Const, gammaR, u, g, H, WR, SR;

            RhoWater = 1000;
            RhoRock = 2500;
            beta = 0.78;
            Const = 1;
            g = 9.807;

            H = beta * h;
            u = Math.Sqrt(1 / beta * g * H);

            HudsonForce = Const / beta * Math.Pow(l, 2) * RhoWater * g * H;

            NS = Math.Pow(MathNet.Numerics.Trig.Cotangent(alpha), 3);
            gammaR = RhoRock * g;
            SR = RhoRock / RhoWater;

            WR = (Math.Pow(H, 3) * gammaR) / (Math.Pow((SR - 1), 3)) * KD * MathNet.Numerics.Trig.Cotangent(alpha);

            result.WR = WR;

        }
    }
}
