using System;
using System.Threading;

namespace ProducerConsumerUsingSemaphores
{
    internal class Consumer
    {
        private PCBuffer buffer;
        private int consumerId;

        public Consumer(PCBuffer buffer,int id)
        {
            this.buffer = buffer;
            this.consumerId = id;
        }

        public void Consume()
        {
            while (true)
            {
                int element = buffer.PopElementFromBuffer();
                Console.WriteLine("Consumer with id {consumerId} consume element with element {element}");
                Thread.Sleep(11000);
            }
        }
    }
}