// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear videos y comentarios
        Video video1 = new Video("Fun Coding Tips", "Alice", 300);
        video1._comments.Add(new Comment("Bob", "Great tips!"));
        video1._comments.Add(new Comment("Charlie", "Thanks for sharing."));
        video1._comments.Add(new Comment("Dana", "Very helpful!"));

        Video video2 = new Video("C# Basics", "Eve", 600);
        video2._comments.Add(new Comment("Frank", "Loved it!"));
        video2._comments.Add(new Comment("Grace", "Nice explanation."));
        video2._comments.Add(new Comment("Heidi", "Clear and concise."));
        video2._comments.Add(new Comment("Ivan", "Easy to understand."));

        Video video3 = new Video("Programming Fun", "Ivy", 450);
        video3._comments.Add(new Comment("Jack", "This is awesome."));
        video3._comments.Add(new Comment("Kate", "Cool video."));
        video3._comments.Add(new Comment("Leo", "Learned a lot."));

        Video video4 = new Video("Advanced C# Techniques", "Mia", 720);
        video4._comments.Add(new Comment("Nina", "Very informative."));
        video4._comments.Add(new Comment("Oscar", "Thanks, I learned something new."));
        video4._comments.Add(new Comment("Paul", "Great examples."));
        video4._comments.Add(new Comment("Quinn", "Helpful for my project."));

        // Lista de videos
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Mostrar información de cada video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video._comments)
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }
            Console.WriteLine();
        }
    }
}
