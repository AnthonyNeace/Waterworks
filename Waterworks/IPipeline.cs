using System.Collections.Generic;
using Waterworks.Filters;

namespace Waterworks
{
    public interface IPipeline<T>
    {
        void Drain(IFilter<T> filter);

        void Drain(IEnumerable<IFilter<T>> filters);

        void Fill(IFilter<T> filter);

        void Fill(IEnumerable<IFilter<T>> filters);

        bool Drip(ref T data, IFilter<T> filter);

        bool Flow(ref T data);
    }

    public interface IPipeline<T, U>
    {
        void Drain(IFilter<T, U> filter);

        void Drain(IEnumerable<IFilter<T, U>> filters);

        void Fill(IFilter<T, U> filter);

        void Fill(IEnumerable<IFilter<T, U>> filters);

        bool Drip(T input, ref U output, IFilter<T, U> filter);

        bool Flow(T input, ref U output);
    }
}