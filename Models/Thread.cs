using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleRedditApi.Models
{
    public class Thread
    {
        public int Id { get; set; } // Primær nøgle

        [Required]
        public string Title { get; set; } // Trådens titel

        public string Content { get; set; } // Kan være tekst eller en URL

        [Required]
        public string Author { get; set; } // Forfatterens navn

        public DateTime CreationDate { get; set; } = DateTime.UtcNow; // Oprettelsesdato

        public int Votes { get; set; } = 0; // Antal stemmer

        // Navigation property for kommentarer
        public List<Comment> Comments { get; set; }
    }
}
