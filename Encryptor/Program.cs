using EncryptionAlgorithms;
using System;
using System.IO;

namespace Encryptor
{
    internal class Program
    {
        static string files_dir = @"../../../../Files";
        static string encrypt_file_path = @$"{files_dir}/encrypt{N}.{extention}";
        static string key_path = @$"{files_dir}/key{N}.bin";

        const int N = 4;
        const string extention = "txt";
        static string file_path = @$"{files_dir}/test{N}.{extention}";

        static int[] key = { 8, 5, 3, 6, 1, 2, 4, 0, 7 };
        //static IEncryptor encryptor = new VerticalPermutationEncryptor(file_path, key, key_path, encrypt_file_path);
        static IEncryptor encryptor = new RSAEncryptor(file_path,  key_path+"open", key_path + "close",encrypt_file_path, 19, 13);


        static void Main(string[] args)
        {
            if (!File.Exists(file_path))
            {
                Console.WriteLine($"Файл {file_path} не существует");
                return;
            }

            encryptor.WriteEncryptFile();
            encryptor.WriteKeyFile();
        }
    }
}
