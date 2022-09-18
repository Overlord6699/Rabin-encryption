using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace WindowsFormsApp1
{
    public static class Algorithm
    {
        public static BigInteger FastPowMod(BigInteger number, BigInteger power, in BigInteger mod)
        {
            BigInteger res = 1;

            while (power != 0)
            {
                while (power % 2 == 0)
                {
                    power /= 2;
                    number = (number * number) % mod;
                }

                power--;
                res = (res * number) % mod;
            }

            return res;
        }
    }
}
