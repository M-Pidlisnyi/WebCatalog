using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebCatalog.Services;

namespace WebCatalog.Pages
{
    public class PersonnelModel : IndexModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public PersonnelModel(ILogger<IndexModel> logger, JsonFilePeopleService peopleService) : base(logger, peopleService)
        {
            _logger = logger;
        }

    }
}
