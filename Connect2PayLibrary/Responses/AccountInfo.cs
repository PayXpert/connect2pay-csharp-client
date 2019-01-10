using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary.Responses
{
    public class PaymentMethodOption
    {
        public String name { get; set; }
        public String value { get; set; }
    }

    public class PaymentMethod
    {
        public String paymentMethod { get; set; }
        public String paymentNetwork { get; set; }
        public List<String> currencies { get; set; }
        public String defaultOperation { get; set; }
        public List<PaymentMethodOption> options { get; set; }
    }

    public class AccountInfoResponse : Connect2PayBaseResponseObject
    {
        public String apiVersion { get; set; }
        public String name { get; set; }
        public Boolean? displayTerms { get; set; }
        public String termsUrl { get; set; }
        public String supportUrl { get; set; }
        public int? maxAttempts { get; set; }
        public String notificationSenderName { get; set; }
        public String notificationSenderEmail { get; set; }
        public Boolean? notificationOnSuccess { get; set; }
        public Boolean? notificationOnFailure { get; set; }
        public Boolean? merchantNotification { get; set; }
        public String merchantNotificationTo { get; set; }
        public String merchantNotificationLang { get; set; }

        public List<PaymentMethod> paymentMethods { get; set; }

        public override bool IsSuccessfull()
        {
            throw new NotImplementedException();
        }
    }
}
