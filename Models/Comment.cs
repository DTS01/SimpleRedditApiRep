using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleRedditApi.Models
{
    public class Comment
    {
        public int Id { get; set; } // Primær nøgle

        [Required]
        public string Text { get; set; } // Kommentarens tekst

        [Required]
        public string Author { get; set; } // Forfatterens navn

        public DateTime CreationDate { get; set; } = DateTime.UtcNow; // Oprettelsesdato

        public int Votes { get; set; } = 0; // Antal stemmer

        // Fremmednøgle til Thread
        public int ThreadId { get; set; }

        // Navigation property for at relatere til Thread
        public Thread Thread { get; set; }
    }
}

