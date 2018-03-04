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
        private int producerId;

        public Producer(PCBuffer buffer,int id)
        {
            this.buffer = buffer;
            
            producerId = id;
        }

        public void Produce()
        {
            while (true)
            {
                
                buffer.PushElementInBuffer(producerId);
                Thread.Sleep(1000);
            }
            
        }
    }
}
