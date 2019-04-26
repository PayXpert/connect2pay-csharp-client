using Connect2PayLibrary;
using SDKTest;
using System;
using System.Collections.Generic;
using System.Text;
using SDKTest;

namespace Connect2PayDemo
{
    partial class Program
    {
        private static void TestRedirectEncryption()
        {
            var client = new Connect2PayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);

            var result = client.HandleRedirectStatus(getEncryptedData(), getMerchantToken());
        }

        private static String getEncryptedData()
        {
            return "C1w0nrYb6B_2yc3mheyRX9vXvuIr2b3-OZSM8RKzKJqYVZlHOPa4seVUmBOeTJ49xqlPR9DoUskBQsyEzTs74rQYdEDqwYk0n4Vac4wF3t_FxkG-GNd2sBcTmrKaeJXLnRuKP1KHHEIi-fZTzwe5pNnOon4bgxJJF_L-PuSHq4xs2P6OJjCUPW_pg3s9bRxdJKHAYaV11EOfwmX_O0dSIyPMCBhOGilmeC7obVY1ePYUW_9w1SgGMZJBslm6LYT3g_adsb2FxfUErJM9wH1eHjAQCG-OJbKx7Ii_4xzMDYM7a3V8DwZZPXBXW9EQI9kQLY2M9kD65uKYvFZd-bmTSAM03n5_bcyUtSznlIG3jE6ZMQmBwDcHAXKzpjtVTqAMa_VfRe-YhGVNdGRebxLjc_Ko96xHxJfMgai6k5P5mCNqIYEDvcCCqHlUU7LCY7yjJSBdAlG-AUPjy62Jmy-G_AHcrFycVgcl4IMvxhaS3Oll2h1ismzU_7qy7XQzcWyDKY8SLuYEoJdQ1u0mTO-u9WlmlQI13Gtwt9V0zDJsWwV8uIaUStX0CFMNDTxAFc8bQIsTST1s1GTb5vJ6vhA4Yawc_kkvfTn43GShjBoy6ahiUID02K6v7qZQrkluOcPT5REyVBFre6BQdDYFzCbAblMQQnD_CBquK7yFHDq8Cu4uJ5LTA_I2ZFtJpatNm1_eqen7QhFLpGZXrrU-rIK9grb44-RximkMjgi5rbropALtPXr5nA3RWZTaHr5h_Lw675pXHJfaf9piOpazuJ45m5RyHk7tgW0u2cf6NYuESt-ozXDyf59XLneSERlt24btK5UE3bB7AfKUQRp10";
        }

        private static String getMerchantToken()
        {
            return "W2n1yR8UXNJBrJxbsqOy3g";
        }
    }
}
