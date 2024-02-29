using System;

public class Word
{
    private string word;
    public bool hidden;
    public Word(string word)
    {
        this.word = word;
        hidden = false;
    }
    public void Hide()
    {
        hidden = true;
    }
    public override string ToString()
    {
        if (hidden)
        {
            return new string('_', word.Length);
        }
        else
        {
            return word;
        }
    }
}