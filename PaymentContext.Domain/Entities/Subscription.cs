using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        public Subscription( DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            
        }

        public DateTime CreateDate {get; private set;}
        public DateTime LastUpdateDate {get; private set;}
        public DateTime? ExpireDate {get; private set;}
        public bool Active { get; private set; }
        private List<Payment> Payments { get; set; }

        public void AddSubscription(Payment payment)
        {
            Payments.Add(payment);
        }

        public void Activate() 
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Deactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}