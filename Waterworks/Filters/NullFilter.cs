namespace Waterworks.Filters
{
    public class NullFilter<T> : IFilter<T>
    {
        public virtual bool Stop(T data)
        {
            return false;
        }  
    }

    public class NullFilter<T, U> : IFilter<T, U>
    {
        public virtual bool Stop(T input, U output)
        {
            return false;
        }
    }
}
