using System;
using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Album
  {
    public string Name { get; set; }
    public int Year { get; set; }
    public string Type { get; set; }
    public string Genre { get; set; }
    public int Id { get; }
    private static int _count = 0;

    private static List<Album> _instances = new List<Album> {};

    public Album(string name, int year, string type, string genre)
    {
      Name = name;
      Year = year;
      Type = type;
      Genre = genre;
      _instances.Add(this);
      Id = _count;
      _count ++;
    }

    public static List<Album> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Album Find(int id)
    {
      int index = _instances.FindIndex(album => album.Id == id);
      return _instances[index];
    }
  }
}