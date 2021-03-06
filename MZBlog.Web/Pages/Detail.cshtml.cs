﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using MZBlog.Core.ViewProjections.Home;

namespace MZBlog.Web.Pages
{
    public class DetailModel : PageModel
    {

        private readonly IMediator _mediator;
        public DetailModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty(SupportsGet =true)]
        public int Year { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Month { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Slug { get; set; }

        public BlogPostDetailsViewModel Detail { get; set; }
        public void OnGet()
        {
            var query = new BlogPostDetailsQuery { Permalink = Slug };
            Detail =_mediator.Send(query).Result;
        }
    }
}