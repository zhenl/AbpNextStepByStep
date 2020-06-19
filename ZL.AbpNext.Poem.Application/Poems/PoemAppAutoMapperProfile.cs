using AutoMapper;
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
