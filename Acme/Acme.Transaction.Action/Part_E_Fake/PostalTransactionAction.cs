using Acme.API.Interface.Part_E_Fake;
using Acme.Entities.Part_E_Fake;
using System;

namespace Acme.Transaction.Action.Part_E_Fake
{
    public class PostalTransactionAction
    {
        private readonly INotificationProxy notificationProxy;
        private readonly int totalEmail;

        public PostalTransactionAction(INotificationProxy notificationProxy)
        {
            this.notificationProxy = notificationProxy;
            totalEmail = (new Random()).Next(10, 21);
        }

        public void PrepareEmail()
        {
            for (int i = 0; i < totalEmail; i++)
            {
                var sendEmailRequestEntity = new SendEmailRequestEntity()
                {
                    From = "no-reply@email.com",
                    To = "to@email.com",
                    Subject = "Important Email",
                    Body = "Content of email."
                };

                notificationProxy.AddEmailToQueue(sendEmailRequestEntity);
            }
        }

        public bool IsEmailPrepared()
        {
            return notificationProxy.GetAllEmails().Count == totalEmail;
        }
    }
}
