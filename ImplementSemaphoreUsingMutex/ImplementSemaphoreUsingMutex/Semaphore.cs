using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImplementSemaphoreUsingMutex
{
    class Semaphore
    {
        private volatile int permits;
        private Mutex permitsMutex;
        private Mutex waitForPermit;

        public Semaphore(int nrOfPermits = 0)
        {
            permits = nrOfPermits;
            permitsMutex = new Mutex();
            waitForPermit = new Mutex();
        }


        public void Aquire()
        {
            permitsMutex.WaitOne();
            while(permits == 0)
            {
                waitForPermit.WaitOne();
            }
            permits--;
            permitsMutex.ReleaseMutex();
        }

        public void Release()
        {
            permitsMutex.WaitOne();
            if(permits == 0)
            {
                
                waitForPermit.ReleaseMutex();
            }
            permits++;
            permitsMutex.ReleaseMutex();
        }
    }

    
}
