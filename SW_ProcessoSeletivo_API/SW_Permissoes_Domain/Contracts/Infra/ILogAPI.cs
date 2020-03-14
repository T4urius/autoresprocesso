using System;
using System.Collections.Generic;
using System.Text;

namespace SW_Permissoes_Domain.Contracts.Infra
{
    public interface ILogAPI
    {
        string BodyContent { get; set; }
        void Error(string msg);
        void Warnning(string msg);
        void Info(string msg);
        void Debug(string msg);
    }
}
