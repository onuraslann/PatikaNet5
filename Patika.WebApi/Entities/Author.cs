﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patika.WebApi.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Date { get; set; }
    }
}
