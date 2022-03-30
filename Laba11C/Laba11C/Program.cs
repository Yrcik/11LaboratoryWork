using System;
using Laba10_1;
namespace Laba11C
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuArrayList menuList = new MenuArrayList();
            while (menuList.Exit)
            {
                menuList.PointMenu();
            }

            MenuStack<Persona> menuStack = new MenuStack<Persona>();
            while (menuStack.Exit)
            {
                menuStack.PointMenu();
            }
        }
    }
}
