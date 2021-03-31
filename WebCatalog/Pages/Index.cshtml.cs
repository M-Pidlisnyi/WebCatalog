using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCatalog.Models;
using WebCatalog.Services;

namespace WebCatalog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFilePeopleService PeopleService;
        public IEnumerable<Person> People { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFilePeopleService peopleService)
        {
            _logger = logger;
            PeopleService = peopleService;
        }

        public virtual void OnGet()
        {
            People = PeopleService.GetPeople();
        }
    }
}
