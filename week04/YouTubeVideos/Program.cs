using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Designing a Minimalist Home Office", "Studio North", 512);
        video1.AddComment(new Comment("Lena", "That lamp choice is perfect for the space."));
        video1.AddComment(new Comment("Marco", "Love the way you used natural light here."));
        video1.AddComment(new Comment("Priya", "Can you share the desk brand?"));
        videos.Add(video1);

        Video video2 = new Video("10 Minute Pasta, No Fuss", "Chef Mateo", 638);
        video2.AddComment(new Comment("Hannah", "Tried it tonight, huge hit."));
        video2.AddComment(new Comment("Sam", "The sauce tip saved my weeknight dinner."));
        video2.AddComment(new Comment("Ivy", "Subbed mushrooms for zucchini and it rocked."));
        video2.AddComment(new Comment("Elliot", "Could you do a gluten-free version?"));
        videos.Add(video2);

        Video video3 = new Video("Trail Run Basics: Breathing and Form", "Outdoor Steps", 905);
        video3.AddComment(new Comment("Jordan", "Breathing tips made a difference today."));
        video3.AddComment(new Comment("Noah", "That downhill form reminder is gold."));
        video3.AddComment(new Comment("Alyssa", "What shoes are you wearing?"));
        videos.Add(video3);

        Video video4 = new Video("How I Plan a Study Week", "Campus Coach", 721);
        video4.AddComment(new Comment("Kira", "Finally a method that feels realistic."));
        video4.AddComment(new Comment("Zoe", "The time-blocking demo was super clear."));
        video4.AddComment(new Comment("Rafael", "Going to try the Friday review habit."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comment List:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}