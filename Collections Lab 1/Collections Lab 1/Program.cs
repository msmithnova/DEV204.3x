using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myArrList = new ArrayList();
            myArrList.Add("First Item");
            myArrList.Add(3);
            myArrList.Add(4.5);
            foreach (object obj in myArrList)
            {
                Console.WriteLine(obj.ToString());
            }

            ArrayList myArrList2 = new ArrayList();
            myArrList2.Add("First Item");
            myArrList2.Add("Third Item");
            myArrList2.Add("Second Item");

            myArrList2.Sort();
            int itemIndex = myArrList2.IndexOf("Third Item");

            foreach (object obj in myArrList2)
            {
                Console.WriteLine(obj.ToString());
            }
            Console.WriteLine();
            Console.WriteLine($"Third Item is at index {itemIndex}.");
        }
    }
}
