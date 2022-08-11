using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Response.Entities
{
    public class Actor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BirthYear { get; set; }

        public string Gander { get; set; }

        public string Country { get; set; }
    }
}
