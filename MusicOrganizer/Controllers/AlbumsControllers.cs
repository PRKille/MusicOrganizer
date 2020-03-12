using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Controllers
{
  public class AlbumsController : Controller
  {
    [HttpGet("/artists/{artistId}/albums/new")]
    public ActionResult New(int id)
    {
      Artist artist = Artist.Find(id);
      return View(artist);
    }

    [HttpGet("/artists/{artistId}/albums/{albumId}")]
    public ActionResult Show(int artistID, int albumID)
    {
      Album album = Album.Find(albumID);
      Artist artist = Artist.Find(artistID);
      Dictionary <string, object> model = new Dictionary<string, object>();
      model.Add("album", album);
      model.Add("artist", artist);
      return View(model);
    }

    [HttpPost("/artists/{artistId}/albums/{albumId}")]
    public ActionResult Delete(int albumID)
    {
      List<Album> albums = Album.GetAll();
      int indexToDelete = albums.FindIndex(album => album.Id == albumID);
      albums.RemoveAt(indexToDelete);
      return RedirectToAction("Show", "Artist");
    }
  }
}