namespace My_Class_Library;

public class YoungPerson {

    private string _firstName;
    private string _lastName;
    private int _age;

    public string FullName {

        get {

            return $"{ this._firstName } { this._lastName }";

        }

        set {

            var fullName = value;

            var fullNameArray = fullName.Split(" ");

            this._firstName = fullNameArray[0];

            this._lastName = fullNameArray[1];

        }

    }

    public int Age {

        get {

            return this._age;

        }

        set {

            this._age = value;

        }

    }

    public YoungPerson(string fullName, int age) {

        if (fullName.Split(" ").Length != 2) {

            throw new ArgumentException("You did not enter a first and a last name");

        }

        this.FullName = fullName;

        this.Age = age;

    }

}

