﻿using System;
using System.Collections.Generic;

namespace ReutersInterview
{
    class ReutersInterview
    {
        private  Random r = new Random();
        public static void Main(string[] args)
        {
            var myInterview = new ReutersInterview();
            myInterview.Question1();
            myInterview.Question2();
            myInterview.Question3();
        }


        #region Question1
        /* using bit operation to check the duplicated number, since we only can have at most 31 different numbers
         * int will be enough
         * can also use hashset to store every number and check duplicate,
         * time complexity will also be O(1) but need more space
         * 
         */
        public void Question1()
        {
            var arr = GetRandomWithDup();
            PrintArr(arr);
            if (CheckDuplicated(arr))
                Console.WriteLine("Has duplicated.");
            else
                Console.WriteLine("Doesn't have duplicated.");
            Console.WriteLine("Press enter to see result to next Question.");
            Console.ReadLine();
        }
        // for each number in the array, try to see the correspond bit in the bitMap
        // if the bit is 1, mean we have this number before, otherwise set this bit
        private bool CheckDuplicated(int[] arr)
        {
            int bitMap = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!BitOp(ref bitMap, arr[i]))
                {
                    return true;
                }
            }
            return false;
        }

        // array of unknown size and containing only integers between 0 to 30 
        public int[] GetRandomWithDup()
        {
            int length = r.Next() % 31;
            var arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = r.Next() % 31;
            }
            return arr;
        }

        // try to set ith bit to 1, if it is '1' already return false, means there is duplicate number
        public bool BitOp(ref int x, int index)
        {
            int k = 1;
            k = k<<index;
            if((k&x) == 0)
            {
                x = k | x;
                return true;
            }
            return false;
        }
        #endregion question1


        #region Question2
        public void Question2()
        {
            int[] randomarr;
            for (int i = 0; i < 10; i++)
            {
                randomarr = GetRandomArr(10);
                PrintArr(randomarr);
            }
            Console.WriteLine("Press enter to see result to next Question.");
            Console.ReadLine();
        }

        public int[] GetRandomArr(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = i; // initialization 
            }
            Shuffle(array);
            return array;

        }

        // this algorithm guarantees that each combanation has same probability 
        // more details can be found on <<Programming pearls>> Column 12
        private void Shuffle(int[] arr)
        {
            int len = arr.Length;
            for(int i=0;i<len;i++)
            {
                swapArr(arr, i, r.Next(i, len));
            }
        }

        private void swapArr(int[] arr,int x, int y)
        {
            int tmp = arr[x];
            arr[x] = arr[y];
            arr[y] = tmp;
        }

        private void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(" ,");
            }
            Console.WriteLine();
        }

        private void PrintList(List<string> arrList)
        {
            foreach (var arr in arrList)
            {
                Console.WriteLine(arr);
            }
            Console.WriteLine();
        }
        #endregion question2
        #region Question3
        public void Question3()
        {
            char[] arr = { 'a', 'b', 'c', 'd' };
            var arrList = GetPermutation(arr, 0);
            PrintList(arrList);
            Console.WriteLine(arrList.Count); // should be n! = 4! = 24
            Console.WriteLine("That is all.");
            Console.ReadLine();
        }

        private List<string> GetPermutation(char[] arr, int pos)
        {
            var list = new List<string>();
            if (arr.Length - pos == 0)
                return list;
            if (arr.Length - pos == 1)
            {
                list.Add(arr[pos].ToString());
                return list;
            }
            //Recusive call, get sub string
            var subList = GetPermutation(arr, pos + 1);

            foreach (var str in subList)
            {
                char c = arr[pos];
                for (int i = 0; i < str.Length + 1; i++)
                {
                    list.Add(str.Insert(i, c.ToString()));
                }
            }
            return list;
        }

        #endregion question3
    }
}
