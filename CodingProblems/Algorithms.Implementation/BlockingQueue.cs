using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Algorithms.Implementation
{

    ///some stuff on threading
    ///Mutex is a locking mechanism to protect a critical section
    ///     It is a key to a toliler, one person can have the key - occupy the toilet. When finished the person gives the key to the
    ///     next person
    ///     Mutexes are typically used to seiralize access to a section of re-entrant code that cannot be executed concurrently by
    ///     mode than one thread. A mutext object only allows one thread into a controlled section, forcing other threads which
    ///     attempt to gain access to that section to wait until first thread has exited from that section
    ///Semaphore is a locking mechanism to protect a critical section upto certain number of concurrent threads
    ///     There are x number of toilets and keys. If the semaphore count is set to 4, that means there are 4 toilets and 4 keys. As
    ///     people are coming in, this value is decreased. If all toilets are full (count of 0), noone can get in until one person
    ///     leaves the toilet in which case the count is incremented to 1
    ///     A semaphore restricts the number of simultaneous users of a shared resource up to a maximum number. Threads can request
    ///     access to the resource (decrementing the semaphore), and can signal that they have finished using the resource (incrementing
    ///     the semaphore)


    /// <summary>
    /// The typical usage for a blocking queue is a producer - consumer scenario in multi-threaded environment
    /// We want producer to wait if the queue is full, such that we don't queue too many jobs
    /// We want consumers to wait if the queue is empty, such that it can continue processing if queue becomes full
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BlockingQueue<T>
    {

        private readonly Queue<T> queue;
        private readonly int maxSize;

        public BlockingQueue(int maxSize)
        {
            this.maxSize = maxSize;
            this.queue = new Queue<T>();
        }

        public void Enqueue(T item)
        {
            // need to lock to make sure some queue properties do not change when some other threads accesses it
            lock (this.queue)
            {
                //if queue size is at the max, then cause producer to wait
                while (this.queue.Count == this.maxSize) {
                    //this releases the lock and causes thread to sleep until signaled
                    //this allows other thread to aquire lock on the queue....eg...while producer is blocked, 
                    //we want consumer to keep dequeuing the job
                    //when monitor is signaled, it will re-iterate the while loop checking for condition again
                    Monitor.Wait(this.queue);
                }

                //if there is a space
                this.queue.Enqueue(item);

                //let other thread go at the queue...since pulse will wake up one thread, there is no guarantee that it's
                //a consumer thread, thus we wake up all and have separate while (check) to re-block producers
                Monitor.PulseAll(this.queue);
            }
        }

        public T Dequeue()
        {
            lock (this.queue)
            {
                //if queue size is at 0, cause consumers to wait
                while (this.queue.Count == 0)
                {
                    Monitor.Wait(this.queue);
                }

                T item = this.queue.Dequeue();

                //let other thread go at the queue
                Monitor.PulseAll(this.queue);

                return item;
            }
        }

    }
}
