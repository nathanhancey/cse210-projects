using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._jobTitle = "Property Maintenance";
        job1._company = "Newcomb Properties";
        job1._startYear = 2020;
        job1._endYear = 2023;

        Resume myResume = new Resume();

        myResume._name = "Nathan Hancey";

        myResume._jobs.Add(job1);

        myResume.Display();
    }
}