using System;
using System.Threading;

namespace ProducerConsumerUsingSemaphores
{
    public class PCBuffer
    {
        private Mutex bufferMutex;
        private Mutex producerMutex;
        private Mutex consumerMutex;
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
            bufferMutex = new Mutex();
            producerMutex = new Mutex();
            consumerMutex = new Mutex();
            rand = new Random();
        }

        public int PopElementFromBuffer(int consumerId)
        {
            int element = 0;
            consumerMutex.WaitOne();
            if (noElementsInBuffer > 0)
            {

                element = buffer[bufferHead % buffer.Length];
                Console.WriteLine("Consumer {2} pop from buffer the element with value {0} and index {1}", element, bufferHead, consumerId);
                bufferHead++;
                Decrement();
                Console.WriteLine(noElementsInBuffer);

            }
            consumerMutex.ReleaseMutex();
            return element;
        }

        public void PushElementInBuffer(int id)
        {
            producerMutex.WaitOne();
            if (noElementsInBuffer < buffer.Length)
            {
                int element = rand.Next(1, 100);
                buffer[bufferTail % buffer.Length] = element;
                Console.WriteLine("Producer {2} push in buffer the element with value {0} and index {1} ", element, bufferTail,id);
                bufferTail++;
                Increment();
                Console.WriteLine(noElementsInBuffer);

            }
            producerMutex.ReleaseMutex();

        }

        public void Increment()
        {
            bufferMutex.WaitOne();
            noElementsInBuffer++;
            bufferMutex.ReleaseMutex();
        }

        public void Decrement()
        {
            bufferMutex.WaitOne();
            noElementsInBuffer--;
            bufferMutex.ReleaseMutex();
        }
    }
}