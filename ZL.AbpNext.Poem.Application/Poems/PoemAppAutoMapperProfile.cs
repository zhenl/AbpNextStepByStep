using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class PoemAppAutoMapperProfile : Profile
    {
        public PoemAppAutoMapperProfile()
        {
            CreateMap<Poet, PoetDto>();
        }
    }
}
