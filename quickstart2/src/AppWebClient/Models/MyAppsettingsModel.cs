using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebClient.Models
{
    public class MyAppsettingsModel
    {
/*
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

*/
        public string SecretKey { get; set; }
        public string PublisheableKey { get; set; }



    }
}
