using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HeaderDecoding
{
    public sealed class Cipher
    {
        private RSACryptoServiceProvider serviceProvider;
        private RSAParameters privKey;
        private RSAParameters pubKey;
        private string pubKeyString;
        private string privKeyString;

        public Cipher()
        {
            serviceProvider = new RSACryptoServiceProvider(2048);
            privKey = serviceProvider.ExportParameters(true);
            pubKey = serviceProvider.ExportParameters(false);
            GeneratePrivateKey();
            GeneratePublicKey();
        }

        public byte[] Encrypt(byte[] data)
        {
           
        }

        
        
        public byte[] Decrypt(byte[] data)
        {
            try
            {
                LoadPrivateKey();
                var bytesDeCypher = serviceProvider.Decrypt(data, false);
                return bytesDeCypher;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                return null;
            }
        }

        private void GeneratePrivateKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, privKey);
            privKeyString = sw.ToString();
        }

        private void GeneratePublicKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, pubKey);
            pubKeyString = sw.ToString();
        }

        private void RecoverPrivateKey()
        {
            var sr = new StringReader(privKeyString);
            var xs = new XmlSerializer(typeof(RSAParameters));
            privKey = (RSAParameters)xs.Deserialize(sr);
        }

        private void RecoverPublicKey()
        {
            var sr = new StringReader(pubKeyString);
            var xs = new XmlSerializer(typeof(RSAParameters));
            pubKey = (RSAParameters)xs.Deserialize(sr);
        }
        private void LoadPublicKey()
        {
            serviceProvider = new RSACryptoServiceProvider();
            serviceProvider.ImportParameters(pubKey);
        }

        private void LoadPrivateKey()
        {
            serviceProvider = new RSACryptoServiceProvider();
            serviceProvider.ImportParameters(privKey);
        }

    }
}
