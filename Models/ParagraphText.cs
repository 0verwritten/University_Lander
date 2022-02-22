using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Lander.Models
{
    public interface IParagraph{
        string Name { get; set; }
    }
    public class ParagraphText : IParagraph
    {
        public string Name { get; set; }
        public string? Value { get; set; }
    }

    public class ParagraphContent : IParagraph{
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
}