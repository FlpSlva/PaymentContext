using PaymentContext.Domain.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        public Payment(DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string address,
            Document document,
            string payer,
            string email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Document = document;
            Payer = payer;
            Email = email;

        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate  { get;  private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Address { get; private set; }
        public Document Document { get; private set; }
        public string Payer { get; private set; }
        public string Email { get; private set; }

    }


}