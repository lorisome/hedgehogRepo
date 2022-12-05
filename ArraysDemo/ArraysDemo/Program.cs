//Declare an array
string[] myPonies;

//initialize (create an instance)
myPonies = new string[6];

//fill up the elements in the array with values
myPonies[0] = "Moonlight";
myPonies[3] = "Daytime";
myPonies[1] = "Twilight";
myPonies[2] = "Sunset";


//get a value out of the array by index:
string mySecretPony = myPonies[2];
Console.WriteLine("My Secret Pony Is: " + mySecretPony);

Console.WriteLine();

//loop through the elements of an array and do something with the elements
foreach (var pony in myPonies)
{
    Console.WriteLine(pony);
}

Console.WriteLine();

//Declare and create an instance of an array with the elements filled in at instantiation:
string[] myPetNames = new string[4] { "Foxy", "Lily", "Luna", "Snowflake" };

//loop through the elements of an array BY INDEX and do something with the elements
string sentence = "";
for (int i = 0; i < myPetNames.Length; i++)
{
    sentence = sentence + myPetNames[i] + " ";
}
Console.WriteLine(sentence);

////When working with arrays, for loops are often more useful because you want to be able to access each element BY INDEX, but often if you're going in order a foreach loop is still simpler

////index out of range exception - your code will raise an exception if you try to access an element in an array THAT DOES NOT EXIST (is out of the bounds of the array)
//string thisWillBreak = myPetNames[7]

////limitation: is fixed length - you can't add any more elements
////real-world example:a dropdown list on a webpage or passing lists of objects around like customers who have first name, last name, address

