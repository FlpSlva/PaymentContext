using Flunt.Validations;
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
        private IList<Subscription> _subscriptions;
        public Student(Name name, Email email, Document document)
        {
            Name = name;
            Email = email;
            Document = document;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
             .Requires()
               .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Voc? j? tem uma sinatura ativa")
               .IsGreaterThan(0, subscription.Payments.Count, "Student.Subscription", "Esta assinatura n?o possui pagamentos")
                );

            //if (hasSubscriptionActive)
            //    AddNotification("Student.Subscription", "Voc? j? tem uma assinatura ativa");

        }
    }
}