using System;
using System.Collections.Generic;

namespace U5
{
    class Person : IComparable<Person>
    {

        public string Firstname{get; set;}

        public string Lastname{get; set;}

        public DateTime Birthdate{get; set;}

       
        public int CompareTo(Person obj)
        { 
            if(obj.Birthdate == null){
                return 1;
            } 
              return Birthdate.CompareTo(obj.Birthdate);
        
          
        }

        
    }
}