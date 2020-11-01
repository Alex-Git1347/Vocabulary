using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vocabulary.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string EnglWord { get; set; }
        public string RussWord { get; set; }
        public string AddRuss { get; set; }
    }
}
