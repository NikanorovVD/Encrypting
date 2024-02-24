using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EncryptionAlgorithms.FilesUtils;

namespace EncryptionAlgorithms
{
    internal class RSADecryptor : IDecryptor
    {
        private string file_path;
        private string close_key_path;
        private string decrypt_file_path;

        private (int d, int n) close_key;

        public RSADecryptor(string file_path, string close_key_path, string decrypt_file_path)
        {
            this.file_path = file_path;
            this.close_key_path = close_key_path;
            this.decrypt_file_path = decrypt_file_path;
        }

        public void ReadKeyFile()
        {
            using BinaryReader reader = new(new FileInfo(close_key_path).Open(FileMode.Open));
            int d = reader.ReadInt32();
            int n = reader.ReadInt32();
            close_key = (d, n);
        }

        public void WriteDecryptFile()
        {
            byte[] data = ReadFile(new FileInfo(file_path));
            byte[] encrypt_data = RSA.Decrypt(data, close_key);

            WriteFile(encrypt_data, decrypt_file_path);
        }
    }
}
