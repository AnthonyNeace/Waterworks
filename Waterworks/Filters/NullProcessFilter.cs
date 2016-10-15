namespace Waterworks.Filters
{
    public class NullProcessFilter<T> : NullFilter<T>, IProcessFilter<T>
    {
        public virtual bool CanProcess(T data)
        {
            return true;
        }

        public virtual void Process(T data)
        {

        }
    }

    public class NullProcessFilter<T, U> : NullFilter<T, U>, IProcessFilter<T, U>
    {
        public virtual bool CanProcess(T input, U output)
        {
            return true;
        }

        public virtual void Process(T input, U output)
        {

        }
    }
}
