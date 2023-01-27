using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName= "Bruce";
            command.LastName= "Wayne";
            command.Document = "99999999999";
            command.Email = "Bruce2.dc@gmail.com";
            command.BarCode = "12345678";
            command.BoletoNumber = "123456";
            command.PaymentNumber = "123534523";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayne Corp";
            command.PayerDocument = "123456788910";
            command.PayerDocumentType = Domain.Enums.EDocumentType.CPF;
            command.PAyerEmail = "batman@dc.com";
            command.Street = "12";
            command.Number = "as";
            command.Neighborhood = "as";
            command.City = "as";
            command.State = "as";
            command.Country = "as";
            command.ZipCode = "12345";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}
