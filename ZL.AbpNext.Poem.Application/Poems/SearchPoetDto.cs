using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class SearchPoetDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
