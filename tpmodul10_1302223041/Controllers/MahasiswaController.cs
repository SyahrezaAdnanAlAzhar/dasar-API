using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace tpmodul10_1302223041.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static readonly List<Mahasiswa> anggotaKelompok = new List<Mahasiswa>
        {
            new Mahasiswa("Syahreza Adnan Al Azhar", "1302223041"),
            new Mahasiswa("Nicholas Xavier Robinson Silalahi", "1302220078"),
            new Mahasiswa("Syauqi Dhiya Ulhaq", "1302220112"),
            new Mahasiswa("Ahmad Fadli Akbar", "1302220126"),
            new Mahasiswa("Ricky Renaldi", "1302223051"),
            new Mahasiswa("Benedict Arvin Indra Puteprasa", "1302223136")
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(anggotaKelompok);
        }

        [HttpPost]
        public IActionResult Create(Mahasiswa mahasiswa)
        {
            anggotaKelompok.Append(mahasiswa);
            return CreatedAtAction(nameof(GetById), new { id = anggotaKelompok.IndexOf(mahasiswa) }, mahasiswa);
        }

        [HttpPost("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= anggotaKelompok.Count)
            {
                return NotFound();
            }
            return Ok(anggotaKelompok[id]);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= anggotaKelompok.Count)
            {
                return NotFound();
            }
            anggotaKelompok.RemoveAt(id);
            return NoContent();
        }
    }
}
