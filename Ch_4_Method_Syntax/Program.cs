using Ch_0_Class_Library;

// INPUT => OUTPUT
// (INPUT) => (WORK ON THE INPUT)

List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

List<Warrior> warriors = new List<Warrior>()
{
                new Warrior() { Height = 100 },
                new Warrior() { Height = 80 },
                new Warrior() { Height = 100 },
                new Warrior() { Height = 70 },
            };

// QUERY SYNTAX
//var oddNumbers = from n in numbers
//                 where n % 2 == 1
//                 select n;

// METHOD (LAMBDA) SYNTAX
// n iterates on the numbers collection
var oddNumbers = numbers.Where(n => n % 2 == 1);

foreach(var n in oddNumbers) {

    Console.Write($"{n}, ");

}

Console.WriteLine();

// DIFFERENCE BETWEEN SELECT AND WHERE

// 1) WHERE FILTERS OBJECTS IN THE COLLECTION
var shortWarriors1 = warriors.Where(w => w.Height < 90);

// 2) USER WHERE TO FILTER OBJECTS, THEN USE SELECT TO MAKE A NEW COLLECTION FROM THE OLD COLLECTION
var shortWarriors2 = warriors.Where(w => w.Height < 90).Select(w => w.Height);

// 3) YOU PROBABLY DON'T WANT TO DO THIS! RETURNS COLLECTION OF TRUE AN FALSE
var shortWarriors3 = warriors.Select(w => w.Height < 90);



foreach (var w in shortWarriors1) {

    Console.Write($"{w}, ");

}
Console.WriteLine();

foreach (var w in shortWarriors2) {

    Console.Write($"{w}, ");

}
Console.WriteLine();

foreach (var w in shortWarriors3) {

    Console.Write($"{w}, ");

}
Console.WriteLine();

// CAN TRANSFORM IEnumbrable TO LIST USING .ToList()
// .ToList() works like a foreach
var shortWarriorsList = warriors.Where(w => w.Height < 90)
                                .Select(w => w.Height)
                                .ToList();

foreach (var w in shortWarriorsList) {

    Console.Write($"{w}, ");

}
Console.WriteLine();


// ForEach
warriors.ForEach(w => Console.Write($"{w.Height}, "));

Console.WriteLine();

// Same as this foreach
foreach (var w in warriors) {

    Console.Write($"{w.Height}, ");

}



