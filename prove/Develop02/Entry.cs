
public class Entry
{

    public string prompt { get; set; }
    public DateTime date { get; set; }
    public string userResponse { get; set; }


    public Entry()
    {

    }

    public string Display()
    {
        return $"Date: {date.ToShortDateString()} - Prompt: {prompt} \n{userResponse}\n";
    }
}