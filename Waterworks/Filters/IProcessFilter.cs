namespace Waterworks.Filters
{
    public interface IProcessFilter<T> : IFilter<T>
    {
        bool CanProcess(T data);

        T Process(T data);
    }

    public interface IProcessFilter<T, U> : IFilter<T, U>
    {
        bool CanProcess(T input, U output);

        void Process(T input, U output);
    }
}
