using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary
{
    public enum RequestType
    {
        CREATE_PAYMENT,
        GET_PAYMENT_STATUS,
        GET_TRANSACTION_INFORMATION,
        CANCEL_TRANSACTION,
        REFUND_TRANSACTION,
        REBILL_TRANSACTION,
        CANCEL_SUBSCRIPTION,
        WECHAT_DIRECT,
        ALIPAY_DIRECT,
        ACCOUNT_INFO
    }

    public static class PaymentMethod
    {
        public static String CREDIT_CARD = "CreditCard";
        public static String BANK_TRANSFER = "BankTransfer";
        public static String DIRECT_DEBIT = "DirectDebit";
        public static String TODITO_CASH = "ToditoCash";
        public static String WECHAT = "WeChat";
        public static String ALIPAY = "Alipay";
        public static String LINE = "Line";
    }

    public static class PaymentMode
    {
        public static String SINGLE = "Single";
        public static String ON_SHIPPING = "OnShipping";
        public static String RECURRENT = "Recurrent";
        public static String INSTALMENTS_PAYMENT = "InstalmentsPayments";
    }

    public static class ShippingType
    {
        public static String PHYSICAL = "Physical";
        public static String VIRTUAL = "Virtual";
        public static String ACCESS = "Access";
    }

    public static class Operation
    {
        public static String AUTHORIZE = "Authorize";
        public static String SALE = "Sale";
    }

    public static class SubscriptionCancelCodes
    {
        public static String BANK_DENIAL = "1000";
        public static String REFUNDED = "1001";
        public static String RETRIEVAL = "1002";
        public static String BANK_LETTER = "1003";
        public static String CHARGEBACK = "1004";
        public static String COMPANY_ACCOUNT_CLOSED = "1005";
        public static String WEBSITE_ACCOUNT_CLOSED = "1006";
        public static String DID_NOT_LIKE = "1007";
        public static String DISAGREE = "1008";
        public static String WEBMASTER_FRAUD = "1009";

        public static String COULD_NOT_GET_INTO = "1010";
        public static String NO_PROBLEM = "1011";
        public static String NOT_UPDATED = "1012";
        public static String TECH_PROBLEM = "1013";
        public static String TOO_SLOW = "1014";
        public static String DID_NOT_WORK = "1015";
        public static String TOO_EXPENSIVE = "1016";
        public static String UNAUTH_FAMILY = "1017";
        public static String UNDETERMINED = "1018";
        public static String WEBMASTER_REQUESTED = "1019";
        public static String NOTHING_RECEIVED = "1020";

        public static String DAMAGED = "1021";
        public static String EMPTY_BOX = "1022";
        public static String INCOMPLETE_ORDER = "1023";
        public static String UNKNOWN_REASON = "1099";
    }
}
