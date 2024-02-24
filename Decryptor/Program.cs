using EncryptionAlgorithms;
using System.IO;
using System;

namespace Decryptor
{
    internal class Program
    {
        static string files_dir = @"../../../../Files";
        static string decrypt_file_path = @$"{files_dir}/decrypt{N}.{extention}";
        static string key_path = @$"{files_dir}/key{N}.bin";

        const int N = 4;
        const string extention = "txt";
        static string file_path = @$"{files_dir}/encrypt{N}.{extention}";

        //static IDecryptor decryptor = new VerticalPermutationDecryptor(file_path, decrypt_file_path, key_path);
        static IDecryptor decryptor = new RSADecryptor(file_path, key_path + "close", decrypt_file_path);

        static void Main(string[] args)
        {
            if (!File.Exists(file_path))
            {
                Console.WriteLine($"Файл {file_path} не существует");
                return;
            }
            //if (!File.Exists(key_path))
            //{
            //    Console.WriteLine($"Файл {key_path} не существует");
            //    return;
            //}

            decryptor.ReadKeyFile();
            decryptor.WriteDecryptFile();
        }
    }
}

