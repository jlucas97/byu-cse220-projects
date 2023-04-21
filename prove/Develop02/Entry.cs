
public class Entry
{

    public string prompt { get; set; }
    public DateTime date { get; set; }
    public string userResponse { get; set; }

    /*public Entry(string pPrompt, DateTime pDate, string pUserResponse)
    {
        pPrompt = this.prompt;
        pDate = this.date;
        pUserResponse = this.userResponse;
    }*/

    public Entry()
    {

    }

    public string Display()
    {
        string message = $"Date: {date} - Prompt: {prompt}" +
        $"\n{userResponse}\n";

        return message;
    }
}