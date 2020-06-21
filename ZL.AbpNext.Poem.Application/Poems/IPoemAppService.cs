using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public interface IPoemAppService:IApplicationService
    {
        /// <summary>
        /// 获取诗人分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PagedResultDto<PoetDto> GetPagedPoets(PagedResultRequestDto dto);

        PoetDto AddPoet(PoetDto poet);
    }
}
