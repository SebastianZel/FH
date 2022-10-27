using System;
using System.Collections.Generic;

namespace U5
{
    class Program
    {
         static void Main(string[] args)
        {
            TestInsert();
            TestDelete();
        }

        static void TestDelete()
        {
            AvlTree<Person> tree = new();
            List<Person> insertedNumbers = new();
            Random r = new();

            while (insertedNumbers.Count <= 500)
            {
                 Person p = new Person();
               p.Birthdate.AddDays(r.Next(28));
               p.Birthdate.AddMonths(r.Next(12));
               p.Birthdate.AddYears(r.Next(1950,2030));
               tree.Insert(p);
                insertedNumbers.Add(p);
            }

            AvlTreeChecker<Person>.Check(tree);

            int counter = 0;
            while (counter <= 40)
            {
                var number = insertedNumbers[r.Next(insertedNumbers.Count - 1)];
                var node = tree.Search(number);

                tree.Delete(node);
                insertedNumbers.Remove(number);
                AvlTreeChecker<Person>.Check(tree);

                counter++;
            }
        }

        static void TestInsert()
        {
            AvlTree<Person> tree = new();

            Random r = new();

            int counter = 0;
             while (counter <= 10000)
            {
                 Person p = new Person();
               p.Birthdate.AddDays(r.Next(28));
               p.Birthdate.AddMonths(r.Next(12));
               p.Birthdate.AddYears(r.Next(1950,2030));
               tree.Insert(p);
               counter++;
            }

            AvlTreeChecker<Person>.Check(tree);
        }
    }
}
