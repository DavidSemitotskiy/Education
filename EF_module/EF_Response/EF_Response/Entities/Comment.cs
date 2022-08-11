using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Response.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Reaction Emotion { get; set; }

        public byte Grade { get; set; }
    }
}
