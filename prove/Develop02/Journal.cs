using System.IO;
using System.Xml;
using System.Xml.Serialization;


public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public List<string> _prompts = new List<string>();

    public string _username;

    public string DisplayMenu()
    {
        return "1.Write\n" +
               "2.Display\n" +
               "3.Load\n" +
               "4.Save\n" +
               "5.Quit\n\n" +
               "What would you like to do?";
    }

    public string ShowPrompt()
    {

        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What did I learn today that I didn't know before?");
        _prompts.Add("How did I show kindness or generosity to someone else today?");
        _prompts.Add("What is something that made me laugh or smile today?");
        _prompts.Add("What is a goal or intention I have for tomorrow or the near future?");
        _prompts.Add("How did I take care of myself physically, mentally, or emotionally today?");

        Random randomNum = new Random();
        int number = randomNum.Next(0, 9);
        return _prompts[number];

    }


    public void ShowEntries()
    {
        foreach (Entry note in _entries)
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
        note._prompt = journalPrompt;
        Console.WriteLine(journalPrompt);
        note._userResponse = Console.ReadLine();
        note._date = today;

        _entries.Add(note);
        Console.WriteLine();
    }

    public List<Entry> LoadEntries(string fileName)
    {
        string path = $"./{fileName}.xml";
        List<Entry> notes = new List<Entry>();

        if (File.Exists(path))
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>), new XmlRootAttribute("Journal"));
                    notes = (List<Entry>)serializer.Deserialize(reader);

                }
                Console.WriteLine("\nFile loaded successfully\n");
                foreach (Entry note in notes)
                {
                    Console.WriteLine(note.Display());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }




        return notes;
    }

    public void SaveEntries(string fileName)
    {
        try
        {
            string path = $"./{fileName}.xml";
            using (StreamWriter writer = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>), new XmlRootAttribute("Journal"));
                serializer.Serialize(writer, _entries);
            }
            Console.WriteLine("\nFile saved successfully\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
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
                this._entries = LoadEntries(fileName);
                break;
            case 4:
                Console.WriteLine("What is the name of the file? Please don't add the XML extension");
                fileName = Console.ReadLine();
                SaveEntries(fileName);
                break;
            case 5:
                Console.WriteLine($"Thanks for using your journal, {_username}");
                break;
            default:
                Console.WriteLine("That is not a valid value");
                break;
        }
    }




}