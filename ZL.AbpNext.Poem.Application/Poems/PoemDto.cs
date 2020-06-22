using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class PoemDto : EntityDto<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int PoetID { get; set; }

        public string AuthorName { get; set; }

        public string Comments { get; set; }

        public string Volumn { get; set; }

        public string Num { get; set; }
    }
}
