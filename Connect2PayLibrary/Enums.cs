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
        public static Int32 BANK_DENIAL = 1000;
        public static Int32 REFUNDED = 1001;
        public static Int32 RETRIEVAL = 1002;
        public static Int32 BANK_LETTER = 1003;
        public static Int32 CHARGEBACK = 1004;
        public static Int32 COMPANY_ACCOUNT_CLOSED = 1005;
        public static Int32 WEBSITE_ACCOUNT_CLOSED = 1006;
        public static Int32 DID_NOT_LIKE = 1007;
        public static Int32 DISAGREE = 1008;
        public static Int32 WEBMASTER_FRAUD = 1009;

        public static Int32 COULD_NOT_GET_INTO = 1010;
        public static Int32 NO_PROBLEM = 1011;
        public static Int32 NOT_UPDATED = 1012;
        public static Int32 TECH_PROBLEM = 1013;
        public static Int32 TOO_SLOW = 1014;
        public static Int32 DID_NOT_WORK = 1015;
        public static Int32 TOO_EXPENSIVE = 1016;
        public static Int32 UNAUTH_FAMILY = 1017;
        public static Int32 UNDETERMINED = 1018;
        public static Int32 WEBMASTER_REQUESTED = 1019;
        public static Int32 NOTHING_RECEIVED = 1020;

        public static Int32 DAMAGED = 1021;
        public static Int32 EMPTY_BOX = 1022;
        public static Int32 INCOMPLETE_ORDER = 1023;
        public static Int32 UNKNOWN_REASON = 1099;
    }

    public static class SubscriptionTypes
    {
        public static String NORMAL = "normal";
        public static String INFINITE = "infinite";
        public static String ONETIME = "onetime";
        public static String LIFETIME = "lifetime";
    }

    public static class WeChatDirectMode
    {
        public static String NATIVE = "native";
        public static String QUICK_PAY = "quickpay";
    }

    public static class AliPayDirectMode
    {
        public static String APP = "app";
        public static String POS = "pos";
    }

    public static class AliPayIdentityCodeType
    {
        public static String QRCODE = "qrcode";
        public static String BARCODE = "barcode";
    }
}
