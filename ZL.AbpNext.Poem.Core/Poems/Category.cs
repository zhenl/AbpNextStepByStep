using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace ZL.AbpNext.Poem.Core.Poems
{/// <summary>
 /// 诗的分类
 /// </summary>
    public class Category : Entity<int>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public virtual string CategoryName { get; set; }

        /// <summary>
        /// 该分类中包含的诗
        /// </summary>
        public virtual ICollection<CategoryPoem> CategoryPoems { get; set; }
    }
}
