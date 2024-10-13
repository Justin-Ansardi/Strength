
using Microsoft.EntityFrameworkCore;
using StrengthEFcore;
using System;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EntityContext>();

        using (var context = new EntityContext(optionsBuilder.Options))
        {
            var result = StrengthEFcore.DataAcessFunctions.DAF.GetAllUsers(context).ToList();

            foreach(var u in result)
            {
                Console.WriteLine(u.Name);
            }
        }
    }
}