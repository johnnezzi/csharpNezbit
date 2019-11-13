using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            Blockchain bc = new Blockchain();
            bc.addBlock("hello");
            return JsonConvert.SerializeObject(bc.chain);
        }
    }
}