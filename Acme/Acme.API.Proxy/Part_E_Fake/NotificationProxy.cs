using Acme.API.Interface.Part_E_Fake;
using Acme.Entities.Part_E_Fake;
using System.Collections.Generic;

namespace Acme.API.Proxy.Part_E_Fake
{
    public class NotificationProxy : INotificationProxy
    {
        public void AddEmailToQueue(SendEmailRequestEntity sendEmailRequestEntity)
        {
            // this is an implementation of API to queue email to be sent later
            // ...
            // ...
            // ...
            // this is an implementation of API to queue email to be sent later
        }

        public List<EmailResponseEntity> GetAllEmails()
        {
            // this is an implementation of API to get all emails in queue
            // ...
            // ...
            // ...
            // this is an implementation of API to get all emails in queue
            return null;
        }
    }
}
