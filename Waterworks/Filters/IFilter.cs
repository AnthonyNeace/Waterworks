namespace Waterworks.Filters
{
    public interface IFilter<T>
    {
        bool CanModify(T data);

        T Modify(T data);

        bool Stop(T data);
    }

    public interface IFilter<T, U>
    {
        bool CanModify(T input, U output);

        U Modify(T input, U output);

        bool Stop(T input, U output);
    }
}
