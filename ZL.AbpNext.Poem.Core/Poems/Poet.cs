using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace ZL.AbpNext.Poem.Core.Poems
{
    /// <summary>
    /// 诗人，从ABP Entity派生
    /// </summary>
    public class Poet : Entity<int>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public virtual string Description { get; set; }
        
    }
}
