using System;

public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text ?? string.Empty;
        _isHidden = false;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        return BuildMaskedWord();
    }

    private string BuildMaskedWord()
    {
        char[] mask = new char[_text.Length];

        for (int i = 0; i < _text.Length; i++)
        {
            char current = _text[i];
            mask[i] = char.IsLetter(current) ? '_' : current;
        }

        return new string(mask);
    }
}
