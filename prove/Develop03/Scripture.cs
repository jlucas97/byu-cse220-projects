using Newtonsoft.Json.Linq;

class Scripture
{
    private Reference _reference;
    private string _scripture;
    private List<Scripture> _scripturesList = new List<Scripture>();

    private string _words;

    public Scripture()
    {

    }

    public Scripture(Reference reference, string scripture)
    {
        this._reference = reference;
        this._scripture = scripture;
    }

    public void ScriptureToLearn
    (string book, int chapter, int verse, int range = 0)
    {
        try
        {
            Json jsonScriptures = Json.GetJsonInstance();
            List<Scripture> scriptures = jsonScriptures.ReadJsonFile();

            List<Scripture> scripturesByBook = new List<Scripture>();
            scripturesByBook = scriptures.Where(n => n._reference.Book.Equals(book)).ToList();
            List<Scripture> finalScriptures = new List<Scripture>();

            foreach (Scripture scriptureVerse in scripturesByBook)
            {
                if (scriptureVerse._reference.Chapter == chapter)
                {
                    if (scriptureVerse._reference.Verse >= verse && scriptureVerse._reference.Verse <= (verse + range))
                    {
                        finalScriptures.Add(scriptureVerse);
                        _words = scriptureVerse._scripture;
                    }
                }
            }
            this._scripturesList = finalScriptures;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex + "The book, chapter or verse might not exist, please check again");
        }
    }

    public string DisplayScripture()
    {
        string message = "";
        bool multiple = false;
        if (_scripturesList.Count > 1)
            multiple = true;

        if (multiple == false)
        {
            foreach (Scripture myScriptures in _scripturesList)
            {
                message += $"{myScriptures._reference.DisplayReference()} {myScriptures._scripture}";
            }
        }
        else
        {
            int first = _scripturesList[0]._reference.Verse;
            int last = _scripturesList[(_scripturesList.Count - 1)]._reference.Verse;
            for (int i = 0; i < _scripturesList.Count; i++)
            {
                if (i == 0)
                {
                    message += $"{_scripturesList[i]._reference.Book} {_scripturesList[i]._reference.Chapter}:{first}-{last} {_scripturesList[i]._scripture} ";
                }
                else
                {
                    message += $"{_scripturesList[i]._scripture} ";
                }
            }
        }
        return message;
    }

    public Reference MyReference
    {
        get
        {
            return _reference;
        }
        set
        {
            _reference = value;
        }
    }

    public string MyScripture
    {
        get
        {
            return _scripture;
        }
        set
        {
            _scripture = value;
        }
    }

    public List<Scripture> ScripturesList
    {
        get
        {
            return _scripturesList;
        }
        set
        {
            _scripturesList = value;
        }
    }

    public string Words { get => _words; set => _words = value; }
}