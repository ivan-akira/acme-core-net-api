using Acme.Entities.Part_E_Fake;
using System.Collections.Generic;

namespace Acme.API.Interface.Part_E_Fake
{
    public interface INotificationProxy
    {
        void AddEmailToQueue(SendEmailRequestEntity sendEmailRequestEntity);

        List<EmailResponseEntity> GetAllEmails();
    }
}
