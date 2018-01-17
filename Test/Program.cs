﻿using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args){
            for(int j = 25; j < 37; j++){
                C t = F.get(j);
                G.get(j, t);
                t.x.show();
                t.obj.show();
            }
        }
    }

    class A
    {
        public A()
        {
            Console.Write("D");
        }
        public virtual void show()
        {
            Console.Write("B");
        }
    }

    class B: A
    {
        public B()
        {
            Console.Write("A");
        }
        public override void show()
        {
            Console.Write("C");
        }
    }

    class C: B
    {
        public A obj = new B();
        public A x = new A();
        public C():base()
        {
            obj = new A();
            Console.Write("A");
        }
    }    

    class D: C
    {
        public D():base(){
            obj = new B();
            Console.Write("D");
            x = new A();
        }
    }

    class F
    {
        public static C get(int x)
        {
            C t;
            if( x % 5 <= 3){
                t = new D();
            }else t = new C();
            if(x % 8 <= 1){
                t.obj = new B();
            }
            if(x % 9 >= 3){
                t.x = new A();
            }
            return t;
        }
    }

    class G
    {
        public static void get(int x, C objC)
        {
            if( x*x*x % 3 <= 1){
                objC = new D();
            }
        }
    }
}