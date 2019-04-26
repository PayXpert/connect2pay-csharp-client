using Connect2PayLibrary;
using NUnit.Framework;
using System;

namespace Connect2PayTest
{
    [TestFixture]
    public class ConnectorHandleRedirectTest
    {
        [Test]
        public void TestHandleRedirect()
        {
            var client = new Connect2PayClient("", "", "");

            var result = client.HandleRedirectStatus(getEncryptedData(), getMerchantToken());

            Assert.IsTrue(result);
        }

        private String getEncryptedData()
        {
            return "";
        }

        private String getMerchantToken()
        {
            return "";
        }
    }
}
