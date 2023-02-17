using My_Utility;
// using My_Class_Library; DON'T USE FOR THIS PROJECT

List<Person> people = new List<Person>()
{
                new Buyer() { Age = 20 , ID = 1, Height = 125, Weight = 77},
                new Buyer() { Age = 25 , ID = 2, Height = 150, Weight = 88},
                new Buyer() { Age = 20 , ID = 5, Height = 100, Weight = 58},
                new Supplier() { Age = 22 },
                new Supplier() { Age = 20 }
            };


object[] myObjects = { 1, 2, 55, 27, new Person(), "I'm a string", 44, 17 };

// FILTER USING .OfType 
var allIntegers1 = myObjects.OfType<int>();

// FILTER USING .Where WITH LAMBDA
var allIntegers2 = myObjects.Where(x => x is int);

// FILTER USING is KEYWORD
var suppliers = from p in people
                where p is Supplier
                select p;

// FILTER BY PROPERTY OF SUBCLASS
var buyers20 = from p in people
               where p is Buyer
               where (p as Buyer).Age == 20
               select p;

// FILTER BY PROPERTY OF SUBCLASS (CAN USE let TO MAKE MORE READABLE)
var buyers20short = from p in people
                    let b = p as Buyer
                    where p is Buyer
                    where b.Age == 20 && b.Height < 110
                    select p;

// FILTER USING LAMBDAS, SAME AS ABOVE (PARAMATER b IN LAMBDA IS LIKE THE let b ABOVE)
var buyers20short_lambda = people.OfType<Buyer>().Where(b => b.Age == 20 && b.Height < 110);


MyConsole.Print(allIntegers1);
MyConsole.Print(allIntegers2);

foreach (var item in suppliers) {
    Console.Write($"Age: {((Supplier)item).Age}, ");
}
Console.WriteLine();

foreach (var item in suppliers) {
    Console.Write($"{item.GetType()} ");
}
Console.WriteLine();

foreach (var item in buyers20) {
    Console.Write($"Age: {((Buyer)item).Age}, ");
}
Console.WriteLine();

foreach (var item in buyers20short) {
    Console.Write($"Age: {((Buyer)item).Age}, Height: {((Buyer)item).Height} ");
}
Console.WriteLine();

foreach (var item in buyers20short_lambda) {
    Console.Write($"Age: {((Buyer)item).Age}, Height: {((Buyer)item).Height} ");
}
Console.WriteLine();





// START AS ARRAY
int[] myIntsArray = { 1, 2, 3, 4 };

// HAS BEEN CONVERTED FROM ARRAY TO ENUMERABLE
var myIntsEnumerable = myIntsArray.Select(n => n);
MyConsole.Print(myIntsEnumerable);

// CAN CONVERT BACK TO ARRAY
var backToArray = myIntsEnumerable.ToArray();
MyConsole.Print(myIntsEnumerable);

// CAN COVERT TO LIST
var listOFNumbers = myIntsEnumerable.ToList();
MyConsole.Print(myIntsEnumerable);


// CONVERT BUYERS TO SUPPLIERS
var buyersToSuppliers = people.OfType<Buyer>().ToList().ConvertAll(b => new Supplier { Age = b.Age });

foreach(var item in buyersToSuppliers) {
    Console.Write($"{ item.Age }, ");
}
Console.WriteLine();


var buyersToSuppliers2 = (from p in people
                          where p is Buyer
                          let b = p as Buyer
                          // some complicated query
                          select new Supplier() {
                              Age = b.Age
                          }).ToArray();

foreach (var item in buyersToSuppliers2) {
    Console.Write($"{item.Age}, ");
}
Console.WriteLine();

// ORDERING, BE SURE TO USE OrderBy, ThenBy

var buyers = people.OfType<Buyer>();

var orderedbuyers = buyers.OrderByDescending(b => b.Age).OrderByDescending(b => b.Height);

foreach (var item in orderedbuyers) {
    Console.WriteLine($"Age: { item.Age }, Height { item.Height }");
}

















internal class Person {

}

internal class Buyer : Person {
    public int Age { get; set; }
    public int ID { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
}

internal class Supplier : Person {
    public int Age { get; set; }
}
