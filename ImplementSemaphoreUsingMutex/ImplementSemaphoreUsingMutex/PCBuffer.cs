using ImplementSemaphoreUsingMutex;
using System;


namespace ProducerConsumerUsingSemaphores
{
    public class PCBuffer
    {

        private Semaphore semaProd;
        private Semaphore semaCons;
        private int[] buffer;
        private int bufferHead, bufferTail;
        private volatile int noElementsInBuffer;
        private Random rand;

        public PCBuffer(int bufferSize)
        {
            buffer = new int[bufferSize];
            bufferHead = 0;
            bufferTail = 0;
            noElementsInBuffer = 0;
            semaProd = new Semaphore(bufferSize);
            semaCons = new Semaphore();
            rand = new Random();
        }

        public int PopElementFromBuffer(int consumerId)
        {
            int element = 0;

            semaCons.Aquire();
            element = buffer[bufferHead % buffer.Length];
            Console.WriteLine("Consumer {2} pop from buffer the element with value {0} and index {1}", element, bufferHead, consumerId);
            bufferHead++;

            Console.WriteLine(noElementsInBuffer);
            semaProd.Release();


            return element;
        }

        public void PushElementInBuffer(int id)
        {

            semaProd.Aquire();
            int element = rand.Next(1, 100);
            buffer[bufferTail % buffer.Length] = element;
            Console.WriteLine("Producer {2} push in buffer the element with value {0} and index {1} ", element, bufferTail, id);
            bufferTail++;

            Console.WriteLine(noElementsInBuffer);

            semaCons.Release();


        }


    }
}