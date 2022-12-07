
//Declare an array
string[] myPonies;

//initialize (create an instance)
myPonies = new string[6];

//fill up the elements in the array with values
myPonies[0] = "Cotton Candy";
myPonies[1] = "Applejack";
myPonies[2] = "Scoops";
myPonies[3] = "Sweet Celebration";
myPonies[4] = "Cuddles";

//A quick reminder since I know you are still new to coding - you can of course put elements into your array by using a variable:
string myFavoritePony = "Blossom";
myPonies[5] = myFavoritePony;

//retrieve a value out of the array by index:
string mySecretPony = myPonies[2];
Console.WriteLine("My Secret Pony Is: " + mySecretPony);

Console.WriteLine();


//Declare and create an instance of an array with the elements filled in at instantiation:
string[] myPetNames = new string[4] { "Foxy", "Lily", "Luna", "Snowflake" };
int[] myNumbers = new int[6] { 45, 78, 100, 2 , 1, 99 };

//index out of range exception - your code will raise an exception if you try to access an element in an array THAT DOES NOT EXIST (is out of the bounds of the array)
//string thisWillBreak = myPetNames[7];
myPetNames[8] = "This Will Also Break";


//Do you need to know how big your array is? The implementation comes with an easy way to do that:
int myStableHoldsThisManyHorses = myPonies.Length;

int theHighestIndexInMyStable = myPonies.Length - 1;

//Remember, an array is fixed length - you can't add any more elements. You also can't delete elements (though you can replace them with null values)
// If you need to add more elements to an array, you can't do that so you will have to create a bigger array and copy your elements over to that one.

//a real-world example: a dropdown list on a webpage might be a use for an array. Or any text inputs that you take in on a form could be inserted into an array.

//loop through the elements of an array and do something with the elements
foreach (var pony in myPonies)
{
    Console.WriteLine(pony);
}

Console.WriteLine();
//loop through the elements of an array BY INDEX and do something with the elements

for (int i = 0; i < myPetNames.Length; i++)
{
    Console.WriteLine($"My Pet at index {i} is: { myPetNames[i] }");
}

//When working with arrays, for loops can sometimes be more useful because you want to be able to access each element BY INDEX, but often if you're going in order a foreach loop is still simpler

Console.ReadLine();