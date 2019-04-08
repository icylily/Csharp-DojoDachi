using System;

namespace Dojodachi.Models
{
    public class MyModel
    {
       
    }
    public class DojoDachi
    {
        public int Happiness{get;set;}
        public int Fullness{get;set;}

        public int Energy{get;set;}
        public int Meals{get;set;}

        public DojoDachi()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
        }

    }
}