using System.Collections;

namespace My_Utility;

public class MyConsole {

    public static void Print(IEnumerable items) {

        foreach (var item in items) {

            Console.Write($"{item}, ");

        }

        Console.WriteLine();
    }

    public static void PrintLine(IEnumerable items) {

        foreach (var item in items) {

            Console.WriteLine($"{item}, ");

        }

        Console.WriteLine();
    }


}
