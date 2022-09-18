using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace WindowsFormsApp1
{
    class RabinEncryptor
    {

        private BigInteger p, q, b;
        public BigInteger N { get; private set; }


        public RabinEncryptor(in BigInteger p, in BigInteger q)
        {
            this.p = p;
            this.q = q;     

            N = GeneratePublicKey();
            Random r = new Random();
            this.b = N - 100;
        }

        public RabinEncryptor(in BigInteger p, in BigInteger q, in BigInteger b)
        {
            this.p = p;
            this.q = q;
            this.b = b;

            N = GeneratePublicKey();
        }

        public BigInteger[] GetSecretKey()
        {
            return new BigInteger[] { p, q };
        }

        public BigInteger GetB()
        {
            return b;
        }

        public bool SetB(in BigInteger b)
        {
            if (b < N)
            {
                this.b = b;
                return true;
            }

            return false;
        }

        private BigInteger GeneratePublicKey()
        {
            return p * q;
        }

        public BigInteger[] Encrypt(in byte[] input)
        {
            BigInteger[] output = new BigInteger[input.Length];

            for(int i = 0; i < input.Length; i++)
                output[i] = (input[i] * (input[i] + b) % N);

            return output;
        }

        private byte CalculateMaxSizeInBytes(in BigInteger[] result)
        {
            byte[] NumOfBitsPerSymbol = new byte[result.Length];

            for(int i = 0; i < result.Length; i++)
            {
                NumOfBitsPerSymbol[i] = (byte) Math.Ceiling(Math.Log((double)result[i] + 1, 2));
            }

            byte numOfBits = NumOfBitsPerSymbol.Max();
            byte numOfBytes = (byte)Math.Ceiling((double)(numOfBits / 8));

            return numOfBytes;
        }   
    }
}
