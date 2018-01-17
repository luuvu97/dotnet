﻿using System;
using System.Collections.Generic;

namespace CompactString
{
    public struct pair{
        public String key;
        public String shortKey;

        public pair(String key, String shortKey){
            this.key = key;
            this.shortKey = shortKey;
        }
    }
    public class Program
    {
        public static List<pair> defineList = new List<pair>();
        public static void initDefineList()
        {
            defineList.Add(new pair("did not", "didn't"));
            defineList.Add(new pair("are not", "aren't"));
            defineList.Add(new pair("is not", "isn't"));
            defineList.Add(new pair("can not", "can't"));
            defineList.Add(new pair("could not", "couldn't"));
            defineList.Add(new pair("has not", "hasn't"));
            defineList.Add(new pair("had not", "hadn't"));
            defineList.Add(new pair("have not", "haven't"));
            defineList.Add(new pair("must not", "mustn't"));
            defineList.Add(new pair("shall not", "shan't"));
            defineList.Add(new pair("should not", "shouldn't"));
            defineList.Add(new pair("was not", "wasn't"));
            defineList.Add(new pair("were not", "weren't"));
            defineList.Add(new pair("will not", "won't"));
            defineList.Add(new pair("would not", "wouldn't"));
            defineList.Add(new pair("might not", "mightn't"));
            defineList.Add(new pair("may not", "mayn't"));
            defineList.Add(new pair("i am", "i'm"));
        }
        static void Main(string[] args)
        {
            while(true){
                Console.WriteLine("Input a string:");
                initDefineList();
                String str = Console.ReadLine();
                descryption(str);
            }
        }

        public static String parse(String str)
        {
            foreach(pair node in defineList){
                if(node.shortKey.Equals(str)){
                    return node.key;
                }
            }
            return str;
        }

        public static String descryption(String str)
        {
            String[] arr = str.Split(' ');
            for(int i = 0; i < arr.Length; i++){
                arr[i] = parse(arr[i].ToLower());
            }
            String outStr = String.Join(" ", arr);
            Console.WriteLine(outStr);
            return outStr;
        }
    }
}