using Ch_0_Class_Library;

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

var innerJoin = from b in buyers
                join s in suppliers
                on b.District equals s.District
                orderby s.District
                select new {

                    SupplierName = s.Name,
                    BuyerName = b.Name,
                    District = b.District
                };

foreach (var item in innerJoin) {

    Console.WriteLine(item);

}


Console.WriteLine();

// INNER JOIN BY COMPOSITE KEY 
// MATCH BY DISTRICT AND AGE
// NEED TO MAKE 2 NEW ANONYMOUS TO COMPARE

var compositeJoin = from b in buyers
                   join s in suppliers
                   on new {b.District, b.Age} equals new {s.District, s.Age}
                   select new {
                       Supplier = s,
                       BuyerName = b.Name,
                   };

foreach (var item in compositeJoin) {

    Console.WriteLine($"{item.Supplier.Name} & {item.BuyerName} are both {item.Supplier.Age} years old and in the {item.Supplier.District}");

}

Console.WriteLine();

// GROUP JOIN 
// WANT SUPPLIERS TO HAVE A GROUP OF BUYERS IN THEIR DISTRICT

var groupJoin = from s in suppliers
                join b in buyers on s.District equals b.District into buyersGroup
                orderby s.District
                select new {

                    s.Name,
                    s.District,
                    Buyers = buyersGroup

                };

foreach (var item in groupJoin) {

    Console.WriteLine($"Supplier: {item.Name}, District: {item.District}");

    foreach (var buyer in item.Buyers) {

        Console.WriteLine($"\tBuyer: {buyer.Name}");

    }

}

Console.WriteLine();

// GROUP INNER JOIN
var innerGroupJoin = from s in suppliers
                join b in buyers on s.District equals b.District into buyersGroup
                orderby s.District
                select new {

                    s.Name,
                    s.District,
                    // buyers group is IEnumerable so you can do another query for a group inner join
                    Buyers = from b in buyersGroup
                             select b

                };

foreach (var item in innerGroupJoin) {

    Console.WriteLine($"Supplier: {item.Name}, District: {item.District}");

    foreach (var buyer in item.Buyers) {

        Console.WriteLine($"\tBuyer: {buyer.Name}");

    }

}

Console.WriteLine();

// LEFT OUTER JOIN
// IF A SUPPLIER HAS NO DISTRICT CAN ASSIGN A DEFAULT VALUE FOR A BUYER
var leftOuterJoin = from s in suppliers
                     join b in buyers on s.District equals b.District into buyersGroup
                     select buyersGroup.DefaultIfEmpty(
                         new Buyer() {

                             Name = "No one here",
                             District = "I don't exist"
                         });

foreach (var item in leftOuterJoin) {

    foreach (var buyer in item) {

        Console.WriteLine($"{buyer.District} {buyer.Name}");
    }


}