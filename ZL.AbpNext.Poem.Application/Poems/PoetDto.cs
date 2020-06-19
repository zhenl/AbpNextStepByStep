using Volo.Abp.Application.Dtos;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class PoetDto:EntityDto<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
