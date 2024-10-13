
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StrengthEFcore;
using StrengthEFcore.DataAcessFunctions;
using System;
using System.ComponentModel;


class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EntityContext>();

        using (var context = new EntityContext(optionsBuilder.Options))
        {
            var result = DAF.GetUserWorkoutData(context, 34).ToList();


            var data = result.Select(x => x.ExerciseBouts.ToList()).ToList();
            foreach(var w in data)
            {
                DisplayWorkoutDataToConsole(w);
            }

        }
    }

    public static void DisplayWorkoutDataToConsole(List<ExerciseBout> bouts)
    {

        var index = 1;
        foreach (var b in bouts)
        {

            Console.WriteLine(b.Exercise);
            foreach (var s in b.SetReps)
            {
                Console.WriteLine($"Set: {index} Reps: {s} ");
                index++;
            }
        }
    }
}
