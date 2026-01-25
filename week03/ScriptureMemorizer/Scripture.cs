using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private static readonly Random _random = new Random();

    private readonly Reference _reference;
    private readonly List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = CreateWords(text);
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden);
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();

        if (visibleWords.Count == 0)
        {
            return;
        }

        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.ToString();
        string wordsText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{referenceText}\n\n{wordsText}";
    }

    public string GetProgressLine()
    {
        int hidden = _words.Count(word => word.IsHidden);
        int total = _words.Count;
        return $"Hidden: {hidden}/{total} words";
    }

    public string GetReferenceText()
    {
        return _reference.ToString();
    }

    private static List<Word> CreateWords(string text)
    {
        List<Word> words = new List<Word>();

        foreach (string value in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            words.Add(new Word(value));
        }

        return words;
    }
}
