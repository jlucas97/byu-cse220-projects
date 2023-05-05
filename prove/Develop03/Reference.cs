
class Reference
{
    private string _volume;
    private string _book;
    private int _chapter;
    private int _verse;

    public Reference()
    {

    }

    public string DisplayReference()
    {
        return $"{_book} {_chapter}:{Verse}";
    }


    public string Book
    {
        get
        {
            return _book;
        }
        set
        {
            _book = value;
        }
    }

    public int Chapter
    {
        get
        {
            return _chapter;
        }
        set
        {
            _chapter = value;
        }
    }

    public int Verse { get => _verse; set => _verse = value; }
    public string Volume { get => _volume; set => _volume = value; }
}