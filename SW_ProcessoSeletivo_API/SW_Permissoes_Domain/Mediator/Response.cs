using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SW_Permissoes_Domain.Mediator
{
    public class Response
    {
        private readonly IList<string> _messages = new List<string>();

        public Response()
        {
            Errors = new ReadOnlyCollection<string>(_messages);
        }

        public Response(dynamic result) : this()
        {
            Result = result;
        }

        public IEnumerable<string> Errors { get; set; }

        public dynamic Result { get; }

        public Response AddError(string msg)
        {
            _messages.Add(msg);
            return this;
        }
    }
}
