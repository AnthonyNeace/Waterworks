using System.Collections.Generic;
using Waterworks.Filters;

namespace Waterworks
{
    public interface IPipeline<T>
    {
        IEnumerable<IProcessFilter<T>> Filters { get; }

        bool Drip(ref T data, IProcessFilter<T> filter);

        bool Flow(ref T data);
    }

    public interface IPipeline<T, U>
        where T : class
        where U : class
    {
        IEnumerable<IProcessFilter<T, U>> Filters { get; }

        bool Drip(T input, U output, IProcessFilter<T, U> filter);

        bool Flow(T input, U output);
    }
}