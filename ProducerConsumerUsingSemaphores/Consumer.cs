﻿using System;
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
                int element = buffer.PopElementFromBuffer(consumerId);
                Thread.Sleep(700);
            }
        }
    }
}