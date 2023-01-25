using PaymentContext.Domain.ValuesObjects;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student(Name name, Email email, Document document)
        {
            Name = name;
            Email = email;
            Document = document;

            AddNotifications(name, document, email);
        }

        public Name Name {get; private set;}
        public string LastName {get; private set;}
        public Email Email {get; private set;}
        public Document Document {get; private set;}
        public Address Address { get; private set; }
        private List<Subscription> Subscriptions {get; set;}

        public void AddSubscription(Subscription subscription)
        {
            foreach(var sub in Subscriptions)
            {
                sub.Deactivate();
            }

            Subscriptions.Add(subscription);
        }
    }
}