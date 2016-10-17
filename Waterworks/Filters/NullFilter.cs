namespace Waterworks.Filters
{
    public class NullFilter<T> : IFilter<T>
    {
        public virtual bool CanModify(T data)
        {
            return true;
        }

        public virtual void Modify(ref T data)
        {
            
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

        public virtual void Modify(T input, ref U output)
        {

        }

        public virtual bool Stop(T input, U output)
        {
            return false;
        }
    }
}
