using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class ReviewStudent : PageModel
    {
        private readonly ILogger<ReviewStudent> _logger;

        public ReviewStudent(ILogger<ReviewStudent> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}