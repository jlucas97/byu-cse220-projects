using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1.company = "Microsoft";
        job1.jobTitle = "Software Engineer";
        job1.startYear = 2021;
        job1.endYear = 2023;

        Job job2 = new Job();
        job2.company = "Apple";
        job2.jobTitle = "Manager";
        job2.startYear = 2023;
        job2.endYear = 2033;

        /*job1.Display();
        job2.Display();*/

        Resume myResume = new Resume();
        myResume.name = "Allison Rose";

        myResume.jobs.Add(job1);
        myResume.jobs.Add(job2);
        myResume.Display();

    }
}