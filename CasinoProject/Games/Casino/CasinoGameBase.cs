using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoProject.Games.Casino
{
    public abstract class CasinoGameBase
    {
        public event EventHandler? OnWin;
        public event EventHandler? OnLoose;
        public event EventHandler? OnDraw;


        protected CasinoGameBase()
        {
            FactoryMethod();
        }


        protected void OnWinInvoke()
        {
            OnWin?.Invoke(this, EventArgs.Empty);
        }

        protected void OnLooseInvoke()
        {
            OnLoose?.Invoke(this, EventArgs.Empty);
        }

        protected void OnDrawInvoke()
        {
            OnDraw?.Invoke(this, EventArgs.Empty);
        }

        public abstract void PlayGame();
        protected abstract void FactoryMethod();


        protected void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }





    }
}
