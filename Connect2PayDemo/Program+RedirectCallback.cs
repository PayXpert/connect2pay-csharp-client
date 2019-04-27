using Connect2PayLibrary;
using SDKTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayDemo
{
    partial class Program
    {
        private static void TestRedirectEncryption()
        {
            var result = Connect2PayClient.HandleRedirectStatus(getEncryptedData(), getMerchantToken());

            if (result.transactions.Count == 1)
            {
                Console.WriteLine("Test passed");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static String getEncryptedData()
        {
            return "ZRHd0TeyKnQ6GwPMRk8x1eMv6iLCrvHkQ-w-QCEd5a7LIiebsWAzKvSDOQR1D3STZMV7MZ1raUJuzA9hesogP7HEAiSMgcx2etr9zaigZYjurnVwQlousUXvKYvLIuWHCHVlkU9ItAejW9DAVP2XiDDUdVXcEoFrTkS6M6a0XQH3w5_yejMyjwV83Rg2eRkKoG0y4B26n7bcbDzSKAn4xo5RKsH7X0t5wQSEwplzCPeHz6QOdGm4py0FZNXiDOf2DXwWmx7CcxFLig2kSj13X9eOiINA9R-Gqdqf4Ue1JJky-knoKqT6IstuAZGj9KyVnV9p2LN_NamaFF_QdiqPNspwKSYo2y06tyYu1fbn6C1RQHtImnedPqEr5DKtCkJiCLQ3DXmnhmPSGqiyvaDngzBYubHa8BNsBh8CFFvaVoCvE076yRL3C4Q8ttw119SEsnQoWrZImV7DQrdpY8BJivIKjXR3JYGeuRgIByRdJYuBM9CBRHOcSM6KS1NoC9uJ2QH_M0oOP2Nh-8E_tX9PyuTqqFI51Y9ToPLw2S80kymzgpuD13xtHubR902Aewz8JAsmgaQ_DZb5Gu1C1bMxuZkc0NLhzJBSIWPy1c3QdR73ppRxuTJIa1SIyWClFPhlNxJL3p8Wb9LXnGhMALC1tA3D_rzfQZfok5tr1AkmR-rQtxmYcYseeepxKayVe22VxF2BPSMmo0nh0sLOb3l30d1xwJ3rD8Mvsnty9V8sw0AxtJT3av6qfRKX-ITiYHjj";
        }

        private static String getMerchantToken()
        {
            return "W2n1yR8UXNJBrJxbsqOy3g";
        }
    }
}
