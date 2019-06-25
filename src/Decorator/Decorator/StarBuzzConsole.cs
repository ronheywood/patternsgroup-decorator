using System;

namespace StarBuzz
{
    public class StarBuzzConsole : IStarBuzzConsole
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public string ReadKey()
        {
            return Console.ReadKey().ToString();
        }
    }
}