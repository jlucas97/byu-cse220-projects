
public class Resume
{
    public string name;
    public List<Job> jobs = new List<Job>();

    public void Display()
    {
        string message = $"Name: {this.name}\n" +
        "Jobs: \n";

        Console.WriteLine(message);

        foreach (Job work in jobs)
        {
            work.Display();
        }


    }
}