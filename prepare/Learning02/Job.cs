
public class Job
{
    public string company;
    public string jobTitle;
    public int startYear;
    public int endYear;

    public void Display()
    {
        string message = $"{this.jobTitle} ({this.company}) {this.startYear}-{this.endYear}";

        Console.WriteLine(message);
    }
}