using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class MapStudent : PageModel
    {
        private readonly ILogger<MapStudent> _logger;

        public MapStudent(ILogger<MapStudent> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}