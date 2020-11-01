using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vocabulary.Models;

namespace Vocabulary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private WordContext db;

        public WordController(WordContext context)
        {
            db = context;
            if (!db.Words.Any())
            {
                db.Words.Add(new Word { RussWord = "карта", EnglWord = "map" });
                db.Words.Add(new Word { RussWord = "компьютер", EnglWord = "computer", AddRuss = "ЭВМ" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> Get()
        {
            var list = await db.Words.ToListAsync();
            return list;
        }

        [HttpGet("{newWord}")]
        public async Task<ActionResult<Word>> Get(string newWord)
        {
            Word word = await db.Words.FirstOrDefaultAsync(x => x.EnglWord == newWord);
            if (word == null)
            {
                word = await db.Words.FirstOrDefaultAsync(x => x.RussWord == newWord);
            }
            if (word == null)
                return NotFound();
            return new ObjectResult(word);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Word>> Get(int id)
        //{
        //    Word word = await db.Words.FirstOrDefaultAsync(x => x.Id == id);
        //    if (word == null)
        //        return NotFound();
        //    return new ObjectResult(word);
        //}

        [HttpPost]
        public async Task<ActionResult<Word>> Post(Word word)
        {
            if (word == null)
            {
                return BadRequest();
            }
            db.Words.Add(word);
            await db.SaveChangesAsync();
            return Ok(word);
        }


        [HttpPut]
        public async Task<ActionResult<Word>> Put(Word word)
        {
            if (word == null)
            {
                return BadRequest();
            }
            if (!db.Words.Any(x => x.Id == word.Id))
            {
                return NotFound();
            }

            db.Update(word);
            await db.SaveChangesAsync();
            return Ok(word);
        }

    }

}
