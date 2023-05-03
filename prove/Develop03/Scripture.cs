using Newtonsoft.Json.Linq;

class Scripture
{
    private Reference _reference;
    private string _scripture;
    private List<Word> _hiddenWords = new List<Word>();

    public Scripture()
    {

    }

    public Scripture(Reference reference, string scripture)
    {
        this._reference = reference;
        this._scripture = scripture;
    }

    public string ScriptureToLearn(string volume, string book, int chapter, int verse)
    {
        Json jsonScriptures = Json.GetJsonInstance();
        List<Scripture> scriptures = jsonScriptures.ReadJsonFile();

        List<Scripture> scripturesByVolume = new List<Scripture>();
        scripturesByVolume = scriptures.Where(n => n._reference.Volume.Equals(volume)).ToList();
        return Convert.ToString(scripturesByVolume.Count);
    }



    public string DisplayScripture()
    {
        return $"{_reference.Book} {_reference.Chapter}:{_reference.Verse} {_scripture}";
    }


}