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
    public class SearchController : ApiController
    {
        Mp3Dbcontext db = new Mp3Dbcontext();

        [HttpGet]
        public IHttpActionResult All(String key)
        {
            if (!string.IsNullOrEmpty(key))
            {

                var resultsByName = db.Mp3.Where(mp3 => mp3.Name.Contains(key)).ToList();
                var resultsByArtist = db.Mp3.Where(mp3 => mp3.Artist.Contains(key)).ToList();
                var resultsPlaylist = db.Playlist.Select(p => new { p.Id, p.Name, p.Mp3s.Count }).Where(pl => pl.Name.Contains(key)).ToList();

                return this.Ok(new { resultsByName, resultsByArtist, resultsPlaylist });
            }
            return this.BadRequest("invalid input");
        }
    }
}