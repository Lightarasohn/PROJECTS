using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Designing_API_To_Ready_To_Go_Database.Controllers
{
    [Route("musteri")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private readonly IMusteriRepository _musteriRepo;
        public MusteriController(IMusteriRepository musteriRepo)
        {
            _musteriRepo = musteriRepo;
        }   
    }
}