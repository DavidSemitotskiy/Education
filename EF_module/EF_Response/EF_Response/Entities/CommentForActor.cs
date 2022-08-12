using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Response.Entities
{
    public class CommentForActor : Comment
    {
        [ForeignKey(nameof(Actor))]
        public int ActorId { get; set; }

        public Actor CurrentActor { get; set; }
    }
}
