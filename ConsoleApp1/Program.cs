using System;
using System.Linq;
using HtmlAgilityPack;

namespace Coding.Challenge.Firstname.Lastname
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlDocument document2 = new HtmlDocument();
            document2.Load(@"C:\Users\hp\Template.txt");
            var script = document2.DocumentNode.Descendants()
                                         .Where(n => n.Name == "script")
                                         .First().InnerText;
            Console.WriteLine("discovered script tag:\n" + script);
            //not able to understand what need to be taken for the information provided in script tag???
            Car c = new Car(); 
            var title = document2.DocumentNode.SelectSingleNode("//title");
            if (title.InnerHtml.Contains("$"))

                Console.WriteLine("discovered title tag:\n" + c.Brand);
           
            var innertitle = document2.DocumentNode.SelectSingleNode("//body/h1");

            if (innertitle.InnerHtml.Contains("$"))
            {
                innertitle.Attributes["title"].Value = c.Brand;
                Console.WriteLine(" title :\n" + innertitle.Attributes["title"].Value);
                Console.WriteLine("discovered title tag:\n" + c.Brand);
            }

            if (c.IsEcoFriendly == true)
            {
                var node = document2.DocumentNode.SelectSingleNode("//body/h2");
                if (node.InnerHtml.Contains("$"))
                    Console.WriteLine("discovered fuel:\n" + c.Fuel);
                else
                {}
                //No need of rendering

            }
                var model = document2.DocumentNode.SelectSingleNode("//div");
                if(model.Attributes.Contains("data-repeat-model"))
                {
                    //iteration comes in here. 
                    foreach (string s in c.Models)
                        Console.WriteLine(s);
                }
             
                
            }

            }

    }

