using System;
using System.Collections.Generic;
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
            var Headnode = document2.DocumentNode.SelectSingleNode("//head");
            foreach (var nNode in Headnode.Descendants())
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                   string value= Checkcondition(nNode, c);
                    Console.WriteLine(nNode.Name);
                    Console.WriteLine(value);
                }

            }

            var Bodynode = document2.DocumentNode.SelectSingleNode("//body");
            foreach (var nNode in Bodynode.Descendants())
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                   string value= Checkcondition(nNode, c);
                    Console.WriteLine(nNode.Name);
                    Console.WriteLine(value);
                }

            }
        }

           
        public static string GetPropValue(object src, string propName)
        {
            string prop = propName.Remove(0, propName.IndexOf('.') + 1).TrimEnd('}');
            return Convert.ToString(src.GetType().GetProperty(prop).GetValue(src, null));
            

        }

        public static string Checkcondition(HtmlNode node, object src)
        {

            if (node.Attributes.Contains("data-cond"))
            {
                string value = GetPropValue(src, node.Attributes.ToList().FirstOrDefault().Value);
                if (value == "True")
                {
                    if (node.InnerHtml.Contains("$"))
                    {
                        string title = GetPropValue(src, node.InnerHtml);
                        return Convert.ToString(title);
                    }
                }

            }

            else if (node.Attributes.Contains("data-repeat-model"))
            {
                // List<Car> lstRecords = new List<Car>();
                int value = GetPropValue(src, node.Attributes.ToList().FirstOrDefault().Value).ToList().Count();
                Console.WriteLine(value);
                //if (node.InnerHtml.Contains("$"))
                //{
                //    string title = GetPropValue(src, node.InnerHtml);
                //    return Convert.ToString(title);
                //}               
                
            }
            else if (node.InnerHtml.Contains("$"))
            {
                string value = GetPropValue(src, node.InnerHtml);
                return Convert.ToString(value);
            }
            return "noValue";
        }

        }

    
    }

