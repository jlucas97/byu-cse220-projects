using System;

class Program
{
    static void Main(string[] args)
    {
        Json _jReader = Json.GetJsonInstance();
        _jReader.ReadJsonFile();

        Scripture _scripture = new Scripture();
        Console.WriteLine("I hope you can learn any scripture you want\n");
        Console.WriteLine("What is the book from your scripture: ");
        string _book = Console.ReadLine();
        Console.WriteLine("What is the chapter of the scripture: ");
        int _chapter = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Is this scripture a single verse? Y/N");
        string _verseOrVerses = (Console.ReadLine().ToUpper());
        int _firstVerse;
        string _verse;
        if (_verseOrVerses.Equals("N"))
        {
            Console.WriteLine("What is the number of the first verse: ");
            _firstVerse = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the number of the last verse: ");
            int _lastVerse = Convert.ToInt32(Console.ReadLine());
            int _range = _lastVerse - _firstVerse;
            _scripture.ScriptureToLearn(_book, _chapter, _firstVerse, _range);
            _verse = _scripture.DisplayScripture();
            Console.WriteLine(_verse);
        }
        else
        {
            Console.WriteLine("What is the number of the verse: ");
            _firstVerse = Convert.ToInt32(Console.ReadLine());
            _scripture.ScriptureToLearn(_book, _chapter, _firstVerse);
            _verse = _scripture.DisplayScripture();
            Console.WriteLine(_verse);
        }
        Word _word = new Word();
        _word.ShownWords = _verse.Split(' ').ToList();
        string userInput = "";
        Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
        userInput = Console.ReadLine();

        while (_word.IsHidden == false || userInput.Equals("quit"))
        {
            _word.ShownWords = _word.HideWords();
            _word.DisplayShownWords();

            Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
            userInput = Console.ReadLine();
            _word.IsHidden = _word.IsWordHidden();
        }

    }
}