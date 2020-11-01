using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vocabulary.Models
{
    public class WordContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public WordContext(DbContextOptions<WordContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
