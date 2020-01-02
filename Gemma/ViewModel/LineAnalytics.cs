using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class PaymentUrl
    {
        public string web { get; set; }
        public string app { get; set; }
    }

    public class Info
    {
        public long transactionId { get; set; }
        public PaymentUrl paymentUrl { get; set; }
        public string paymentAccessToken { get; set; }
    }

    public class LineRootObject
    {
        public string returnCode { get; set; }
        public string returnMessage { get; set; }
        public Info info { get; set; }
    }
}