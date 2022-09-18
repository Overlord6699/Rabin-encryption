using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace WindowsFormsApp1
{
    class RabinDecryptor
    {
        public byte BytesPerSymbol { get; private set; }


        public BigInteger Yp { get; private set; }
        public BigInteger Yq { get; private set; }

        public BigInteger[] M_p { get; private set; }
        public BigInteger[] M_q { get; private set; }

        private BigInteger n, p,q,b;

        BigInteger[,] ostArray;
        public RabinDecryptor(in BigInteger n, in BigInteger[] secretKey, in BigInteger b)
        {
            this.n = n;
            p = secretKey[0];
            q = secretKey[1];
            this.b = b;
        }

        //нод(a,b) = a*x1+b*y1

        private BigInteger[] ExtendedEuclideanAlgorithm(in BigInteger aInp, in BigInteger bInp)
        {
            //начинаю со 2 итерации
            BigInteger x1 = BigInteger.Zero;
            BigInteger x0 = BigInteger.One;
            BigInteger y1 = BigInteger.One;
            BigInteger y0 = BigInteger.Zero;

            BigInteger a1 = aInp;
            BigInteger a0 = bInp;

            //ожидать a1 = 0
            while (a1 != BigInteger.Zero)
            {
                BigInteger q = a0 / a1;
                BigInteger tr = a1;

                a1 = a0 - q * a1;
                a0 = tr;

                BigInteger ts = x1;
                x1 = x0 - q * x1;
                x0 = ts;

                BigInteger tt = y1;
                y1 = y0 - q * y1;
                y0 = tt;
            }

            return new[] { a0, x0, y0 };
        }

        public BigInteger[,] GetOstArray()
        {
            return ostArray;
        }

        public BigInteger[,] Decrypt(in BigInteger[] input)
        {
            BigInteger[] D = new BigInteger[input.Length];           

            for (int i = 0; i < input.Length; i++)
            {
                D[i] = Algorithm.FastPowMod(BigInteger.Pow(b, 2) + 4 * input[i], 1, n);
            }

            M_p = new BigInteger[D.Length];
            M_q = new BigInteger[D.Length];

            for (int i = 0; i < D.Length; i++)
            {
                M_p[i] = Algorithm.FastPowMod(D[i], (p + 1) / 4, p);
                M_q[i] = Algorithm.FastPowMod(D[i], (q + 1) / 4, q);
            }

            BigInteger[] res = ExtendedEuclideanAlgorithm(p, q);
            Yp = res[2]; //y0
            Yq = res[1]; //x0

            int numOfRows = D.Length, numOfCols = 4;
            ostArray = new BigInteger[numOfRows, numOfCols];

            for (int i = 0; i < numOfRows; i++)
            {
                ostArray[i, 0] = (Yp * p * M_q[i] + Yq * q * M_p[i]) % n; //d1 = (yp*p*mq + yq*q* mp) mod n
                ostArray[i, 1] = (n - ostArray[i, 0]); // d2= n - d1
                ostArray[i, 2] = (Yp * p * M_q[i] - Yq * q * M_p[i]) % n; //d3 = (yp*p*mq - yq*q* mp) mod n
                ostArray[i, 3] = n - ostArray[i, 2]; //d4 = n - d3
            }

            BigInteger[,] M = new BigInteger[numOfRows, numOfCols];
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCols; j++)
                {
                    M[i, j] = (((ostArray[i, j] - b) % 2 == 0) ?
                        (-b + ostArray[i, j]) / 2 % n :
                        (-b + n + ostArray[i, j]) / 2 % n);
                }
            }

            return M;
        }
    }
}
