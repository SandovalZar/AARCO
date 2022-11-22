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
    public class MarcasController : ControllerBase
    {
        private readonly AutoContext _context;

        public MarcasController(AutoContext context)
        {
            _context = context;
        }

        // GET: api/Marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarca()
        {
           
            return await _context.Marca.ToListAsync();
            
        }



        // GET: api/Marcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _context.Marca.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }
    }
}
