using System;

namespace VATExample
{
    class Program
    {
        static void Main(string[] args)
        {
            String str = "Toi la VN    D:v";
            S s = new S();
            for(int i = 0; i < str.Length; i++){
                Console.WriteLine();
                Console.WriteLine($"{str[i]}");
                s = s.get(str[i]);
                s.show();
            }
            s.show();
        }
    }

    class S
    {
        public virtual S get(char c)
        {
            if(c == 'V'){
                return new S1();
            }
            return new S6();
        }

        public virtual void show(){
            Console.WriteLine("S - NO");
        }
    }

    class S1 : S
    {
        public override S get(char c)
        {
            if(c == 'N'){
                return new S2();
            }
            return new S6();
        }

        public override void show(){
            Console.WriteLine("S1 - NO");
        }
    }

    class S2 : S
    {
        public override S get(char c)
        {
            if(c == ' '){
                return new S3();
            }
            return new S6();
        }

        public override void show(){
            Console.WriteLine("S2 - NO");
        }
    }

    class S3 : S
    {
        public override S get(char c)
        {
            if(c == ' '){
                return this;
            }else if(c == 'D' || c == 'V'){
                return new S4();
            }
            return new S6();
        }

        public override void show(){
            Console.WriteLine("S3 - NO");
        }
    }

    class S4 : S
    {
        public override S get(char c)
        {
            if((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')){
                return new S6();
            }
            return new S5();
        }

        public override void show(){
            Console.WriteLine("S4 - Yes");
        }
    }

    class S5 : S4
    {
        public override S get(char c)
        {
            return this;
        }
    }

    class S6 : S
    {
        public override S get(char c)
        {
            if(c == ' '){
                return new S();
            }
            return this;
        }

        public override void show(){
            Console.WriteLine("S6 - NO");
        }
    }
}