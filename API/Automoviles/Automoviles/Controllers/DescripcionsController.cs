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
    public class DescripcionsController : ControllerBase
    {
        private readonly AutoContext _context;

        public DescripcionsController(AutoContext context)
        {
            _context = context;
        }

        // GET: api/Descripcions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Descripcion>>> GetDescripcion()
        {
            return await _context.Descripcion.ToListAsync();
        }

        // GET: api/Descripcions/5
        [HttpGet("{id}/{idMod}")]
        public async Task<ActionResult<IEnumerable<Descripcion>>> GetDescripcion(int id, int idmod)
        {
            var listSubMod = await _context.SubModDes.ToListAsync();
            var listDesc = await _context.Descripcion.ToListAsync();
            var listSubmarca = await _context.Submarca.ToListAsync();
            var listMod = await _context.Modelo.ToListAsync();

            var resulMod = (from submar in listSubmarca
                            join submod in listSubMod on submar.Id equals submod.IdSubm
                            join mod in listMod on submod.IdMod equals mod.Id
                            join des in listDesc on submod.IdDes equals des.Id
                            where submar.Id == id && mod.Id == idmod
                            select new Descripcion()
                            {
                                Id = des.Id,
                                Detalles = des.Detalles,
                                DescripcionId = des.DescripcionId,
                            }).ToList();

            return resulMod;
        }

        private bool DescripcionExists(int id)
        {
            return _context.Descripcion.Any(e => e.Id == id);
        }
    }
}
