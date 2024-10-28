using System;

namespace CrazyMusicians.Models
{
    public class Musician
    {
        public int Id { get; set; }           // Unique ID for the musician
        public string Name { get; set; }      // Name of the musician
        public string Genre { get; set; }     // Genre of music
        public int DebutYear { get; set; }    // Year of debut
    }
}
