namespace Waterworks.Filters
{
    public interface IFilter<T>
    {
        bool Stop(T data);
    }

    public interface IFilter<T, U>
    {
        bool Stop(T input, U output);
    }
}
