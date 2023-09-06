using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        private int size;
        private int bufSize;
        private readonly int defBufSize = 2;
        public int Count
        {
            get { return size; }
        }
        public int Capacity
        {
            get { return bufSize; }
        }
        public int this[int index]
        {
            get => bufArray[index]; 
        }
        public IntArrayList()
        {
            bufArray = new int[defBufSize];
            bufSize = defBufSize;
        }
        public IntArrayList(int Size)
        {
            bufArray = new int[Size];
            bufSize = Size;
        }
        void PushBack(int value)
        {
            if(bufArray.Length<size)
            {
                bufArray[size-1] = value;
                size++;
            }
            else
            {
                bufSize = bufSize * 2;
                int[] buf = new int[bufSize];
                foreach(int i in bufArray)
                {
                    buf[i] = bufArray[i];
                }
                bufArray[size-1]=value;
                size++;
                bufArray = buf;
            }
        }
        void PopBack()
        {
            if(size!=0)
            {
                bufArray[size] = 0;
            }
        }
        bool TryInsert(int index, int value)
        {
            if(index - 1 <= bufSize&&index >= 0)
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
            if (index - 1 <= bufSize || index >= 0)
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
            if (index - 1 <= bufSize || index >= 0)
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
            size = 0;
            foreach (int i in bufArray)
            {
                bufArray[i] = 0;
            }
        }
        public bool TryForceCapacity(int newCapacity)
        {

        }
    }
}
