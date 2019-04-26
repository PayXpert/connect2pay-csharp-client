using Connect2PayLibrary.Requests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Connect2PayLibrary
{
    public class Connect2PayClient
    {
        private String url;
        private String originatorId;
        private String password;

        public Connect2PayClient(String Url, String OriginatorId, String Password)
        {
            this.url = Url;
            this.originatorId = OriginatorId;
            this.password = Password;
        }

        public Connect2PayClient(String OriginatorId, String Password)
        {
            this.url = "https://connect2.payxpert.com";
            this.originatorId = OriginatorId;
            this.password = Password;
        }

        public RequestCreatePayment NewRequestCreatePayment()
        {
            return new RequestCreatePayment(RequestType.CREATE_PAYMENT, originatorId, password, url, null);
        }

        public RequestPaymentStatus NewRequestPaymentStatus(String MerchantToken)
        {
            return new RequestPaymentStatus(RequestType.GET_PAYMENT_STATUS, originatorId, password, url, MerchantToken);
        }

        public RequestTransactionInfo NewRequestTransactionInfo(String TransactionID)
        {
            return new RequestTransactionInfo(RequestType.GET_TRANSACTION_INFORMATION, originatorId, password, url, TransactionID);
        }

        public RequestAccountInfo NewRequestAccountInfo()
        {
            return new RequestAccountInfo(RequestType.ACCOUNT_INFO, originatorId, password, url);
        }

        #region Refund, rebill, cancel

        public RequestRefundRebillCancel NewRequestRefund(String TransactionID)
        {
            return new RequestRefundRebillCancel(RequestType.REFUND_TRANSACTION, originatorId, password, url, TransactionID);
        }

        public RequestRefundRebillCancel NewRequestRebill(String TransactionID)
        {
            return new RequestRefundRebillCancel(RequestType.REBILL_TRANSACTION, originatorId, password, url, TransactionID);
        }

        public RequestRefundRebillCancel NewRequestTransactionCancel(String TransactionID)
        {
            return new RequestRefundRebillCancel(RequestType.CANCEL_TRANSACTION, originatorId, password, url, TransactionID);
        }

        #endregion

        #region Subscriptions

        public RequestSubscriptionCancel NewRequestSubscriptionCancel(String SubscriptionID)
        {
            return new RequestSubscriptionCancel(RequestType.CANCEL_SUBSCRIPTION, originatorId, password, url, SubscriptionID);
        }

        public RequestWeChatDirect NewRequestWeChatDirect(String CustomerToken)
        {
            return new RequestWeChatDirect(RequestType.WECHAT_DIRECT, originatorId, password, url, CustomerToken);
        }

        public RequestAliPayDirect NewRequestAliPayDirect(String CustomerToken)
        {
            return new RequestAliPayDirect(RequestType.ALIPAY_DIRECT, originatorId, password, url, CustomerToken);
        }

        #endregion

        #region Encryption utils

        private static string OpenSSLDecrypt(string encrypted, string passphrase)
        {
            //get the key bytes (not sure if UTF8 or ASCII should be used here doesn't matter if no extended chars in passphrase)
            var key = Encoding.UTF8.GetBytes(passphrase);

            //pad key out to 32 bytes (256bits) if its too short
            if (key.Length < 32)
            {
                var paddedkey = new byte[32];
                Buffer.BlockCopy(key, 0, paddedkey, 0, key.Length);
                key = paddedkey;
            }

            //setup an empty iv
            var iv = new byte[16];

            //get the encrypted data and decrypt
            byte[] encryptedBytes = Convert.FromBase64String(encrypted);
            return DecryptStringFromBytesAes(encryptedBytes, key, iv);
        }

        private static string DecryptStringFromBytesAes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create a RijndaelManaged object
            // with the specified key and IV.
            aesAlg = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.None, KeySize = 256, BlockSize = 128, Key = key, IV = iv };

            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                        srDecrypt.Close();
                    }
                }
            }

            return plaintext;
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public bool HandleRedirectStatus(String encryptedData, String merchantToken)
        {
            var key = Base64Decode(merchantToken);
            var binData = Base64Decode(encryptedData);

            var json = OpenSSLDecrypt(binData, key);

            var parsed = JObject.Parse(json);

            return true;
        }

        #endregion
    }
}
