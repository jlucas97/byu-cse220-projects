using System.Xml;


public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public List<string> prompts = new List<string>();

    public string username;

    public string DisplayMenu()
    {
        return "1.Write\n" +
               "2.Display\n" +
               "3.Load\n" +
               "4.Save\n" +
               "5.Quit\n" +
               "What would you like to do?";
    }

    public string ShowPrompt()
    {

        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("How did I see the hand of the Lord in my life today?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");
        prompts.Add("What did I learn today that I didn't know before?");
        prompts.Add("How did I show kindness or generosity to someone else today?");
        prompts.Add("What is something that made me laugh or smile today?");
        prompts.Add("What is a goal or intention I have for tomorrow or the near future?");
        prompts.Add("How did I take care of myself physically, mentally, or emotionally today?");

        Random randomNum = new Random();
        int number = randomNum.Next(0, 9);
        return prompts[number];

    }


    public void ShowEntries()
    {
        foreach (Entry note in entries)
        {
            Console.WriteLine(note.Display());
        }
    }

    public void WriteEntry()
    {
        Entry note = new Entry();
        DateTime today = DateTime.Today;
        string journalPrompt;

        journalPrompt = ShowPrompt();
        note.prompt = journalPrompt;
        Console.WriteLine(journalPrompt);
        note.userResponse = Console.ReadLine();
        note.date = today;

        entries.Add(note);
    }

    public List<Entry> LoadEntries(string fileName)
    {

        string path = $"./{fileName}.xml";
        List<Entry> notes = new List<Entry>();

        if (System.IO.File.Exists($"{fileName}.xml"))
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            foreach (XmlNode item in xmlDoc.DocumentElement.SelectNodes("Journal/Entry"))
            {
                Entry note = new Entry();
                string prompt = item.Attributes["Prompt"].Value;
                note.prompt = prompt;
                DateTime date = Convert.ToDateTime(item.Attributes["Date"].Value);
                note.date = date;
                string userResponse = item.Attributes["User_Response"].Value;
                note.userResponse = userResponse;


                notes.Add(note);
            }
        }

        return notes;
    }

    public void SaveEntries(string fileName)
    {
        string path = $"./{fileName}.xml";
        XmlWriter writer = XmlWriter.Create(path);

        writer.WriteStartDocument();
        writer.WriteStartElement("Root");

        writer.WriteStartElement("Journal");
        writer.WriteStartAttribute("Name", $"{username}");

        foreach (Entry notes in entries)
        {
            writer.WriteStartElement("Entry");
            writer.WriteStartAttribute("Prompt", $"{notes.prompt}");
            writer.WriteStartAttribute("Date", $"{notes.date}");
            writer.WriteStartAttribute("User_Response", $"{notes.userResponse}");
            writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.WriteEndElement();

        writer.Close();
    }

    public void ActionMenu(int option)
    {
        string fileName;
        switch (option)
        {
            case 1:
                WriteEntry();
                break;
            case 2:
                ShowEntries();
                break;
            case 3:
                Console.WriteLine("What is the name of the file? Please don't add the XML extension");
                fileName = Console.ReadLine();
                LoadEntries(fileName);
                break;
            case 4:
                Console.WriteLine("What is the name of the file? Please don't add the XML extension");
                fileName = Console.ReadLine();
                SaveEntries(fileName);
                break;
            case 5:
                Console.WriteLine($"Thanks for using your journal, {username}");
                break;
            default:
                Console.WriteLine("That is not a valid value");
                break;
        }
    }




}