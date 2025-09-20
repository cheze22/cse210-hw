using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);
        
        for (int i = 0; i < wordsToHide; i++)
        {
            if (visibleWords.Count > 0)
            {
                int randomIndex = random.Next(visibleWords.Count);
                visibleWords[randomIndex].Hide();
                visibleWords.RemoveAt(randomIndex);
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public double GetHiddenPercentage()
    {
        if (_words.Count == 0) return 0.0;
        
        int hiddenCount = _words.Count(word => word.IsHidden());
        return (double)hiddenCount / _words.Count * 100.0;
    }

    public int GetTotalWords()
    {
        return _words.Count;
    }

    public int GetHiddenWordsCount()
    {
        return _words.Count(word => word.IsHidden());
    }
}