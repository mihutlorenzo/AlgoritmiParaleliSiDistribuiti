using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerUsingSemaphores
{
    class Producer
    {
        private PCBuffer buffer;
        private Random rand;
        private int producerId;

        public Producer(PCBuffer buffer,int id)
        {
            this.buffer = buffer;
            rand = new Random();
            producerId = id;
        }

        public void Produce()
        {
            while (true)
            {
                int element = rand.Next();
                buffer.PushElementInBuffer(element);
                Console.WriteLine("Producer with id {producerId} produce element with value {element}");
                Thread.Sleep(1000);
            }
            
        }
    }
}
