using System;
using System.IO;
using System.Collections.Generic;

namespace U4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("sample.txt");  
  
        foreach (string line in lines)  
          controlLine(line);
        }

        static async String controlLine(String input){
            Stack<char> stack = new Stack<char>();
           
         

            for(int i = 0; i < input.Length; i++){
                switch(input[i]){
                    case '{' :
                    case '(' :
                    case '[' :
                    case '<' :  
                    stack.Push(input[i]);
                    break;


                    case '}' :
                    if(stack.Peek()  == '{' ){

                    }

                    break;

                    case ')' :
                    break;

                    case '>' :
                    break;

                    case ']':
                    break;
                }
            }
            return "richtig";
            
        }
    }
}
