using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public static class FilesUtils
    {
        public static byte[] ReadFile(FileInfo file)
        {
            using BinaryReader reader = new(file.Open(FileMode.Open));
            byte[] data = reader.ReadBytes((int)file.Length);
            return data;
        }
        public static void WriteFile(byte[] data, string path)
        {
            FileInfo file = new FileInfo(path);
            using BinaryWriter writer = new(file.Open(FileMode.OpenOrCreate));
            writer.Write(data);
        }
    }
}
