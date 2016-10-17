using System.Collections.Generic;
using Waterworks.Filters;

namespace Waterworks
{
    public interface IPipeline<T>
    {
        IEnumerable<IFilter<T>> Filters { get; }

        bool Drip(ref T data, IFilter<T> filter);

        bool Flow(ref T data);
    }

    public interface IPipeline<T, U>
    {
        IEnumerable<IFilter<T, U>> Filters { get; }

        bool Drip(T input, ref U output, IFilter<T, U> filter);

        bool Flow(T input, ref U output);
    }
}