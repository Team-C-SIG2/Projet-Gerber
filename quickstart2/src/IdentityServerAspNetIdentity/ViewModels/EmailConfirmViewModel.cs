using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.ViewModels
{
    public class EmailConfirmViewModel
    {
        public string UserId { get; set; }
        public string code { get; set; }
    }
}
