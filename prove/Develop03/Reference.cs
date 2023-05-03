
class Reference
{
    private string _volume;
    private string _book;
    private int _chapter;
    private int _verse;

    public Reference()
    {

    }

    public string Volume
    {
        get
        {
            return _volume;
        }
        set
        {
            _volume = value;
        }
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

    public int Verse
    {
        get
        {
            return _verse;
        }
        set
        {
            _verse = value;
        }
    }
}