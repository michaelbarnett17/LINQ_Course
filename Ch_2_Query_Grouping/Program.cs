using My_Utility;
using My_Class_Library;

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

// LINQ QUERY CAN END WITH EITHER A GROUP CLAUSE OR A SELECT CLAUSE
var genderGroup = from p in people
                  group p by p.Gender;

// GROUP CLAUSE RETURNS IEnumerable<Grouping<Gender, Person>>
// GROUPING IMPLEMENTS IEnumerable, SO YOU HAVE IEnumerable<IEnumerable>
// SO YOU NEED TO USE A NESTED foreach LOOP

foreach (var person in genderGroup) {

    // USE Key TO VIEW GROUP TYPES
    Console.WriteLine($"{person.Key}");

    foreach (var p in person) {

        Console.WriteLine($"\t{p.FirstName} {p.Gender}");

    }
}

Console.WriteLine();

var ageGroup = from p in people
               where p.Age > 20
               group p by p.Age;

foreach (var myKey in ageGroup) {

    Console.WriteLine($"{myKey.Key}");

    foreach (var item in myKey) {

        Console.WriteLine($"\t{item.FirstName} {item.Age}");

    }
}

Console.WriteLine();

// GROUP BY FIRST LETTER IN ALPHABETICAL ORDER WITH AGE > 20

var alphabeticalGroup = from p in people
                        where p.Age > 20
                        orderby p.FirstName
                        group p by p.FirstName[0];

foreach (var myKey in alphabeticalGroup) {

    Console.WriteLine($"{myKey.Key}");

    foreach (var item in myKey) {

        Console.WriteLine($"\t{item.FirstName}");

    }
}


// GROUP BY MULTIPLE KEYS
// GROUP BY SAME GENDER AN SAME AGE (PEOLE IN WITH SAME GENDER AND AGE ARE GROUPED)
// NEED TO USE ANONYMOUS OBJECT
var multipleKeys = from p in people
                   group p by new {
                       p.Gender,
                       p.Age
                   };

foreach (var myKey in multipleKeys) {

    Console.WriteLine(myKey);
    Console.WriteLine($"{myKey.Key}");

    foreach (var item in myKey) {

        Console.WriteLine($"\t{item.FirstName}");

    }
}


// INTO KEYWORD

int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var numbers = from n in arrayOfNumbers
              orderby n
              let evenOrOdd = (n % 2 == 0) ? "Even" : "Odd"
              group n by evenOrOdd into nums
              orderby nums.Count()
              select nums;

foreach (var num in numbers) {

    Console.WriteLine($"{num.Key}");

    foreach (var i in num) {

        Console.WriteLine($"\t{i}");

    }
}

// COUNTING EACH GROUP
var howManyOfEachGroup = from p in people
                         group p by p.Gender into g
                         orderby g.Count()
                         select new {
                             Gender = g.Key,
                             NumOfPeople = g.Count()
                         };

foreach (var amount in howManyOfEachGroup) {

    Console.WriteLine($"{amount.Gender}");
    Console.WriteLine($"\t{amount.NumOfPeople}");

}
