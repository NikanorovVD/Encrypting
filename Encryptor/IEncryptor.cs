using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithms
{
    public interface IEncryptor
    {
        public void WriteEncryptFile();
        public void WriteKeyFile();
    }
}
