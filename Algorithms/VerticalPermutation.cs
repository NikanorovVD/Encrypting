using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public static class VerticalPermutation
    {
        public static byte[] Encrypt(byte[] data, int[] key)
        {
            int len = key.Length;

            byte[] origin_data = AddSymbols(data, len);
            byte[] result_data = new byte[origin_data.LongLength];
            for (int k = 0; k < len; k++)
            {
                WriteColumn(origin_data, result_data, len, key[k], k);
            }
            return result_data;
        }

        public static byte[] Decrypt(byte[] data, int[] key)
        {
            int len = key.Length;
            byte[] result_data = new byte[data.LongLength];
            for (int k = 0; k < len; k++)
            {
                ReadColumn(data, result_data, len, key[k], k);
            }
            return result_data;
        }


        private static void WriteColumn(byte[] origin_data, byte[] result_data, int len, int key, int k)
        {
            long column_len = origin_data.LongLength / len;
            for (long i = column_len * key; i < column_len * (key + 1); i++)
            {
                result_data[i] = origin_data[k];
                k += len;
            }
        }

        private static void ReadColumn(byte[] origin_data, byte[] result_data, int len, int key, int k)
        {
            long column_len = origin_data.LongLength / len;
            for (long i = column_len * key; i < column_len * (key + 1); i++)
            {
                result_data[k] = origin_data[i];
                k += len;
            }
        }

        private static byte[] AddSymbols(byte[] data, int len)
        {
            if (data.LongLength % len == 0) return data;

            List<byte> data_list = new List<byte>(data);

            while(data_list.Count % len != 0)
                data_list.Add(0);
            return data_list.ToArray();
        }
    }
}
