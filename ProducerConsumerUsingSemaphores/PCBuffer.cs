using System;
using System.Threading;

namespace ProducerConsumerUsingSemaphores
{
    internal class PCBuffer
    {
        Semaphore pushProduceInBuffer;
        Semaphore popProductFromBuffer;
        int[] elements;

        private int bufferHead, bufferTail;

        public PCBuffer(int bufferSize)
        {
            pushProduceInBuffer = new Semaphore(bufferSize - 1, bufferSize);
            popProductFromBuffer = new Semaphore(bufferSize - 1, bufferSize);
            elements = new int[bufferSize + 1];
            bufferHead = 0;
            bufferTail = 0;
        }

        internal int PopElementFromBuffer()
        {
            
            popProductFromBuffer.WaitOne();
            int element = elements[bufferHead % elements.Length];
            Console.WriteLine("Consumer pop from buffer the element with value {0} and index {1}", element, bufferHead);
            bufferHead++;
            pushProduceInBuffer.Release();
            return element;
        }

        internal void PushElementInBuffer(int element)
        {
            pushProduceInBuffer.WaitOne();
            elements[bufferTail%elements.Length] = element;
            Console.WriteLine("Producer push in buffer the element with value {0} and index {1} " , element,bufferTail);
            bufferTail++;
            popProductFromBuffer.Release();
        }
    }
}