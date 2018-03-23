# Backend-Csharp-i6ao2-2018
Bookstore Project voor backend C#

# afgehandeld
- Product attributen, propperty, constructor af
- Measurement attributen, propperty, constructor af
- Book attributen, propperty, constructor af
- Magazine attributen, propperty, constructor af
- Order attributen, propperty, constructor af
- OrdeItems attributen, propperty, constructor af
- Bookstore attributen, propperty, constructor af

# To do list
- methodes maken
- commentaar toevoegen door middel van gost doc
- test data toevoegen aan de hand van een methode zie voorbeeld hieronder:

       public static List<Animal> GetTestData()
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog("Hero", 25, 6));
            animals.Add(new Pig("Pandi", 60, 5, Gender.Female));
            animals.Add(new Chicken("Meenachi", 25, 15, Gender.Male));
            animals.Add(new Horse("mr. Ed", 350, 18));
            Animal ed1 = new Horse("Papi", 180, 3);
            animals.Add(ed1);

            return animals;
        }
        

