namespace mp3.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Mp3Dbcontext : DbContext
    {
        public Mp3Dbcontext()
            : base("name=Mp3Db")
        {
        }

        public virtual DbSet<Mp3> Mp3 { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        //trebat ce izminit bazu da moze 1 mp3 vise puta u istu playlistu. redosljed pjesmi?
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.Mp3s)
                .WithMany(e => e.Playlists)
                .Map(m => m.ToTable("PlaylistMp3").MapLeftKey("IdPlaylist").MapRightKey("IdMp3"));

        }
    }


}