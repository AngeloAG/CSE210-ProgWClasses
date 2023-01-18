/*
Author: Angelo Arellano Gaona
Date: 1/15/2022
Description:
Experiments with Classes and objects. 
Creates a Resume and Job classes to display
job history of a person
*/
using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("\nLearning02");
    Console.WriteLine("Classes and instances\n");

    AAAGJob aaagSoftwareDeveloper = new AAAGJob();
    aaagSoftwareDeveloper._aaagCompany = "Microsoft";
    aaagSoftwareDeveloper._aaagJobTitle = "Junior Developer";
    aaagSoftwareDeveloper._aaagStartYear = 2010;
    aaagSoftwareDeveloper._aaagEndYear = 2014;

    AAAGJob aaagSalesManager = new AAAGJob();
    aaagSalesManager._aaagCompany = "Apple";
    aaagSalesManager._aaagJobTitle = "Sales Manager";
    aaagSalesManager._aaagStartYear = 2014;
    aaagSalesManager._aaagEndYear = 2016;



    Console.WriteLine(aaagSoftwareDeveloper._aaagCompany);
    Console.WriteLine(aaagSalesManager._aaagCompany);

    Console.WriteLine("\n");
    aaagSoftwareDeveloper.Display();
    aaagSalesManager.Display();

    AAAGResume aaagAngeloResume = new AAAGResume();
    aaagAngeloResume._aaagName = "Angelo Arellano Gaona";
    aaagAngeloResume._aaagJobs.Add(aaagSoftwareDeveloper);
    aaagAngeloResume._aaagJobs.Add(aaagSalesManager);

    Console.WriteLine("\n");
    Console.WriteLine(aaagAngeloResume._aaagJobs[0]._aaagJobTitle);


    Console.WriteLine("\n");
    aaagAngeloResume.Display();

  }
}