using System;
using System.Collections.Generic;

namespace Permute
{
    class Program
    {
        private int x;
        private List<Data> arr;
        int n;

        public Program(){
            x = 0;
            arr = new List<Data>();
            n = 0;
        }
        static void Main(string[] args)
        {
            if(args.Length == 0){
                Console.WriteLine("Not enough argument");
            }else{
                Program main = new Program();
                main.setX(Int32.Parse(args[0]));
                main.init();
                main.CountPermutation();
            }          

        }

        public void setX(int x){
            this.x = x;
        }

        public void init(){
            int y = x;
            int z;
            while(true){
                z = y % 10;
                if(this.findData(z) == null){
                    this.arr.Add(new Data(z, 1));
                }else{
                    this.findData(z).count++;
                }
                y = y / 10;
                if(y == 0)
                    break;
            }

            foreach (Data d in this.arr){
                n += d.count;
            }
        }

        public Data findData(int val){
            foreach(Data d in this.arr){
                if(d.val == val){
                    return d;
                }
            }
            return null;
        }

        public void CountPermutation(){
            int tmp = 1;
            foreach(Data d in this.arr){
                tmp *= fac(d.count);
            }
            Console.WriteLine($"{fac(this.n)/tmp}");
        }

        public int fac(int n){
            int sum = 1;
            for(int i = 1; i <= n; i++){
                sum *= i;
            }
            return sum;
        }
    }

    public class Data{
        public int val;
        public int count;

        public Data(){
            val = 0;
            count = 0;
        }

        public Data(int v, int c){
            val = v;
            count = c;
        }
    }
}
