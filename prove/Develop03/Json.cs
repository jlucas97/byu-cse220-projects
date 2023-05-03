using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

class Json
{

    [JsonProperty("volume_title", NullValueHandling = NullValueHandling.Ignore)]
    public string VolumeTitle { get; set; }

    [JsonProperty("book_title", NullValueHandling = NullValueHandling.Ignore)]
    public string BookTitle { get; set; }

    [JsonProperty("book_short_title", NullValueHandling = NullValueHandling.Ignore)]
    public string BookShortTitle { get; set; }

    [JsonProperty("chapter_number", NullValueHandling = NullValueHandling.Ignore)]
    public int ChapterNumber { get; set; }

    [JsonProperty("verse_number", NullValueHandling = NullValueHandling.Ignore)]
    public int VerseNumber { get; set; }

    [JsonProperty("verse_title", NullValueHandling = NullValueHandling.Ignore)]
    public string VerseTitle { get; set; }

    [JsonProperty("verse_short_title", NullValueHandling = NullValueHandling.Ignore)]
    public string VerseShortTitle { get; set; }

    [JsonProperty("scripture_text", NullValueHandling = NullValueHandling.Ignore)]
    public string ScriptureText { get; set; }

    private static Json _jsonInstance = null;

    private Json()
    {

    }

    public static Json GetJsonInstance()
    {
        if (_jsonInstance == null)
        {
            _jsonInstance = new Json();
        }
        return _jsonInstance;
    }

    public List<Scripture> ReadJsonFile()
    {
        try
        {
            string fileName = "./lds-scriptures.json";
            string jsonText = File.ReadAllText(fileName);

            var myObject = JsonConvert.DeserializeObject<Json[]>(jsonText);

            List<Scripture> scriptures = new List<Scripture>();
            foreach (Json content in myObject)
            {
                Reference refe = new Reference();
                refe.Volume = content.VolumeTitle;
                refe.Book = content.BookTitle;
                refe.Chapter = content.ChapterNumber;
                refe.Verse = content.VerseNumber;


                string scriptureText = content.ScriptureText;
                Scripture myScripture = new Scripture(refe, scriptureText);
                scriptures.Add(myScripture);
            }

            return scriptures;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

}