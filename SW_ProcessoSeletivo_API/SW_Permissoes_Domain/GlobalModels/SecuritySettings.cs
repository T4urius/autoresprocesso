using System;
using System.Collections.Generic;
using System.Text;

namespace SW_Permissoes_Domain.GlobalModels
{
    public class SecuritySettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
        public int PerfilAdminId { get; set; }
    }
}
