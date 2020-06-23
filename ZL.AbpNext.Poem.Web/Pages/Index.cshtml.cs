using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ZL.AbpNext.Poem.Application.Poems;

namespace ZL.AbpNext.Poem.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IPoemAppService service;

        public List<CategoryDto> categories;

        public IndexModel(ILogger<IndexModel> logger, IPoemAppService service)
        {
            _logger = logger;
            this.service = service;
        }

        public void OnGet()
        {
            categories=service.GetAllCategories();
        }
    }
}
