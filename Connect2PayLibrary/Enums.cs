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
}
