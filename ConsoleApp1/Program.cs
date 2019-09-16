using System;
using System.Reflection;

namespace ConsoleApp1
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //try
    //{
    //    int a = 0;
    //    Console.WriteLine("Hello World, dammit!");
    //    int x = 1 / a;
    //}
    //catch(Exception ex)
    //{
    //    Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} ERROR: {ex}");
    //}
    //finally
    //{
    //    Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} has ended.");
    //}

    //namespace DelegateAppl
    //{

    //    class TestDelegate
    //    {
    //        private delegate int NumberChanger(int n);
    //        private static int num = 10;

    //        public static int AddNum(int p)
    //        {
    //            num += p;
    //            return num;
    //        }
    //        public static int MultNum(int q)
    //        {
    //            num *= q;
    //            return num;
    //        }
    //        public static int getNum()
    //        {
    //            return num;
    //        }
    //        static void Main(string[] args)
    //        {
    //            //create delegate instances
    //            NumberChanger nc;
    //            NumberChanger nc1 = new NumberChanger(AddNum);
    //            NumberChanger nc2 = new NumberChanger(MultNum);

    //            nc = nc1;
    //            nc += nc2;

    //            //calling multicast
    //            nc(5);
    //            Console.WriteLine("Value of Num: {0}", getNum());
    //            Console.ReadKey();
    //        }
    //    }
    //}

    public class ConsoleApp1
    {
        public static void Main()
        {
            Number myNumber = new Number(1200222.22f);
            myNumber.PrintMoney();
            myNumber.PrintNumber();
        }
    }

    public class PrintHelper
    {
        // declare delegate 
        public delegate void BeforePrint();

        //declare event of type delegate
        public event BeforePrint beforePrintEvent;

        public PrintHelper()
        {
        }

        public void PrintNumber(float num)
        {
            //call delegate method before going to print
            if (beforePrintEvent != null)
            {
                beforePrintEvent();
            }

            Console.WriteLine("Number: {0,-12:0}", num);
        }

        public void PrintDecimal(float dec)
        {
            if (beforePrintEvent != null)
            {
                beforePrintEvent();
            }

            Console.WriteLine("Decimal: {0:F}", dec);
        }

        public void PrintMoney(float money)
        {
            if (beforePrintEvent != null)
            {
                beforePrintEvent();
            }

            Console.WriteLine("Money: {0:C}", money);
        }

        public void PrintTemperature(float num)
        {
            if (beforePrintEvent != null)
            {
                beforePrintEvent();
            }

            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }

        public void PrintHexadecimal(float dec)
        {
            if (beforePrintEvent != null)
            {
                beforePrintEvent();
            }

            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }

    class Number
    {
        private PrintHelper _printHelper;

        public Number(float val)
        {
            Value = val;

            _printHelper = new PrintHelper();
            //subscribe to beforePrintEvent event
            _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
        }
        //beforePrintevent handler
        void printHelper_beforePrintEvent()
        {
            Console.WriteLine("BeforPrintEventHandler: PrintHelper is going to print a value");
        }

        //private float _value;

        public float Value { get; set; }

        public void PrintMoney()
        {
            _printHelper.PrintMoney(Value);
        }
        public void PrintNumber()
        {
            _printHelper.PrintNumber(Value);
        }
    }


        // Abstract/Virtual example
    //    abstract class Car
    //{
    //    public virtual void speed()
    //    {
    //        Console.WriteLine("120 kmph");
    //    }
    //    //Force derived classes to implement
    //    public abstract void mileage();
    //}

    //class Zen : Car
    //{
    //        // This function implementation is optional and 
    //        //depend upon need if a derived class want to 
    //        //implement it or else base class implementaion will be used.
    //        //public override void speed()
    //        //{
    //        //    Console.WriteLine("Zen Speed:70 kmph");
    //        //}

    //        //This class must implement this function.
    //        public override void mileage()
    //    {
    //        Console.WriteLine("Zen mileage:1200cc");
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Car c = new Zen();
    //        c.speed();
    //        c.mileage();
    //    }
    //}
}