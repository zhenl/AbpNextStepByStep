using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class CategoryDto : EntityDto<int>
    {
        public string CategoryName { get; set; }
    }
}
