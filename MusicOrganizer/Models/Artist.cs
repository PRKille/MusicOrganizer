using System;
using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist>{};
    private static int _count = 0;
    public string Name {get;set;}
    public int Id {get;}
    public List<Album> Albums {get;set;}

    public Artist(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _count;
      Albums = new List<Album>{};
      _count++;
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Artist Find(int id)
    {
      int index = _instances.FindIndex(artist => artist.Id == id);
      return _instances[index];
    }

    public void AddAlbum(Album album)
    {
      Albums.Add(album);
    }
  }

}