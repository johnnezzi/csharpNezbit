using System;
using Microsoft.AspNetCore.Mvc;
using Nezbit.Classes;

namespace WebApplication.Controllers
{    
    [ApiController]
    [Route("/blocks")]
    public class BlockController : Controller
    {
        // GET
        [HttpGet]
        public String Index()
        {
            return "TestBlock";
        }
    }
}