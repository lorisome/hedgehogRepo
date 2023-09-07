using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LINQDemo 
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Pony> allPonies = Pony.GetListOfPonies();
            //Things you can do with LINQ
            //	- Where - filter a collection
            //let's get all the ponies with purple hair!
            IEnumerable<Pony> purpleHairedPonies = allPonies.Where(p => p.HairColor == "purple");
            Console.WriteLine("Here are all the ponies with purple hair: ");
            //Thoughts? What is this IEnumerable<Pony> thing? Let's look at the breakpoint and "enumerate the Ienumerable"
            foreach (Pony aPony in purpleHairedPonies)
            {
                Console.WriteLine(aPony.Name);
            }
            Console.WriteLine();
            //But whatever it is that is implementing the IEnumerable interface MUST have a concrete type so what type is it?
            Type checkConcreteType = purpleHairedPonies.GetType();
            Console.WriteLine($"The concrete type (class) of this collection is: {checkConcreteType.Name}");
            Console.WriteLine($"And its FULLY QUALIFIED NAME is: {checkConcreteType.FullName}");
            Console.WriteLine();
            //This is a fancy thing, but the whole point is that it is a collection you can iterate through.
            //in other words, an Enumerable is a collection you can loop through.

            //now we can get all the ponies that have more than 10 items in their cutie marks!
            //notes: This time I made a list instead of just making this a collection of Enumerables which is the default
            //type that is handed back to me, I am turning it into a specific type - a List<Pony>.
            //putting a .ToList(); on the end of a LINQ query is common, and it is what you usually do when you are DONE manipulating your data.
            List<Pony> MoreThan10ItemPonies = allPonies.Where(p => p.CutieMark.Quantity > 10).ToList();


            //-Select - pick properties from your collection's object and make a new little object that only contains select properties (so just like picking columns or computed columns in SQL) - otherwise known as transforming
            // this is similar to what you can do with the .map() array function in javascript.
            var specialListOfBrandNewObjectsThatHasPonyNameAndCutieMarkName = allPonies.Select(p => new { p.Name, p.CutieMark.Mark });
            foreach(var specialPony in specialListOfBrandNewObjectsThatHasPonyNameAndCutieMarkName) 
            {
                Console.WriteLine($"{specialPony.Name} has a {specialPony.Mark} for her cutie mark");
            }

            // First() and FirstOrDefault() - return only one object from the collection, the "First" one that matches your condition, or the first one in a sorted state, or even just the first one. We'll talk about FirstOrDefault later.
            //Let's find the first pony that has yellow hair
            Pony greenHairedPony = allPonies.First(p => p.HairColor == "green");
            //this method - .First() - will throw an exception if it doesn't find what you are looking for!!
            //sometimes this is what you want. For instance, if you are trying to get the "State" object from your collection that has the
            //state abbreviation "OH" and if nothing comes back, something has gone wrong, so you WANT an error.
            //other times, you will still want to get the first thing, and you don't really care if there is or isn't one there, you'll handle it either way.
            //In those situations you can use .FirstOrDefault() which will return you a default version of your type - empty string or zero or just a null object.
            
            Pony orangeHairedPony = allPonies.FirstOrDefault(p => p.HairColor == "orange");

            //I like to use .FirstOrDefault() when I want to order a list first, then get the first thing in the list in order.
            //Let's get the first pony alphabetically by name!
            Pony firstAlphabetically = allPonies.OrderBy(p => p.Name).FirstOrDefault();
            Console.WriteLine($"The first pony alphabetically is: {firstAlphabetically.Name}");

            //the chaining of methods is one of the things that makes linq so nice and succinct! 

            
            // - Any() - returns a boolean value that tells you if any objects in your collection meet a condition.
		    // similar to what you might think of as .contains() but can take an entire function or drill down into an object to find nested properties and things like that
            
            
            // All() - also returns a boolean answering whether all the things meet a specific condition

            // SelectMany() - How to flatten a collection. This is used when you have one collection of objects, and the objects contain another 
            //collection inside. We are probably not going to get to this today but I wanted to leave it here so you've heard of it.




        }
    }
}
