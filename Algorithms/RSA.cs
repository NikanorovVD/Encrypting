using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public static class RSA
    {
        public static byte[] Encrypt(byte[] origin_data, (int e, int n) key)
        {
            byte[] result_data = new byte[origin_data.LongLength];
            for(long i = 0; i < origin_data.LongLength; i++)
            {
                result_data[i] = (byte)(DecimalPow(origin_data[i], key.e, key.n) % key.n);
            }
            return result_data;
        }
        public static byte[] Decrypt(byte[] origin_data, (int d, int n) key)
        {
            byte[] result_data = new byte[origin_data.LongLength];
            for (long i = 0; i < origin_data.LongLength; i++)
            {
                result_data[i] = (byte)(DecimalPow(origin_data[i], key.d, key.n) % key.n);
            }
            return result_data;
        }

        private static decimal DecimalPow(int x, int power, int mod)
        {
            int r = x;
            for (int i = 0; i < power - 1; i++)
            {
                r = (r*x) % mod;
            }
            return r;
        }
    }
}
