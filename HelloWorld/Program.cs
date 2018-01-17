using System;

namespace HelloWorld
{
    class A
    {
        public A()
        {
            // Console.WriteLine("A");
        }
        public virtual void show(){
            Console.WriteLine("A");
        }
    }
    class B: A
    {
        private A x = new A();
        public B()
        {
            // Console.WriteLine("B");
        }
        public override void show(){
            Console.WriteLine("B");
        }
    }
    
    class Program
    {
        public static void test(ref A a)
        {
            a = new B();
        }

        static void Main(string[] args)
        {
            A x = new A();
            test(ref x);
            if(x is B){
                Console.WriteLine("B");
            }else{
                Console.WriteLine("A");
            }
            // x.show();
        }
    }
}
