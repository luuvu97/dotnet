using System;

namespace DelegateTest
{
    public delegate void Show();

    class C
    {
        public event Show show;
        public C(){

        }
        public virtual void Notify()
        {
            if(show != null){
                show();
            }
            Console.Write("D")
        }
    }

}
