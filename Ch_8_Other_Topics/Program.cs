using My_Utility;
using My_Class_Library;

// REPEAT 
var fives = Enumerable.Repeat(5, 20);
MyConsole.Print(fives);

// RANGE
var sevenToTen = Enumerable.Range(7, 4);
MyConsole.Print(sevenToTen);

// USE RANGE TO GET OOD NUMBERS
var odds = Enumerable.Range(1, 10).Where(x => x % 2 != 0);
MyConsole.Print(odds);

// USE RANGE TO GET SQUARED NUMBERS
var squared1 = Enumerable.Range(1, 10).Select(x => x * x);
MyConsole.Print(squared1);

var squared2 = from n in Enumerable.Range(1, 10)
               select (n * n);
MyConsole.Print(squared2);


// CHECK COLLECTIONS FOR EQUALITY USING .SequenceEqual()

string[] catNames1 = { "Lucky", "Mittens", "Snowball" };
string[] catNames2 = { "Lucky", "Mittens", "Snowball" };

Console.WriteLine(catNames1.SequenceEqual(catNames2));

Console.WriteLine();

string? myString1 = "I am a cat";
string? myString2 = "I am a dog";

List<int> ints1 = new List<int>() { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 6, 7, 8, 8, 4, 3 };
List<int> ints2 = new List<int>() { 3, 2, 3, 5, 8, 43, 5, 67, 1, 2, 3, 7, 7, 7, 6, 5, 2, 1, 1, 1, 1, 1 };

// DISTINCT
var distinctInts = ints1.Distinct();
MyConsole.Print(distinctInts);

// INTERSECT
var intersectionOfStrings = myString1.Intersect(myString2);
MyConsole.Print(intersectionOfStrings);

// UNION 
var unionOfStrings = myString1.Union(myString2);
MyConsole.Print(unionOfStrings);

// EXCEPT 
var exceptInts = ints2.Except(ints1);
MyConsole.Print(exceptInts);

// ALL (CHECK IF ALL IN SET MEETS CRITERIA)
Console.WriteLine( ints1.All(x => x < 1000) );
Console.WriteLine( ints1.All(x => x < 5) );

// ANY (CHECK IF ANY IN SET MEETS CONDIDITON)
Console.WriteLine( ints1.Any(x => x < 1000) );
Console.WriteLine( ints1.Any(x => x < 5) );

// CONTAINS
Console.WriteLine( ints1.Contains(2) );
Console.WriteLine( ints1.Contains(45445) );

// SKIP (SKIPS FIRST 10 ELEMENTS)
var skippedInts = ints1.Skip(10);
MyConsole.Print(skippedInts);

// TAKE (TAKES FIRST 5 ELEMENTS)
var takenInts = ints1.Take(5);
MyConsole.Print(takenInts);

// SKIP WHILE (SKIPS UNTIL NUMBER 5 IS FOUND AND THEN TAKES THE REST)
var skipWhile5 = ints1.SkipWhile(x => x < 5);
MyConsole.Print(skipWhile5);

// TAKE WHILE (TAKE UNTIL NUMBER 5 IS FOUND AND THEN STOPS)
var takeWhile5 = ints1.TakeWhile(x => x < 5);
MyConsole.Print(takeWhile5);

// CONCAT (SPLICES TWO ARRAYS TOGETHER)
MyConsole.Print( ints1.Concat(ints2) );




// AGGREGATION OPERATIONS (p IS THE CURRENT PRODUCT, i IS WHAT IS AGGERATED EACH TIME)

int[] intsArray = { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 6, 7, 8, 8, 4, 3 };

var total = intsArray.Aggregate((p, i) => p + i);

// AGGREGATE IS SAME AS DOING THIS:
var p = 0;

for (int i = 0; i < intsArray.Length; i++) {
    p = p + intsArray[i];
}

Console.WriteLine(total);
Console.WriteLine(p);

// AGGREGATE WITH SEED VALUE (like setting and initial p)

var aggregateWithSeed = intsArray.Aggregate(10, (p, i) => p + i);
Console.WriteLine(aggregateWithSeed);





// SUM
int intsSum = intsArray.Sum();
Console.WriteLine(intsSum);

// AVERAGE
double intsAverage = intsArray.Average();
Console.WriteLine(intsAverage);



List<Person> people = new List<Person>()
{
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
            };

// SUM WITH LAMBDA
int sumOfAges = people.Sum(p => p.Age);

Console.WriteLine(sumOfAges);

// AVERAGE WITH LAMBDA
double averageAge = people.Average(p => p.Age);

Console.WriteLine(averageAge);

// MIN AND MAX WITH LAMBDA
int minAge = people.Min(p => p.Age);
int maxAge = people.Max(p => p.Age);

Console.WriteLine(minAge);
Console.WriteLine(maxAge);
