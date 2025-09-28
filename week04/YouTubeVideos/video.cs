// Video.cs
using System.Collections.Generic;

public class Video
{
    public string _title { get; set; }
    public string _author { get; set; }
    public int _length { get; set; } // en segundos
    public List<Comment> _comments { get; set; }

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
}
