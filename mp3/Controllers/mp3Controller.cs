using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using mp3.Models;

namespace mp3.Controllers
{
    public class mp3Controller : ApiController
    {
        Mp3Dbcontext db = new Mp3Dbcontext();

        [HttpGet]
        public IHttpActionResult all()
        {
            try
            {
                var mp3all = db.Mp3.Select(m => new { m.Id, m.Name, m.Artist, m.Album });
                return this.Ok(mp3all);
            }
            catch
            {

                return this.InternalServerError();
            }

        }

        [HttpGet]
        public IHttpActionResult byId(int? id)
        {
            var mp3 = db.Mp3.Select(m => new
            {
                m.Id,
                m.Name,
                m.Artist,
                m.Album,
                m.Year,
            }).FirstOrDefault(i => i.Id == id);


            return this.Ok(mp3);
        }

        [HttpPost]
        public IHttpActionResult add(Mp3 newMp3)
        {
            if (ModelState.IsValid && newMp3 != null)
            {
                try
                {
                    db.Mp3.Add(newMp3);
                    db.SaveChanges();
                    return this.Ok(new { newMp3.Id });
                }
                catch
                {
                    return this.BadRequest();
                }
            }
            return this.BadRequest("invalid input, try again");
        }
        [HttpPost]
        public IHttpActionResult delete(int? id)
        {
            try
            {
                var mp3 = db.Mp3.FirstOrDefault(i => i.Id == id);
                if (mp3.Playlists.Count != 0)
                {
                    mp3.Playlists.Clear();
                }
                db.Mp3.Remove(mp3);
                db.SaveChanges();
                return this.Ok();
            }
            catch
            {
                return this.NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult update(Mp3 updateMp3)
        {
            if (updateMp3 != null && ModelState.IsValid)
            {
                var mp3 = db.Mp3.FirstOrDefault(i => i.Id == updateMp3.Id);
                mp3.Name = updateMp3.Name;
                mp3.Artist = updateMp3.Artist;
                mp3.Album = updateMp3.Album;
                mp3.Year = updateMp3.Year;
                db.SaveChanges();
                return this.Ok("Saved");
            }
            return this.BadRequest("invalid input");
        }

    }
}
