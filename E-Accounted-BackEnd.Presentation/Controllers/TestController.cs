using E_Accounted_BackEnd.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public sealed class TestController: ApiController
    {
        [HttpGet]  
        public IActionResult Get()
        {
            return Ok("İşlem Başarılı");
        }
    }
}
