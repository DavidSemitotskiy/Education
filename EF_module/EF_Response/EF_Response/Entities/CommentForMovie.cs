﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Response.Entities
{
    public class CommentForMovie : Comment
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        public Movie Film { get; set; }
    }
}
