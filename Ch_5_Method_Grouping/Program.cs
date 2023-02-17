using Ch_0_Class_Library;

List<Person> people = new List<Person>()
 {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 22, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Male),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 23, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };

int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

// GROUPING GROUPS BY A COMMON PROPERTY

// Returns IEnumerable<IGrouping<Gender, Person>>
var genderGrouping = people.GroupBy(p => p.Gender);

foreach(var item in genderGrouping) {

    // use .Key to access the key (what it is grouped by) of the grouping
    Console.WriteLine(item.Key);

    // loop through the grouping
    foreach (var person in item) {

        Console.WriteLine($"\t{person.FirstName} {person.LastName}");

    }

}

// OVER THE AGE OF 20, GROUP BY FIRST CHARACTER OF FIRST NAME, ORDERED BY FIRST NAME

var alphabeticalGrouping = people
                                .Where(p => p.Age > 20)
                                .OrderBy(p => p.FirstName)
                                .GroupBy(p => p.FirstName[0]);

foreach (var grouping in alphabeticalGrouping) {

    Console.WriteLine(grouping.Key);

    foreach (var person in grouping) {

        Console.WriteLine($"\t{person.FirstName} {person.LastName}");

    }

}


Console.WriteLine();

// GROUP BY MULTIPLE KEYS (PEOPLE WITH SAME GENDER AND AGE ARE IN SAME GROUP)
// NEED TO USE ANONYMOUS OBJECT: new { p.Gender, p.Age }

var ageGenderGroup = people.GroupBy(p => new { p.Gender, p.Age });

foreach (var grouping in ageGenderGroup) {

    Console.WriteLine($"{grouping.Key}");

    foreach (var person in grouping) {

        Console.WriteLine($"\t{person.FirstName}");

    }
}

// GROUPING WITH CUSTOM KEYS (LIKE EVEN OR ODD)
var evenOrOddNumbers1 = arrayOfNumbers.GroupBy(n => n % 2 == 0);

foreach (var grouping in evenOrOddNumbers1) {

    Console.WriteLine($"{grouping.Key}");

    foreach (var n in grouping) {

        Console.WriteLine($"\t{n}");

    }
}

Console.WriteLine();

// MAKE IT RETURN EVEN OR ODD INSTEAD OF TRUE / FALSE
var evenOrOddNumbers2 = arrayOfNumbers.GroupBy(n => (n % 2 == 0) ? "Even" : "Odd");

foreach (var grouping in evenOrOddNumbers2) {

    Console.WriteLine($"{grouping.Key}");

    foreach (var n in grouping) {

        Console.WriteLine($"\t{n}");

    }
}