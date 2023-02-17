using My_Utility;
using My_Class_Library;

List<Buyer> buyers = new List<Buyer>()
{
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "EarthIsFlat District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
};

List<Supplier> suppliers = new List<Supplier>()
{
                new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22 },
                new Supplier() { Name = "Charles", District = "Developers District", Age = 40 },
                new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35 },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 },
                new Supplier() { Name = "Johnny", District = "No Buyers Here District", Age = 30 }
};

// JOIN BY DISTRICT
// WANT TO FIND BUYERS AND SUPPLIERS WHO ARE IN THE SAME DISTRICT

var innerJoin = buyers.Join(suppliers, b => b.District, s => s.District, (b, s) => new {

    BuyerName = b.Name,
    SupplierName = s.Name,
    District = b.District

});

MyConsole.PrintLine(innerJoin);

// INNER JOIN BY COMPOSITE KEY 
// MATCH BY DISTRICT AND AGE
// NEED TO MAKE 2 NEW ANONYMOUS TO COMPARE

var compositeJoin = buyers.Join(suppliers,

    b => new { b.District, b.Age },
    s => new { s.District, s.Age },
    (b, s) => new {

        BuyerName = b.Name,
        SupplierName = s.Name,
        District = b.District,
        Age = b.Age

    });

foreach (var item in compositeJoin) {

    Console.WriteLine($"{item.SupplierName} & {item.BuyerName} are both {item.Age} years old and in the {item.District}");

}

Console.WriteLine();

// GROUP JOIN 
// WANT SUPPLIERS TO HAVE A GROUP OF BUYERS IN THEIR DISTRICT

var groupJoin = suppliers.GroupJoin(buyers,
    s => s.District, b => b.District,
    (s, buyersGroup) => new {

        s.Name,
        s.District,
        Buyers = buyersGroup.OrderBy(b => b.Name)

    });

foreach (var item in groupJoin) {

    Console.WriteLine($"Supplier: {item.Name}, District: {item.District}");

    foreach (var buyer in item.Buyers) {

        Console.WriteLine($"\tBuyer: {buyer.Name}");

    }

}

