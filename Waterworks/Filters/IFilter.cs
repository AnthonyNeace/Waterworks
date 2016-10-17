namespace Waterworks.Filters
{
    public interface IFilter<T>
    {
        bool CanModify(T data);

        void Modify(ref T data);

        bool Stop(T data);
    }

    public interface IFilter<T, U>
    {
        bool CanModify(T input, U output);

        void Modify(T input, ref U output);

        bool Stop(T input, U output);
    }
}
