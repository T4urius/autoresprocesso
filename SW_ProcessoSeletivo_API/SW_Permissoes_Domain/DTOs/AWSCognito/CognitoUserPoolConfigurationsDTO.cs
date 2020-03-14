using System;
using System.Collections.Generic;
using System.Text;

namespace SW_Permissoes_Domain.DTOs.AWSCognito
{
    public class CognitoUserPoolConfigurationsDTO
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string PoolId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecretKey { get; set; }
        public string Region { get; set; }
    }
}
