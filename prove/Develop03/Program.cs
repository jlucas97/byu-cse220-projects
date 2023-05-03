using System;

class Program
{
    static void Main(string[] args)
    {
        Json jReader = Json.GetJsonInstance();
        jReader.ReadJsonFile();

        Scripture scripture = new Scripture();
        Console.WriteLine(scripture.ScriptureToLearn("Old Testament", "Genesis", 1, 1));
    }
}