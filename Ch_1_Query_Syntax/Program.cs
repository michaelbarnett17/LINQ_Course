using My_Utility;
using My_Class_Library;

// 1) SOURCE - from x in collection_of_x
// 2) CONDITIONS - where x > something
// 3) SELECT AND MANIPULATE COLLECTION EACH ELEMENT IN THE COLLECTION - select
// 4) EXECUTE BY ITERATING


int[] numbers = new int[] { 15, 6, 22, 17, 2, 4, 5 };

// QUERY IS NOT EXECUTED UNTIL COLLECTION IS ITERATED OVER
var numbersGreaterThanSeven = from number in numbers
                              where number > 7
                              orderby number
                              select number + 100;

numbers[0] = 16;

// EXECUTES NOW (WHEN IENUMERABLE IS ITERATED OVER OR WHEN .ToList() IS CALLED
MyConsole.Print(numbers);


string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };

var catsWithA = from cat in catNames
                where cat.Contains("A") && cat.Length < 5
                select cat;

MyConsole.Print(catNames);


List<Person> people = new List<Person>() {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 43, Gender.Female),
                new Person("Cassandra", "Jones", 7, 160, 37, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 33, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 18, Gender.Female)

};

var forCharPeople = from p in people
                    where p.FirstName.Length == 4
                    orderby p.Height descending, p.ID
                    select p;

MyConsole.Print(forCharPeople);

var forCharPeopleNames = from p in people
                         where p.FirstName.Length == 4
                         select p.FirstName;

MyConsole.Print(forCharPeopleNames);

// CREATE NEW OBJECTS FROM OLD OBJECTS
var youngPeople = from p in people
                  where p.Age < 25
                  select new YoungPerson(
                      p.FirstName + " " + p.LastName,
                      // see constructor in YoungPerson
                      // p.FirstName,
                      p.Age
                  );

foreach (var item in youngPeople) {

    Console.WriteLine($"{item.FullName} is {item.Age} years old.");

}
Console.WriteLine();

// USE LET KEYWORD TO DEFINE VARIABLES IN LINQ QUERY

var peopleWithA = from p in people
                  let firstCharacter = p.FirstName.ToLower()[0]
                  where firstCharacter == 'a'
                  select p;

foreach (var item in peopleWithA) {

    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");

}
Console.WriteLine();


// LIST OF LISTS TO SINGLE LIST

List<List<int>> list = new List<List<int>>
{
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 }
            };

//var allNumbers = from l in list
//                 from n in l
//                 select n;

var allNumbers = from l in list
                 let numbersList = l
                 from n in numbersList
                 select n;

MyConsole.Print(allNumbers);
