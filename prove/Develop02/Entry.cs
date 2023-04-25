
public class Entry
{

    public string _prompt { get; set; }
    public DateTime _date { get; set; }
    public string _userResponse { get; set; }


    public Entry()
    {

    }

    public string Display()
    {
        return $"Date: {_date.ToShortDateString()} - Prompt: {_prompt} \n{_userResponse}\n";
    }
}