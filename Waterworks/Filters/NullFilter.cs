namespace Waterworks.Filters
{
    public abstract class NullFilter<T> : IFilter<T>
    {
        public virtual bool CanModify(T data)
        {
            return true;
        }

        public virtual T Modify(T data)
        {
            return data;
        }

        public virtual bool Stop(T data)
        {
            return false;
        }
    }

    public class NullFilter<T, U> : IFilter<T, U>
    {
        public virtual bool CanModify(T input, U output)
        {
            return true;
        }

        public virtual U Modify(T input, U output)
        {
            return output;
        }

        public virtual bool Stop(T input, U output)
        {
            return false;
        }
    }
}
