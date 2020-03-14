using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.ProcessoSeletivo.Controllers
{
    [Route("api/v1/autores")]
    public class AutoresController : ControllerBase
    {
        public AutoresController()
        {

        }

        [HttpPost]
        public IActionResult FormatarAutores([FromBody] List<string> autores)
        {
            var nomeAutores = new List<string>();

            foreach (var nome in autores)
            {
                var result = nome.ToString().Split(" ");

                for (var j = 0; j < result.Length; j++)
                {
                    List<string> list = result.ToList();
                    list.RemoveAll(e => e.StartsWith("da"));
                    list.RemoveAll(e => e.StartsWith("do"));
                    list.RemoveAll(e => e.StartsWith("dos"));
                    list.RemoveAll(e => e.StartsWith("das"));
                    list.RemoveAll(e => e.StartsWith("de"));

                    var last = list[0];

                    if (list.Count > 2)
                    {
                        last = list[0];
                        for (var i = 1; i < list.Count; i++)
                        {
                            if (i + 1 != 3)
                            {
                                var first = new List<string>
                        {
                            list[i] + " " + list[i+1]
                        };
                                nomeAutores.Add(first.FirstOrDefault().ToUpper() + ", " + char.ToUpper(last[0]) + last.Substring(1));
                            }
                        };
                    }
                    if (list.Count == 1)
                    {
                        nomeAutores.Add(list.FirstOrDefault() + " <- Não formatado");
                    }
                    else
                    {
                        var first = list[1];
                        if (!nomeAutores.Any(x => x.Any(y => y.Equals(first.FirstOrDefault()))))
                        {
                            nomeAutores.Add(first.ToUpper() + ", " + char.ToUpper(last[0]) + last.Substring(1));
                        }
                    }
                }
            }
            return Ok(nomeAutores);
        }
    }
}
