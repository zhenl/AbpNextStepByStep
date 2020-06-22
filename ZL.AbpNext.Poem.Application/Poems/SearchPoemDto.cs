using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class SearchPoemDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

        public string AuthorName { get; set; }

    }
}
