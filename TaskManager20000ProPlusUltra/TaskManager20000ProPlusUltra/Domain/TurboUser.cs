using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager20000ProPlusUltra.Domain
{
    public abstract class TurboUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}