using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spave_Invaders_v0_01
{
    internal class UIController
    {
        public event EventHandler OnAPressed;
        public  event EventHandler OnDPressed;
        public  event EventHandler OnSpacebarPressed;

        public void ButtonPreassing()
        {
            ConsoleKeyInfo key; 
            while (true)
            {
                
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                    OnAPressed?.Invoke(this,new EventArgs());
                else if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow)
                    OnDPressed?.Invoke(this, new EventArgs());

                    OnSpacebarPressed?.Invoke(this, new EventArgs());
               
            }
        }
        


    }
}
