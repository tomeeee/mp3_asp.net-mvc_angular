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
    public class PlaylistController : ApiController
    {
        Mp3Dbcontext db = new Mp3Dbcontext();

        [HttpGet]
        public IHttpActionResult all()
        {
            try
            {
                var plAll = db.Playlist.Select(p => new { p.Id, p.Name, p.Mp3s.Count });
                return this.Ok(plAll);
            }
            catch
            {

                return this.InternalServerError();
            }

        }

        [HttpGet]
        public IHttpActionResult byId(int? id)
        {
            if (id != null)
            {
                var pl = db.Playlist.Select(p => new  // => view model napravit ili rjesit reference // prebacit rad s bazom u drugu clasu...
                {
                    p.Id,
                    p.Name,
                    p.Mp3s,
                    //notInPlaylistIds = db.Mp3.Select(mp => mp.Id).Except(p.Mp3s.Select(m => m.Id))
                    //notInPlaylist = db.Mp3.Where(mp3 => db.Mp3.Select(mp => mp.Id).Except(p.Mp3s.Select(m => m.Id)).Contains(mp3.Id))
                    notInPlaylist = db.Mp3.Where(mp3 => !p.Mp3s.Select(m => m.Id).Contains(mp3.Id)).ToList()
                }).FirstOrDefault(p => p.Id == id);

                return this.Ok(pl);
            }
            return this.BadRequest();
        }

        [HttpPost]
        public IHttpActionResult add(Playlist newPlaylist)
        {
            if (ModelState.IsValid && newPlaylist != null)
            {
                try
                {
                    db.Playlist.Add(newPlaylist);
                    db.SaveChanges();
                    return this.Ok(new { newPlaylist.Id, newPlaylist.Name, newPlaylist.Mp3s.Count });
                }
                catch
                {
                    return this.BadRequest();
                }
            }
            return this.BadRequest("model state invalid");
        }


        [HttpPost]
        public IHttpActionResult delete(int? id)
        {
            try
            {
                var pl = db.Playlist.FirstOrDefault(i => i.Id == id);
                if (pl.Mp3s.Count != 0)
                {
                    pl.Mp3s.Clear();
                }
                db.Playlist.Remove(pl);
                db.SaveChanges();
                return this.Ok();
            }
            catch
            {
                return this.NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult update(Playlist updatePl)
        {
            if (ModelState.IsValid && updatePl != null)
            {
                var playlist = db.Playlist.FirstOrDefault(i => i.Id == updatePl.Id);
                playlist.Name = updatePl.Name;
                playlist.Mp3s.Clear();
                foreach (var mp3 in updatePl.Mp3s)
                {
                    playlist.Mp3s.Add(db.Mp3.FirstOrDefault(m => m.Id == mp3.Id));
                }
                db.SaveChanges();
                return this.Ok("Saved");

            }
            return this.BadRequest();
        }
    }
}