﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.Models
{
    public class ResetPwdViewModel
    {
        public string UserId { get; set; }
        public string code { get; set; }
        public string newPwd { get; set; }
    }
}
