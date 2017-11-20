using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Encryptor;
using ImageCrypto;
using System.Windows.Forms;

namespace HeaderDecoding
{
    public class KeyGen
    {
        private RSACryptoServiceProvider serviceProvider;
        private RSAParameters privKey;
        private RSAParameters pubKey;
        public KeyGen()
        {
            serviceProvider = new RSACryptoServiceProvider(2048);
            privKey = serviceProvider.ExportParameters(true);
            pubKey = serviceProvider.ExportParameters(false);
        }
        private const int BufferSize = 245;
        public byte[] Encrypt(byte[] data)
        {
            serviceProvider.ImportParameters(pubKey);
            List<byte[]> chunkedData = new List<byte[]>();
            byte[] Header = data.Take(54).ToArray();
            byte[] content = data.Skip(54).ToArray();
            MemoryStream memoryStream = new MemoryStream(content);
            while (memoryStream.Length > memoryStream.Position)
            {
                byte[] chunk = new byte[BufferSize];
                for (int i = 0; i < BufferSize; i++)
                {
                    chunk[i] = (byte)memoryStream.ReadByte();
                }
                chunk = serviceProvider.Encrypt(chunk, false);
                Form1.step++;
                chunkedData.Add(chunk);
            }
            var result = new List<byte>();
            result.AddRange(Header);
            foreach (var c in chunkedData)
            {
                result.AddRange(c);
            }
            testChunk = chunkedData[0];
            return result.ToArray();
        }
        private byte[] testChunk;
        public byte[] Decrypt(byte[] data)
        {
            serviceProvider.ImportParameters(privKey);
            List<byte[]> chunkedData = new List<byte[]>();
            byte[] Header = data.Take(54).ToArray();
            byte[] content = data.Skip(54).ToArray();
            MemoryStream memoryStream = new MemoryStream(content);
            while (memoryStream.Length > memoryStream.Position)
            {
                byte[] chunk = new byte[256];
                for (int i = 0; i < 256; i++)
                {
                    chunk[i] = (byte)memoryStream.ReadByte();
                }
                chunk = serviceProvider.Decrypt(chunk, false);
                chunkedData.Add(chunk);
                Form1.step++;
            }
            var result = new List<byte>();
            result.AddRange(Header);
            foreach (var c in chunkedData)
            {
                result.AddRange(c);
            }

            return result.ToArray();
        }
        public string GetPublicKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, pubKey);
            return sw.ToString();
        }
        public string GetPrivateKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, privKey);
            return sw.ToString();
        }
    }
}
