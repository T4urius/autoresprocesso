using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SW.ProcessoSeletivo.Domain.Contracts.Repositories;
using SW.ProcessoSeletivo.Domain.DTOs;
using SW.ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SW.ProcessoSeletivo.Controllers
{
    [Route("api/v1/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public AutoresController(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IActionResult> ObterAutores()
        //{
        //    var response = await _autorRepository.ObterAutores();
        //    return Ok(response);
        //}

        [HttpGet]
        public async Task<IActionResult> FormatarAutores()
        {
            var response = await _autorRepository.ObterAutores();

            var nomeAutores = new List<string>();

            foreach (var nome in response)
            {
                var result = nome.Nome.Split(" ");

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

        [HttpPost("inserirAutor")]
        public async Task<IActionResult> InserirAutor([FromBody] AutoresRequest request)
        {
            var data = _mapper.Map<Autores>(request);
            var response = await _autorRepository.InserirAutor(data);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAutor([FromQuery] int idAutor)
        {
            var response = _autorRepository.DeleteAutor(idAutor);

            return Ok(response);
        }
    }
}
