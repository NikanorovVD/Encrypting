using System;
using System.IO;
using static EncryptionAlgorithms.FilesUtils;

namespace EncryptionAlgorithms
{
    public class RSAEncryptor : IEncryptor
    {
        private string file_path;
        private string open_key_path;
        private string close_key_path;
        private string encrypt_file_path;

        private (int e, int n) open_key;
        private (int d, int n) close_key;

        public RSAEncryptor(string file_path, string open_key_path, string close_key_path, string encrypt_file_path, int p , int q)
        {
            this.file_path = file_path;
            this.open_key_path = open_key_path;
            this.close_key_path = close_key_path;
            this.encrypt_file_path = encrypt_file_path;

            CheckSimple(p);
            CheckSimple(q);

            int n = p * q;
            int f = (p - 1) * (q - 1);
            int e = ChooseE();
            int d = FindD(f,e);

            open_key = (e, n);
            close_key = (d, n);
        }

        public void WriteEncryptFile()
        {
            byte[] data = ReadFile(new FileInfo(file_path));
            byte[] encrypt_data = RSA.Encrypt(data, open_key);

            WriteFile(encrypt_data, encrypt_file_path);
        }

        public void WriteKeyFile()
        {
            FileInfo file1 = new FileInfo(open_key_path);
            using BinaryWriter writer1 = new(file1.Open(FileMode.OpenOrCreate));
            writer1.Write(open_key.e);
            writer1.Write(open_key.n);

            FileInfo file2 = new FileInfo(close_key_path);
            using BinaryWriter writer2 = new(file2.Open(FileMode.OpenOrCreate));
            writer2.Write(close_key.d);
            writer2.Write(close_key.n);
        }

        private int ChooseE()
        {
            return 5;
        }

        private int FindD(int f, int e)
        {
            decimal d;
            int k = 1;
            while(true)
            {
                d = (decimal)((k * f + 1)) / e;
                if (d % 1 == 0) return (int)d;
                k++;
            }
        }

        private void CheckSimple(int x)
        {

        }
    }
}
