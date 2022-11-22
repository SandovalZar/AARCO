using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Automoviles.Models.Context;
using Automoviles.Models.Entities;
using Newtonsoft.Json;

namespace Automoviles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubModDesController : ControllerBase
    {
        private readonly AutoContext _context;

        public SubModDesController(AutoContext context)
        {
            _context = context;
        }
        // GET: api/SubModDes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubModDes>>> GetSubModDes()
        {            
            return await _context.SubModDes.ToListAsync();
        }

        // GET: api/SubModDes/5
        [HttpGet("Modelo/{id}")]
        public async Task<ActionResult<IEnumerable<SubModDes>>> GetSubMod(int id)
        {
            var listSubMod = await _context.SubModDes.ToListAsync();
            var listDesc = await _context.Descripcion.ToListAsync();
            var listSubmarca = await _context.Submarca.ToListAsync();
            var listMod = await _context.Modelo.ToListAsync();
            var resultadoSubMod = listSubMod.Where(x => x.IdSubm == id).ToList();

            var resulMod = (from submar in listSubmarca
                            join submod in listSubMod on submar.Id equals submod.IdSubm
                            join mod in listMod on submod.IdMod equals mod.Id
                            where submar.Id == id
                            select new SubModDes() {
                                Id = submod.Id,
                                IdSubm = submod.IdSubm,
                                IdMod = submod.IdMod,
                                IdDes = submod.IdDes
                            }).ToList();
            return resulMod;
        }

        [HttpGet("Descripcion/{id}")]
        public async Task<ActionResult<IEnumerable<SubModDes>>> GetSubDes(int id)
        {
            var list = await _context.SubModDes.ToListAsync();

            var resultado = list.Where(x => x.IdSubm == id).ToList();

            return resultado;
        }


        private bool SubModDesExists(int id)
        {
            return _context.SubModDes.Any(e => e.Id == id);
        }
    }
}
