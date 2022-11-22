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
    public class ModeloesController : ControllerBase
    {
        List<Modelo> _listaMod = new List<Modelo>();
        private readonly AutoContext _context;

        public ModeloesController(AutoContext context)
        {
            _context = context;
        }

        // GET: api/Modeloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelo()
        {
            return await _context.Modelo.ToListAsync();
        }
        // GET: api/Modeloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Modelo>>> GetModelo(int id)
        {
            var listSubMod = await _context.SubModDes.ToListAsync();
            var listDesc = await _context.Descripcion.ToListAsync();
            var listSubmarca = await _context.Submarca.ToListAsync();
            var listMod = await _context.Modelo.ToListAsync();

            IEnumerable<Modelo> resulMod = (from submar in listSubmarca
                                            join submod in listSubMod on submar.Id equals submod.IdSubm
                                            join mod in listMod on submod.IdMod equals mod.Id
                                            where submar.Id == id
                                            select new Modelo()
                                            {
                                                Id = mod.Id,
                                                Anio = mod.Anio
                                            }).ToList();
            resulMod = resulMod.DistinctBy(x => x.Anio);
            return resulMod.ToList();
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelo.Any(e => e.Id == id);
        }
    }

    public static class Repetidos
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
