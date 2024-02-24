using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EncryptionAlgorithms.FilesUtils;

namespace EncryptionAlgorithms
{
    public class VerticalPermutationEncryptor : IEncryptor
    {
        private string file_path;
        private int[] key;
        private string key_path;
        private string encrypt_file_path;

        public VerticalPermutationEncryptor(string file_path, int[] key, string key_path, string encrypt_file_path)
        {
            this.file_path = file_path;
            this.key = key;
            this.key_path = key_path;
            this.encrypt_file_path = encrypt_file_path;
        }

        public void WriteEncryptFile()
        {
            byte[] data = ReadFile(new FileInfo(file_path));
            byte[] encrypt_data = VerticalPermutation.Encrypt(data, key);

            WriteFile(encrypt_data, encrypt_file_path);
        }

        public void WriteKeyFile()
        {
            FileInfo file = new FileInfo(key_path);
            using BinaryWriter writer = new(file.Open(FileMode.OpenOrCreate));
            writer.Write(key.Length);
            for (int i = 0; i < key.Length; i++)
            {
                writer.Write(key[i]);
            }
        }


    }
}
