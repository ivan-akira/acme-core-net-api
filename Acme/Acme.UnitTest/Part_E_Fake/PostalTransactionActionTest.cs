using Acme.API.Interface.Part_E_Fake;
using Acme.Entities.Part_E_Fake;
using Acme.Transaction.Action.Part_E_Fake;
using System;
using System.Collections.Generic;
using Xunit;

namespace Acme.UnitTest.Part_E_Fake
{
    public class PostalTransactionActionTest
    {
        private PostalTransactionAction postalTransactionAction;

        [Fact]
        public void IsEmailPrepared_PrepareEmailBeforehand_ReturnTrue()
        {
            // arrange
            var notificationApiClient = new NotificationProxyFake();
            postalTransactionAction = new PostalTransactionAction(notificationApiClient);

            postalTransactionAction.PrepareEmail();

            // act
            var result = postalTransactionAction.IsEmailPrepared();

            // assert
            Assert.True(result);
        }

        private class NotificationProxyFake : INotificationProxy // <- this is fake
        {
            private readonly List<EmailResponseEntity> emails;

            public NotificationProxyFake()
            {
                emails = new List<EmailResponseEntity>();
            }

            public void AddEmailToQueue(SendEmailRequestEntity sendEmailRequestEntity)
            {
                emails.Add(new EmailResponseEntity()
                {
                    EmailId = Guid.NewGuid(),
                    From = sendEmailRequestEntity.From,
                    To = sendEmailRequestEntity.To,
                    Subject = sendEmailRequestEntity.Subject,
                    Body = sendEmailRequestEntity.Body
                });
            }

            public List<EmailResponseEntity> GetAllEmails()
            {
                return emails;
            }
        }
    }
}
