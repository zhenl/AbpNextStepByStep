using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class CategoryPoemDto : EntityDto<int>
    {
        public int CategoryId { get; set; }

        public int PoemId { get; set; }
    }
}
