using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Automoviles.Models.Context;
using Automoviles.Models.Entities;

namespace Automoviles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmarcasController : ControllerBase
    {
        private readonly AutoContext _context;

        public SubmarcasController(AutoContext context)
        {
            _context = context;
        }

        // GET: api/Submarcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submarca>>> GetSubmarca()
        {
            return await _context.Submarca.ToListAsync();
        }

        // GET: api/Submarcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Submarca>>> GetSubmarca(int id)
        {
            var list = await _context.Submarca.ToListAsync();

            //await _context.Submarca.ToListAsync();

            var resultado = list.Where(x => x.IdMarca == id).ToList();

            return resultado;
        }

        private bool SubmarcaExists(int id)
        {
            return _context.Submarca.Any(e => e.Id == id);
        }
    }
}
