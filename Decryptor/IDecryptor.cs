using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public interface IDecryptor
    {
        public void WriteDecryptFile();
        public void ReadKeyFile();
    }
}
