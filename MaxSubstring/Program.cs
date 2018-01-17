using System;

namespace HelloWorld
{
    class Program
    {
        public int getMaxSubstring(String X, String Y){
            String[] arrX = X.Split(" ");
            String[] arrY = Y.Split(" ");
            int lengthX = arrX.Length;
            int lengthY = arrY.Length;
            int[,] M = new int[lengthX + 1,lengthY + 1];
            for(int i = 1; i <= lengthX; i++){
                for(int j = 1; j <= lengthY; j++){
                    if(arrX[i - 1].Equals(arrY[j - 1])){
                        M[i,j] = M[i-1,j-1] + 1;
                    }else{
                        M[i,j] = M[i,j-1] > M[i-1,j] ? M[i,j-1] : M[i-1,j];
                    }
                }
            }
            return M[lengthX,lengthY];
        }
        static void Main(string[] args)
        {
            String vbg = "I have a black cat I name it Salem I love it";
            String inp = "I name black it Salem I love this dog";
            Program prg = new Program();
            int n = prg.getMaxSubstring(vbg, inp);
            Console.WriteLine($"{n}");
        }
    }
}
