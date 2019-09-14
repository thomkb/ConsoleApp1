using System;
using System.Reflection;

//namespace ConsoleApp1
//{
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

delegate int NumberChanger(int n);
namespace DelegateAppl
{
    class TestDelegate
    {
        private static int num = 10;

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }
        static void Main(string[] args)
        {
            //create delegate instances
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);

            nc = nc1;
            nc += nc2;

            //calling multicast
            nc(4);
            Console.WriteLine("Value of Num: {0}", getNum());
            Console.ReadKey();
        }
    }
}