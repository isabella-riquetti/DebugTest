using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Avalia.Ras.Infra.CrossCutting.Identity.Authorization
{
    /// <summary>Contains methods and properties for two-way encryption and decryption</summary>
    /// <author>Chidi C. Ezeukwu</author>
    /// <written>May 24, 2004</written>
    /// <Updated>Aug 07, 2004</Updated>
    public class SymCryptography
    {
        #region Private members...

        private string _key = "16dcceb3-6014-441d-a785-a1417b431d61";
        private string _salt = string.Empty;
        private readonly ServiceProviderEnum _algorithm;
        private readonly SymmetricAlgorithm _cryptoService;

        private void SetLegalIv()
        {
            // Set symmetric algorithm
            switch (_algorithm)
            {
                case ServiceProviderEnum.Rijndael:
                    _cryptoService.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };
                    break;
                default:
                    _cryptoService.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };
                    break;
            }
        }

        #endregion

        #region Public interfaces...

        public enum ServiceProviderEnum
        {
            // Supported service providers
            Rijndael,
            // ReSharper disable InconsistentNaming
            RC2,
            DES,
            TripleDES
            // ReSharper restore InconsistentNaming
        }

        public SymCryptography()
        {
            // Default symmetric algorithm
            _cryptoService = new RijndaelManaged { Mode = CipherMode.CBC };
            _algorithm = ServiceProviderEnum.Rijndael;
        }

        public SymCryptography(ServiceProviderEnum serviceProvider)
        {
            switch (serviceProvider)
            {
                case ServiceProviderEnum.Rijndael:
                    _cryptoService = new RijndaelManaged();
                    _algorithm = ServiceProviderEnum.Rijndael;
                    break;
                case ServiceProviderEnum.RC2:
                    _cryptoService = new RC2CryptoServiceProvider();
                    _algorithm = ServiceProviderEnum.RC2;
                    break;
                case ServiceProviderEnum.DES:
                    _cryptoService = new DESCryptoServiceProvider();
                    _algorithm = ServiceProviderEnum.DES;
                    break;
                case ServiceProviderEnum.TripleDES:
                    _cryptoService = new TripleDESCryptoServiceProvider();
                    _algorithm = ServiceProviderEnum.TripleDES;
                    break;
            }
            _cryptoService.Mode = CipherMode.CBC;
        }

        public SymCryptography(string serviceProviderName)
        {
            // Select symmetric algorithm
            switch (serviceProviderName.ToLower())
            {
                case "rijndael":
                    serviceProviderName = "Rijndael";
                    _algorithm = ServiceProviderEnum.Rijndael;
                    break;
                case "rc2":
                    serviceProviderName = "RC2";
                    _algorithm = ServiceProviderEnum.RC2;
                    break;
                case "des":
                    serviceProviderName = "DES";
                    _algorithm = ServiceProviderEnum.DES;
                    break;
                case "tripledes":
                    serviceProviderName = "TripleDES";
                    _algorithm = ServiceProviderEnum.TripleDES;
                    break;
            }

            // Set symmetric algorithm
            _cryptoService = (SymmetricAlgorithm)CryptoConfig.CreateFromName(serviceProviderName);
            _cryptoService.Mode = CipherMode.CBC;
        }

        public virtual byte[] GetLegalKey()
        {
            // Adjust key if necessary, and return a valid key
            if (_cryptoService.LegalKeySizes.Length > 0)
            {
                // Key sizes in bits
                int keySize = _key.Length * 8;
                int minSize = _cryptoService.LegalKeySizes[0].MinSize;
                int maxSize = _cryptoService.LegalKeySizes[0].MaxSize;
                int skipSize = _cryptoService.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                {
                    // Extract maximum size allowed
                    _key = _key.Substring(0, maxSize / 8);
                }
                else if (keySize < maxSize)
                {
                    // Set valid size
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;
                    if (keySize < validSize)
                    {
                        // Pad the key with asterisk to make up the size
                        _key = _key.PadRight(validSize / 8, '*');
                    }
                }
            }
            var key = new PasswordDeriveBytes(_key, Encoding.ASCII.GetBytes(_salt));
#pragma warning disable 612,618
            return key.GetBytes(_key.Length);
#pragma warning restore 612,618
        }

        public virtual string Encrypt(string plainText)
        {
            byte[] plainByte = Encoding.ASCII.GetBytes(plainText);
            byte[] keyByte = GetLegalKey();

            // Set private key
            _cryptoService.Key = keyByte;
            SetLegalIv();

            // Encryptor object
            ICryptoTransform cryptoTransform = _cryptoService.CreateEncryptor();

            // Memory stream object
            var ms = new MemoryStream();

            // Crpto stream object
            var cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write);

            // Write encrypted byte to memory stream
            cs.Write(plainByte, 0, plainByte.Length);
            cs.FlushFinalBlock();

            // Get the encrypted byte length
            byte[] cryptoByte = ms.ToArray();

            // Convert into base 64 to enable result to be used in Xml
            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));
        }

        public virtual string Decrypt(string cryptoText)
        {
            // Convert from base 64 string to bytes
            byte[] cryptoByte = Convert.FromBase64String(cryptoText);
            byte[] keyByte = GetLegalKey();

            // Set private key
            _cryptoService.Key = keyByte;
            SetLegalIv();

            // Decryptor object
            var cryptoTransform = _cryptoService.CreateDecryptor();
            try
            {
                // Memory stream object
                var ms = new MemoryStream(cryptoByte, 0, cryptoByte.Length);

                // Crpto stream object
                var cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Read);

                // Get the result from the Crypto stream
                var sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        public bool VerifyPassword(string encryptedPassword, string password)
        {
            if (encryptedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            var encryptedPasswordProvided = Encrypt(password);

            return string.Equals(encryptedPassword, encryptedPasswordProvided);
        }

        #endregion
    }
}