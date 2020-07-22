using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMatcherProject1.ViewModels
{
    public class UploadFileViewModel
    {
        public IFormFile Photo { get; set; }
        public Service Service { get; set; }
    }
}
