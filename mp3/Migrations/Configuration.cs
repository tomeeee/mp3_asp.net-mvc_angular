namespace mp3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using mp3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<mp3.Models.Mp3Dbcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(mp3.Models.Mp3Dbcontext context)
        {           
        
            for (var i = 0; i < 100; i++)
            {
                context.Mp3.Add(new Mp3
                {
                    Name = "name " + i,
                    Artist = "artist " + i,
                    Album= "album " +i,
                    Year = (short)(2000) ,
                });
            }

            for (var i = 0; i < 2; i++)
            {
                context.Playlist.Add(new Playlist
                {
                    Name = "playlist " + i,
                });
            }

            context.SaveChanges();
            foreach (var p in context.Playlist)
            {
                p.Mp3s.Add(context.Mp3.Find(1));
                p.Mp3s.Add(context.Mp3.Find(2));
                p.Mp3s.Add(context.Mp3.Find(3));
            }
        }
    }
}
