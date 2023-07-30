using System.Linq;
/*
 version 0.2 7/14/2023
version 0.3 7/14/23 Added futureProjects and the writeLine for the smallest 
    project amount, and section titles
v0.4 7/17 added the day of the week in a string, and protein choices for 
    tomorrow
v0.5 TO-DO added for new class path, and a bunch of future projects
v0.51 Separate WIPs from new stuff - so I get done with current things first
v0.51 update text, and change project for off hours - added tomorrow's extra 
    training task
v0.6 adjusted amount of projects, added only the first 5 future projects 
    (which are WIPs)
v0.61 add if statement for single project
v0.62 if statement for new project
v0.7 finished project logic
v0.71 updated to lists
v0.72 moved back to arrays to ease additions and manipulations
*/
/*
 string[] arrayToBeFilled;
arrayToBeFilled= arrayToBeFilled.Append("str").ToArray();
 */
string
    [] workProjects =
    {
        "C# training", "Manual Tests", "Playwright tests", "Regressions"
        , "Side projects"
    };

string
    [] offHoursList =
    {
        "French", "knitting", "liquids"
    };


string
    [] newStuff =
    {
        "socks", "a short story", "reading a book", "editing", "video games"
        , "typing practice", "a new project", "scripting", "sculptures"
        , "3D printing", "sketching", "LEGO", "VIC-20 emulator set up"
        , "spinning"
    };

string[] freezer =
    {
        "beef", "chicken", "pork", "veggies", "hamburger"
    }
    ;

var day = DateTime.Now;
var rnd = new Random();


var today = day.ToString("dddd");
var meat = rnd.Next(freezer.Length);
var next = rnd.Next(0, 5);
var total = workProjects.Length + offHoursList.Length;

var update = 0;

Console.Clear();
Console.WriteLine($"Today is {today}.");
Console.WriteLine($"Get {freezer[meat]} ready for tomorrow.");
Console.WriteLine();
Console.WriteLine("\nWork Stuff");
Console.WriteLine(
    "c-Completed,i-In Progress,s-Skip,n-Not Started, f-Finished\n");

foreach (var project in workProjects)
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
        , "f" => "finished!"
        , _ => statusText
    };

    if (status == "f")
    {
        var change = workProjects[update];
        //workProjects.RemoveAt(update);
    }

    Console.SetCursorPosition(0, Console.CursorTop - 2);
    Console.WriteLine($"{project} updated to {statusText}");
    update++;
}

Console.SetCursorPosition(0, Console.CursorTop - 1);
Console.WriteLine();

Console.WriteLine("Off hours stuff");
var stuff = 0;


foreach (var craft in offHoursList)
{
    if (stuff <= offHoursList.Length)

    {
        var progress = "";

        Console.WriteLine($"{craft}?");

        var status = Console.ReadLine();
        progress = status switch
        {
            "c" => "completed!"
            , "i" => "in progress . . . ."
            , "s" => "skipped."
            , "n" => "not started."
            , "f" => "finished!"
            , _ => progress
        };

        if (progress == "f")
        {
            var shift = offHoursList[stuff];
            /*offHoursList.Add(shift);
            offHoursList.RemoveAt(stuff);*/
        }

        Console.SetCursorPosition(0, Console.CursorTop - 2);
        Console.WriteLine($"{craft} updated to {progress}");
        stuff++;
    }
}


Console.WriteLine("\nReminder:");
switch (total)
{
    case >= 9:
        Console.WriteLine("I'm pushing burn out.");
        break;
    case > 5:
        Console.WriteLine("I really shouldn't take on any more.");
        break;
    case < 3:
        var startOptions = "";
        Console.WriteLine($"Is it time to start {newStuff[next]}?");
        var start = Console.ReadLine();
        startOptions = start switch
        {
            "y" => "Yes"
            , "n" => "No."
            , _ => startOptions
        };
        if (startOptions == "n")
        {
            var change = newStuff[next];
            /*newStuff.Add(change);
            newStuff.RemoveAt(next);*/
        }

        else
        {
            var change = newStuff[next];
            /*newStuff.RemoveAt(next);
            newStuff.Add(change);
            offHoursList.Add(change);*/
        }

        break;
    //ideal case
    default:
        Console.WriteLine("Doing good!");
        break;
}
