using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Adder a = new Adder();
            a.OnMultipleOffiveReached += a_MultipleOffiveReached;
            int iAnswer = a.Add(4,3);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            iAnswer = a.Add(14, 6);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            Console.ReadKey();
        }
        
        static void a_MultipleOffiveReached(object sender, MultipleOfFiveEventArgs e)
        {
            Console.WriteLine("The following numbers added together:{0},{1}" ,e.X, e.Y);
            Console.WriteLine("Multiple of five reached!{0}", e.Total);
        }
    }

    public class Adder
    {
        public event EventHandler<MultipleOfFiveEventArgs> OnMultipleOffiveReached;

        public int Add(int x, int y)
        {
            int iSum = x + y;
            if ((iSum % 5 == 0) && (OnMultipleOffiveReached != null))
            { OnMultipleOffiveReached(this, new MultipleOfFiveEventArgs(iSum, x, y)); }
            return iSum;
        }
    }

    public class MultipleOfFiveEventArgs : EventArgs
        {
        public MultipleOfFiveEventArgs (int iTotal, int ix, int iy)
        { Total = iTotal;
            X = ix;
            Y = iy;
        }
        public int Total { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
