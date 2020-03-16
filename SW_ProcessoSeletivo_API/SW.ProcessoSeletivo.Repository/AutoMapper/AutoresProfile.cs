using AutoMapper;
using SW.ProcessoSeletivo.Domain.DTOs;
using SW.ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.ProcessoSeletivo.Repository.AutoMapper
{
    public class AutoresProfile : Profile
    {
        public AutoresProfile()
        {
            CreateMap<AutoresRequest, Autores>()
                .ForMember(c => c.Id, d => d.MapFrom(e => e.IdAutor))
                .ForMember(c => c.Nome, d => d.MapFrom(e => e.NomeAutor)).ReverseMap();
        }
    }
}
