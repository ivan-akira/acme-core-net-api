using System;

namespace Acme.Entities.Part_E_Fake
{
    public class EmailResponseEntity
    {
        public Guid EmailId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
