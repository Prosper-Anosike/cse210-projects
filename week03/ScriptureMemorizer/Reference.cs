using System;

public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = Math.Max(startVerse, endVerse);
    }

    public override string ToString()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}
