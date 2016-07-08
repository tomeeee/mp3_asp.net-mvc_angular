using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace mp3.Models
{
    [Table("Playlist")]
    public class Playlist
    {
        public Playlist()
        {
            Mp3s = new HashSet<Mp3>();
        }
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        public virtual  ICollection<Mp3> Mp3s { get; set; }
    }
}