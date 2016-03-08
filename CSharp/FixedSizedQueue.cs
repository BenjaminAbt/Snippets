public class FixedSizedQueue<T>
{
     public FixedSizedQueue(int limit)
     {
         Limit = limit;
     }
     
     private ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();

     private volatile int _limit;
     public int Limit
     {
        get { return _limit; }
        set { _limit = value; }
     }
     
     private object _lockMe = new object();
     
     public void Enqueue(T obj)
     {
        _queue.Enqueue(obj);
        lock (_lockMe)
        {
           T overflow;
           while (_queue.Count > Limit && _queue.TryDequeue(out overflow)) ;
        }
     }
}
