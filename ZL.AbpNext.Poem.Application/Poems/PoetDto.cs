using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using ZL.AbpNext.Poem.Core.Poems;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class PoetDto:EntityDto<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
