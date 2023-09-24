#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvokeWebAPIEF.Data;
using InvokeWebAPIEF.Model;

namespace InvokeWebAPIEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoesController : ControllerBase
    {
        private readonly InvokeWebAPIEFContext _context;

        public CryptoesController(InvokeWebAPIEFContext context)
        {
            _context = context;
        }

        // GET: api/Cryptoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crypto>>> GetCrypto()
        {
            return await _context.Crypto.ToListAsync();
        }

        // GET: api/Cryptoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crypto>> GetCrypto(int id)
        {
            var crypto = await _context.Crypto.FindAsync(id);

            if (crypto == null)
            {
                return NotFound();
            }

            return crypto;
        }

        // PUT: api/Cryptoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrypto(int id, Crypto crypto)
        {
            if (id != crypto.Id)
            {
                return BadRequest();
            }

            _context.Entry(crypto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CryptoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cryptoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Crypto>> PostCrypto(Crypto crypto)
        {
            _context.Crypto.Add(crypto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCrypto", new { id = crypto.Id }, crypto);
        }

        // DELETE: api/Cryptoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrypto(int id)
        {
            var crypto = await _context.Crypto.FindAsync(id);
            if (crypto == null)
            {
                return NotFound();
            }

            _context.Crypto.Remove(crypto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CryptoExists(int id)
        {
            return _context.Crypto.Any(e => e.Id == id);
        }
    }
}
