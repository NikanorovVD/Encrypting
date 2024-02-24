using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EncryptionAlgorithms.FilesUtils;

namespace EncryptionAlgorithms
{
    public class VerticalPermutationDecryptor : IDecryptor
    {
        private string file_path;
        private string decrypt_file_path;
        private string key_path;
        private int[] key;

        public VerticalPermutationDecryptor(string file_path, string decrypt_file_path, string key_path)
        {
            this.file_path = file_path;
            this.decrypt_file_path = decrypt_file_path;
            this.key_path = key_path;
        }

        public void ReadKeyFile()
        {
            using BinaryReader reader = new(new FileInfo(key_path).Open(FileMode.Open));
            int len = reader.ReadInt32();
            key = new int[len];
            for (int i = 0; i < len; i++)
            {
                key[i] = reader.ReadInt32();
            }
        }

        public void WriteDecryptFile()
        {
            byte[] data = ReadFile(new FileInfo(file_path));
            byte[] decrypt_data = VerticalPermutation.Decrypt(data, key);
            WriteFile(decrypt_data, decrypt_file_path);
        }
    }
}
