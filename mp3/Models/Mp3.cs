using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Newtonsoft.Json;
namespace mp3.Models
{
    [Table("Mp3")]
    public class Mp3
    {
        public Mp3()
        {
            Playlists = new HashSet<Playlist>();
        }
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Artist { get; set; }
        [StringLength(100)]
        public string Album { get; set; }

        public short Year { get; set; }
        [JsonIgnore]
        public virtual ICollection<Playlist> Playlists {get; set; }
    }
}