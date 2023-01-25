using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValuesObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(firstName))
                AddNotification("Name.FirstName", "Nome inválido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
