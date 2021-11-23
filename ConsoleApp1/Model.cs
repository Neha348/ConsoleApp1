using System;
using System.Collections.Generic;
using System.Text;


namespace Coding.Challenge.Firstname.Lastname
{

    public class Car
    {
        public string Brand
        {
            get;
            set;
        } = "Mercedes Benz";
        public bool IsEcoFriendly { get; set; } = true;
        public string Fuel { get; set; } = "Hybrid";

        public List<string> Models { get; set; } = new List<string>()
        {
            "Hello",
  "Hello2",
  "Hello3"
        };
       
       
        //public static Car Lookup(string id)
        //{
        // return id;
        //}
    }
}
    

