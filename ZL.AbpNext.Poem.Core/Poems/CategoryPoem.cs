using Volo.Abp.Domain.Entities;

namespace ZL.AbpNext.Poem.Core.Poems
{
    public class CategoryPoem : Entity<int>
    {
        public virtual int CategoryId { get; set; }

        public virtual int PoemId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Poem Poem { get; set; }
    }
}
