using System;
using System.Collections.Generic;

class Person
{
    public int personId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string favoriteColour { get; set; }
    public int age { get; set; }
    public bool isWorking { get; set; }

    public void DisplayPersonInfo()
    {
        Console.WriteLine("Name: " + firstName + " " + lastName);
        Console.WriteLine("PersonId: " + personId);
        Console.WriteLine(firstName + "'s favorite color is: " + favoriteColour);
    }

    public void ChangeFavoriteColour()
    {
        favoriteColour = "White";
    }

    public int GetAgeInTenYears()
    {
        return age + 10;
    }

    public override string ToString()
    {
        return "PersonId: " + personId + "\n" +
               "FirstName: " + firstName + "\n" +
               "LastName: " + lastName + "\n" +
               "FavoriteColour: " + favoriteColour + "\n" +
               "Age: " + age + "\n" +
               "IsWorking: " + isWorking;
    }
}

class Relation
{
    public string RelationshipType { get; set; }

    public void ShowRelationShip(Person person1, Person person2)
    {
        Console.WriteLine("Relationship between " + person1.firstName + " and " + person2.firstName + " is: " + RelationshipType);
    }
}

class MainClass
{
    static void Main(string[] args)
    {
        Person person1 = new Person
        {
            personId = 1,
            firstName = "Ian",
            lastName = "Brooks",
            favoriteColour = "Red",
            age = 30,
            isWorking = true
        };

        Person person2 = new Person
        {
            personId = 2,
            firstName = "Gina",
            lastName = "James",
            favoriteColour = "Green",
            age = 18,
            isWorking = false
        };

        Person person3 = new Person
        {
            personId = 3,
            firstName = "Mike",
            lastName = "Briscoe",
            favoriteColour = "Blue",
            age = 45,
            isWorking = true
        };

        Person person4 = new Person
        {
            personId = 4,
            firstName = "Mary",
            lastName = "Beals",
            favoriteColour = "Yellow",
            age = 28,
            isWorking = true
        };

        Console.WriteLine(person2.personId + ": " + person2.firstName + " " + person2.lastName + "'s favorite colour is " + person2.favoriteColour);

        Console.WriteLine(person3.ToString());

        person1.ChangeFavoriteColour();
        Console.WriteLine(person1.personId + ": " + person1.firstName + " " + person1.lastName + "'s favorite colour is: " + person1.favoriteColour);

        int maryAgeInTenYears = person4.GetAgeInTenYears();
        Console.WriteLine(person4.firstName + " " + person4.lastName + "'s Age in 10 years is: " + maryAgeInTenYears);

        Relation relation1 = new Relation
        {
            RelationshipType = "Sisterhood"
        };

        Relation relation2 = new Relation
        {
            RelationshipType = "Brotherhood"
        };

        relation1.ShowRelationShip(person2, person4);
        relation2.ShowRelationShip(person1, person3);

        List<Person> peopleList = new List<Person>();
        peopleList.Add(person1);
        peopleList.Add(person2);
        peopleList.Add(person3);
        peopleList.Add(person4);

        double averageAge = CalculateAverageAge(peopleList);
        Console.WriteLine("Average age is: " + averageAge);

        Person youngestPerson = GetYoungestPerson(peopleList);
        Console.WriteLine("The youngest person is: " + youngestPerson.firstName);

        Person oldestPerson = GetOldestPerson(peopleList);
        Console.WriteLine("The oldest person is: " + oldestPerson.firstName);

        List<Person> peopleWithFirstNameM = GetPeopleWithFirstNameM(peopleList);
        Console.WriteLine("People whose first names start with M:");
        foreach (Person person in peopleWithFirstNameM)
        {
            Console.WriteLine(person.ToString());
        }

        Person personWithFavoriteColourBlue = GetPersonWithFavoriteColour(peopleList, "Blue");
        Console.WriteLine("Person who likes the color blue:");
        Console.WriteLine(personWithFavoriteColourBlue.ToString());
    }

    static double CalculateAverageAge(List<Person> peopleList)
    {
        int totalAge = 0;
        foreach (Person person in peopleList)
        {
            totalAge += person.age;
        }
        return (double)totalAge / peopleList.Count;
    }

    static Person GetYoungestPerson(List<Person> peopleList)
    {
        Person youngestPerson = peopleList[0];
        foreach (Person person in peopleList)
        {
            if (person.age < youngestPerson.age)
            {
                youngestPerson = person;
            }
        }
        return youngestPerson;
    }

    static Person GetOldestPerson(List<Person> peopleList)
    {
        Person oldestPerson = peopleList[0];
        foreach (Person person in peopleList)
        {
            if (person.age > oldestPerson.age)
            {
                oldestPerson = person;
            }
        }
        return oldestPerson;
    }

    static List<Person> GetPeopleWithFirstNameM(List<Person> peopleList)
    {
        List<Person> peopleWithFirstNameM = new List<Person>();
        foreach (Person person in peopleList)
        {
            if (person.firstName.StartsWith("M"))
            {
                peopleWithFirstNameM.Add(person);
            }
        }
        return peopleWithFirstNameM;
    }

    static Person GetPersonWithFavoriteColour(List<Person> peopleList, string color)
    {
        foreach (Person person in peopleList)
        {
            if (person.favoriteColour.ToLower() == color.ToLower())
            {
                return person;
            }
        }
        return null;
    }
}
