using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class PoemAppService : ApplicationService, IPoemAppService
    {
        private readonly IRepository<Poet> _poetRepository;
        public PoemAppService(IRepository<Poet> poetRepository)
        {
            _poetRepository = poetRepository;
        }
        public PagedResultDto<PoetDto> GetPagedPoets(PagedResultRequestDto dto)
        {
           using (var uow = UnitOfWorkManager.Begin(new AbpUnitOfWorkOptions()))
            {
                var count = _poetRepository.Count();
                var lst = _poetRepository.OrderBy(o => o.Id).PageBy(dto).ToList();
                var items = new List<PoetDto>();
                
                return new PagedResultDto<PoetDto>
                {
                    TotalCount = count,
                    Items = ObjectMapper.Map<List<Poet>, List<PoetDto>>(lst)
                };
            }
            
        }
    }
}
