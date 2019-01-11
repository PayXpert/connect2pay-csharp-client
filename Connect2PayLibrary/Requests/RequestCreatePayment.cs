using Connect2PayLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connect2PayLibrary.Requests
{
    public class OrderCartContent
    {
        public Int32 cartProductId { get; set; }
        public String cartProductName { get; set; }
        public float cartProductUnitPrice { get; set; }
        public Int32 cartProductQuantity { get; set; }
        public String cartProductBrand { get; set; }
        public String cartProductMPN { get; set; }
        public String cartProductCategoryName { get; set; }
        public Int32 cartProductCategoryID { get; set; }
    }

    public class RequestCreatePaymentObject : BaseRequestObject
    {
        // Anti-fraud

        public Int32? afClientId { get; set; }
        public String afPassword { get; set; }

        public String apiVersion { get; set; }

        // Shopper details
        public String shopperID { get; set; }
        public String shopperEmail { get; set; }
        public String shopperFirstName { get; set; }
        public String shopperLastName { get; set; }
        public String shopperPhone { get; set; }
        public String shopperAddress { get; set; }
        public String shopperState { get; set; }
        public String shopperZipcode { get; set; }
        public String shopperCity { get; set; }
        public String shopperCountryCode { get; set; }
        public String shopperCompany { get; set; }
        public String shopperLoyaltyProgram { get; set; }
        public String shopperBirthDate { get; set; }
        public String shopperIDNumber { get; set; }

        // Shipping details
        public String shipToFirstName { get; set; }
        public String shipToLastName { get; set; }
        public String shipToCompany { get; set; }
        public String shipToPhone { get; set; }
        public String shipToAddress { get; set; }
        public String shipToState { get; set; }
        public String shipToZipcode { get; set; }
        public String shipToCity { get; set; }
        public String shipToCountryCode { get; set; }
        public String shippingType { get; set; }
        public String shippingName { get; set; }

        // Order and payment details
        public String orderID { get; set; }
        public String currency { get; set; }
        public Int32 amount { get; set; }
        public Int32? orderTotalWithoutShipping { get; set; }
        public Int32? orderShippingPrice { get; set; }
        public Int32? orderDiscount { get; set; }
        public String customerIP { get; set; }
        public String orderFOLanguage { get; set; }
        public String orderDescription { get; set; }
        public List<OrderCartContent> orderCartContent { get; set; }

        // Payment details
        public String paymentType { get; set; }
        public String paymentMethod { get; set; }
        public String paymentNetwork { get; set; }
        public String provider { get; set; }
        public String operation { get; set; }
        public String paymentMode { get; set; }
        public Boolean secure3d { get; set; }

        // Subscription details
        public Int64? offerID { get; set; }
        public String subscriptionType { get; set; }
        public String trialPeriod { get; set; }
        public Int32? rebillAmount { get; set; }
        public String rebillPeriod { get; set; }
        public Int32? rebillMaxIteration { get; set; }

        // Template and flow control
        public String ctrlRedirectURL { get; set; }
        public String ctrlCallbackURL { get; set; }
        public String ctrlCustomData { get; set; }
        public String timeOut { get; set; }
        public Boolean? merchantNotification { get; set; }
        public String merchantNotificationTo { get; set; }
        public String merchantNotificationLang { get; set; }
        public Int64? themeID { get; set; }


        public RequestCreatePaymentObject()
        {
            this.apiVersion = "002.60";
        }

        public bool Validate()
        {
            // Check for required fields

            if (orderID == null || orderID.Length == 0)
            {
                return false;
            }

            if (currency == null || currency.Length == 0)
            {
                return false;
            }

            if (amount == 0)
            {
                return false;
            }

            if (shippingType == null || shippingType.Length == 0)
            {
                return false;
            }

            if (paymentMode == null || paymentMode.Length == 0)
            {
                return false;
            }

            // Check for fields length

            if ((shopperID != null && shopperID.Length > 32) ||
                (shopperEmail != null && shopperEmail.Length > 100) ||
                (shipToCountryCode != null && shipToCountryCode.Length > 2) ||
                (shopperCountryCode != null && shopperCountryCode.Length > 2) ||
                // (affiliateID != null && affiliateID.Length > 16) ||
                // (campaignName != null && campaignName.Length > 128) ||
                (orderID != null && orderID.Length > 100) ||
                (orderDescription != null && orderDescription.Length > 500) ||
                (currency != null && currency.Length > 500) ||
                (orderFOLanguage != null && orderFOLanguage.Length > 50) ||
                (shippingType != null && shippingType.Length > 50) ||
                (shippingName != null && shippingName.Length > 50) ||
                (paymentMethod != null && paymentMethod.Length > 32) ||
                (operation != null && operation.Length > 32) ||
                (paymentMode != null && paymentMode.Length > 30) ||
                (subscriptionType != null && subscriptionType.Length > 32) ||
                (trialPeriod != null && trialPeriod.Length > 10) ||
                (rebillPeriod != null && rebillPeriod.Length > 10) ||
                (ctrlRedirectURL != null && ctrlRedirectURL.Length > 2048) ||
                (ctrlCallbackURL != null && ctrlCallbackURL.Length > 2048) ||
                (timeOut != null && timeOut.Length > 10) ||
                (merchantNotificationTo != null && merchantNotificationTo.Length > 10) ||
                (merchantNotificationLang != null && merchantNotificationLang.Length > 10) ||
                (ctrlCustomData != null && ctrlCustomData.Length > 2048))
            {
                return false;
            }

            return true;
        }
    }

    public class RequestCreatePayment : RequestBase
    {
        private String customerToken = null;

        public RequestCreatePaymentObject Data {
            get { return (RequestCreatePaymentObject)this.requestObject; }
        }

        public RequestCreatePayment(RequestType Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            this.requestObject = new RequestCreatePaymentObject();
        }

        public async Task<CreatePaymentResponse> Send()
        {
            CreatePaymentResponse response = await SendRequestToServer<CreatePaymentResponse>();
            this.customerToken = response.customerToken;
            return response;
        }

        public String getCustomerRedirectURL()
        {
            if (customerToken == null)
            {
                return null;
            }
            else
            {
                return Utils.Combine(baseURL, "payment/" + customerToken);
            }
        }
    }
}
