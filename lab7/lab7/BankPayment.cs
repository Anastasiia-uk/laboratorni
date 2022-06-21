using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;


namespace lab7
{
    [Serializable]
    public class BankPayment
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public double Sum { get; set; }
        public string PruposeOfPayment { get; set; }
        public DateTime PaymentCreationDate { get; set; }

        public BankPayment() { }
        public BankPayment(string Sender, string Recipient, double Sum, string PruposeOfPayment)
        {
            this.Sender = Sender;
            this.Recipient = Recipient;
            this.Sum = Sum;
            this.PruposeOfPayment = PruposeOfPayment;
            PaymentCreationDate = DateTime.Now;
        }    
    }
}