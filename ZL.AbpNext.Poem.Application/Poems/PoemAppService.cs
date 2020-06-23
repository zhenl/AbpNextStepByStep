using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using ZL.AbpNext.Poem.Core.Poems;
using ZL.AbpNext.Poem.Core.Repositories;

namespace ZL.AbpNext.Poem.Application.Poems
{
    public class PoemAppService : ApplicationService, IPoemAppService
    {
        private readonly IPoemRepository _poemRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Poet> _poetRepository;
        private readonly ICategoryPoemRepository _categoryPoemRepository;
        public PoemAppService(IPoemRepository poemRepository
            , IRepository<Category> categoryRepository
            , IRepository<Poet> poetRepository
            , ICategoryPoemRepository categoryPoemRepository)
        {
            _poemRepository = poemRepository;
            _categoryRepository = categoryRepository;
            _poetRepository = poetRepository;
            _categoryPoemRepository = categoryPoemRepository;
        }

        public CategoryDto AddCategory(CategoryDto category)
        {
            var cate = _categoryRepository.FirstOrDefault(o => o.CategoryName == category.CategoryName);

            if (cate == null)
            {
                cate= _categoryRepository.InsertAsync(new Category { CategoryName = category.CategoryName },true).Result;
            }
            return ObjectMapper.Map<Category,CategoryDto>(cate); 
            
        }

        public void AddPoemToCategory(CategoryPoemDto categoryPoem)
        {
            var categorypoem = _categoryPoemRepository.FirstOrDefault(o => o.CategoryId == categoryPoem.CategoryId && o.PoemId == categoryPoem.PoemId);
            if (categorypoem == null)
            {
                categorypoem = new CategoryPoem { CategoryId = categoryPoem.CategoryId, PoemId = categoryPoem.PoemId };
                _categoryPoemRepository.InsertAsync(categorypoem,true);
            }
        }

        public PoetDto AddPoet(PoetDto poet)
        {
            var addpoet=_poetRepository.InsertAsync(new Poet
            {
                 Name=poet.Name,
                 Description=poet.Description
            },true).Result;
            return new PoetDto
            {
                Id=addpoet.Id,
                Name=addpoet.Name,
                Description=addpoet.Description
            };
        }

        public void DeleteCategory(CategoryDto category)
        {
            if (category.Id > 0)
            {
                var cat = _categoryRepository.FirstOrDefault(o => o.Id == category.Id);
                if (cat != null)
                {
                    _categoryRepository.DeleteAsync(cat, true);
                }
            }
            else if (!string.IsNullOrEmpty(category.CategoryName))
            {
                var cat = _categoryRepository.FirstOrDefault(o => o.CategoryName == category.CategoryName);
                if (cat != null)
                {
                    _categoryRepository.DeleteAsync(cat,true);
                }
            }
        }

        public List<CategoryDto> GetAllCategories()
        {
            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(_categoryRepository.ToList());
        }

        public List<CategoryPoemDto> GetCategoryPoems()
        {
            return ObjectMapper.Map<List<CategoryPoem>, List<CategoryPoemDto>>(_categoryPoemRepository.ToList());
        }

        public PagedResultDto<PoemDto> GetPagedPoems(PagedResultRequestDto dto)
        {
            var count = _poemRepository.Count();
            var lst = _poemRepository.OrderBy(o => o.Id).PageBy(dto).ToList();

            return new PagedResultDto<PoemDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<Core.Poems.Poem>, List<PoemDto>>(lst) //lst.MapTo<List<PoemDto>>()
            };
        }

        public PagedResultDto<PoetDto> GetPagedPoets(PagedResultRequestDto dto)
        {
                var count = _poetRepository.Count();
                var lst = _poetRepository.OrderBy(o => o.Id).PageBy(dto).ToList();
                var items = new List<PoetDto>();
                
                return new PagedResultDto<PoetDto>
                {
                    TotalCount = count,
                    Items = ObjectMapper.Map<List<Poet>, List<PoetDto>>(lst)
                };
        }

        public List<CategoryDto> GetPoemCategories(int poemid)
        {
            var lst = _categoryPoemRepository.GetPoemCategories(poemid);
            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(lst);
        }

        public List<PoemDto> GetPoemsOfCategory(int categoryid)
        {
            var lst = _categoryPoemRepository.GetPoemsOfCategory(categoryid);
            return ObjectMapper.Map<List<Core.Poems.Poem>, List<PoemDto>>(lst);
        }

        public void RemovePoemFromCategory(CategoryPoemDto categoryPoem)
        {
            var categorypoem = _categoryPoemRepository.FirstOrDefault(o => o.CategoryId == categoryPoem.CategoryId && o.PoemId == categoryPoem.PoemId);
            if (categorypoem != null)
            {
                _categoryPoemRepository.DeleteAsync(categorypoem,true);
            }
        }

        public PagedResultDto<PoemDto> SearchPoems(SearchPoemDto dto)
        {
           
            int total;
            var lst = _poemRepository.GetPagedPoems(dto.MaxResultCount, dto.SkipCount, dto.AuthorName, dto.Keyword,dto.Categories, out total).Result;
            return new PagedResultDto<PoemDto> {
                TotalCount = total,
                Items=ObjectMapper.Map<List<Core.Poems.Poem>, List<PoemDto>>(lst)
        };
        }

        public PagedResultDto<PoetDto> SearchPoets(SearchPoetDto dto)
        {
            var res = _poetRepository.AsQueryable();
            if (!string.IsNullOrEmpty(dto.Keyword))
            {
                res = res.Where(o => o.Name.Contains(dto.Keyword));
            }
            var count = res.Count();
            var lst = res.OrderBy(o => o.Id).PageBy(dto).ToList();

            return new PagedResultDto<PoetDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map< List < Poet> ,List <PoetDto>>(lst)
            };
        }
    }
}
