//using System.Collections.Generic;

//TODO: Make sure this is the correct format
//TODO: Add in basic outline from OneNote
//TODO: ??
//TODO: Profit!

//version 0.2 7/14/2023
//version 0.3 7/14/23 Added futureProjects and the writeLine for the smallest project amount, and section titles
//v0.4 7/17 added the day of the week in a string, and protein choices for tomorrow
//v0.5 TO-DO added for new class path, and a bunch of future projects
//v0.51 Separate WIPs from new stuff - so I get done with current things first
//v0.51 update text, and change project for off hours - added tomorrow's extra training task
//v0.6 adjusted amount of projects, added only the first 5 future projects (which are WIPs)
//v0.61 add if statement for single project



string[] workProjects =
{
    "C# training", "Exercism", "Playwright Tests", "Regression Tests"
    , "Tracker project"
};
List<string> workList = new List<string>(workProjects);
string[] personalProjects =
    { "French", "spinning", "Tone Up" };
List<string> offHoursList = new List<string>(personalProjects);
string[] futureProjects =
{
    "socks", "a short story", "reading a book", "editing"
    , "captions for videos", "video games", "a new project"
    , "scripting", "sculptures"
    , "spinning", "3D printing", "sketching"
    , "LEGO"
};
List<string> newStuff = new List<string>(futureProjects);
string[] freezer = { "beef", "chicken", "pork", "veggies", "hamburger" };

var day = DateTime.Now;
var rnd = new Random();


var today = day.ToString("dddd");
var meat = rnd.Next(freezer.Length);
var next = rnd.Next(0, 5);
var total = workProjects.Length + personalProjects.Length;


Console.WriteLine($"Today is {today}.");
Console.WriteLine($"Get {freezer[meat]} ready for tomorrow.");
Console.WriteLine("\r ");
Console.WriteLine("\nWork Stuff");
Console.WriteLine("c-Completed,i-In Progress,s-Skip,n-Not Started\n");

foreach (var project in workList)
{
    var statusText = "";

    Console.WriteLine($"{project}");

    var status = Console.ReadLine();
    statusText = status switch
    {
        "c" => "completed!"
        , "i" => "in progress . . . ."
        , "s" => "skipped."
        , "n" => "not started."
        , _ => statusText
    };

    Console.SetCursorPosition(0, Console.CursorTop - 2);
    Console.WriteLine($"{project} updated to {statusText}");
}

Console.SetCursorPosition(0, Console.CursorTop - 1);
Console.WriteLine("\r ");
Console.WriteLine("Off hours stuff");
Console.Write("Don't forget ");
var stuff = 0;

if (personalProjects.Length > 1)
{
    foreach (var craft in offHoursList)
    {
        stuff++;
        if (stuff < personalProjects.Length)
            Console.Write($"{craft}, ");

        else
            Console.WriteLine($"and {craft}.");
    }
}

else
{
    Console.Write($"{offHoursList[0]}.");
}


Console.WriteLine("\nReminder:");
switch (total)
{
    case >= 8:
        Console.WriteLine("I'm pushing burn out.");
        break;
    case > 5:
        Console.WriteLine("I really shouldn't take on any more.");
        break;
    case < 3:
        var startOptions = "";
        Console.WriteLine($"Is it time to start {futureProjects[next]}?");
        var start = Console.ReadLine();
        startOptions = start switch
        {
            "y" => "Yes"
            , "n" => "No."
            , _ => startOptions
        };
        if (startOptions == "n")
        {
            var change = futureProjects[next];
            newStuff.RemoveRange(next, 1);
            newStuff.Add(change);
        }

        else
        {
            var change = futureProjects[next];
            newStuff.RemoveRange(next, 1);
            newStuff.Add(change);
            offHoursList.Add(change);
        }
        
        break;
    //ideal case
    default:
        Console.WriteLine("Doing good!");
        break;
}

