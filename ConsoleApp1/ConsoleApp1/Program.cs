using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class IntArrayList
    {
        private int[] bufArray;
        private int stored;
        private int bufSize;
        private readonly int defBufSize = 2;
        public int Count
        {
            get { return bufSize; }
        }
        public int Capacity
        {
            get { return bufArray.Length; }
        }
        public int this[int index]
        {
            get => bufArray[index]; 
        }
        public IntArrayList()
        {
            bufArray = new int[defBufSize];
            bufSize = defBufSize;
            stored = 0;
        }
        public IntArrayList(int Size)
        {
            bufArray = new int[Size];
            bufSize = Size;
            stored = 0;
        }
        void PushBack(int value)
        {
            if(Capacity<=stored)
            {

                int[] newArr = new int[Capacity*2];
                for (int i = 0; i < bufArray.Length; i++)
                {
                    newArr[i] = bufArray[i];
                }
                bufArray = newArr;
            }
            bufArray[stored - 1] = value;
            stored++;
        }
        void PopBack()
        {
            if(stored==0)
            {
                return;
            }

            bufArray[stored] = 0;
            stored--;
        }
        bool TryInsert(int index, int value)
        {
            if(index - 1 <= Count&&index >= 0)
            {
                bufArray[index - 1] = value;   
                return true;
            }
            else
            {
                return false;
            }
        }
        bool TryErase(int index)
        {
            if (index - 1 <= Count || index >= 0)
            {
                bufArray[index] = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        bool TryGetAt(int index, out int result)
        {
            if (index - 1 <= Count || index >= 0)
            {
                result = bufArray[index];
                return true;  
            }
            else
            {
                result = 0; 
                return false;
            }
        }
        public void Clear()
        {
            stored = 0;
            bufArray = new int[defBufSize];
        }
        public bool TryForceCapacity(int newCapacity)
        {
            if (newCapacity < 0)
            {
                return false;
            }
            int[] newArr = new int[newCapacity];
            for (int i = 0; i < Capacity; i++)
            {
                newArr[i] = bufArray[i];
            }
            bufArray = newArr;

            return true;
        }
        public int Find(int value)
        {
            for (int i = 0; i < stored; i++)
            {
                if (bufArray[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
