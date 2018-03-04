using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerUsingSemaphores
{
    class Program
    {
        static void Main(string[] args)
        {
            PCBuffer buffer = new PCBuffer(20);
            Producer producer = new Producer(buffer,1);
            Consumer consumer = new Consumer(buffer,1);
            Thread threadProducers = new Thread(producer.Produce);
            Thread threadConsumers = new Thread(consumer.Consume);

            threadProducers.Start();
            threadConsumers.Start();

            threadProducers.Join();
            threadConsumers.Join();
        }
    }
}
