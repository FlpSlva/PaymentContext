using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private Student _student;
        private Subscription _subscription;
        private Email _email;
        private Address _address;
        private Document _document;
        public StudentTests()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("41852816848", Domain.Enums.EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            var _address = new Address("rua 1", "1234", "bairro legal", "gotham", "sp", "br", "13400123");
            _student = new Student(name, _email, document);
            _subscription = new Subscription(null);
            
        }


        [TestMethod]
        public void SholdReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PaypalPayment(_email, "12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "wayne corp");

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void SholdReturnErrorWhenSubscriptionHasNoPayment()
        {
            
            
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);

           
        }

        [TestMethod]
        public void SholdReturnSuccessWhenHadNoActiveSubscription()
        {
            var payment = new PaypalPayment(_email, "12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "wayne corp");
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }
    }
}
