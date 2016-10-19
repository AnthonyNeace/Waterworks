using System.Linq;
using System.Collections.Generic;
using Waterworks.Filters;

namespace Waterworks
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pipeline<T> : IPipeline<T>
    {
        protected List<IFilter<T>> Filters { get; private set; }

        /// <summary>
        /// Public constructor.
        /// </summary>
        public Pipeline()
        {
            Filters = new List<IFilter<T>>();
        }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="filters">Collection of filters to be processed.</param>
        public Pipeline(IEnumerable<IFilter<T>> filters)
        {
            Filters = filters.ToList();
        }

        /// <summary>
        /// Remove a single filter from the Filters collection.
        /// </summary>
        /// <param name="filter"></param>
        public void Drain(IFilter<T> filter)
        {
            Filters.Remove(filter);
        }

        /// <summary>
        /// Remove many filters from the Filters collection.
        /// </summary>
        /// <param name="filter"></param>
        public void Drain(IEnumerable<IFilter<T>> filters)
        {
            foreach (var filter in filters)
            {
                Drain(filter);
            }
        }

        /// <summary>
        /// Add a single filter to the Filters collection.
        /// </summary>
        /// <param name="filter"></param>
        public void Fill(IFilter<T> filter)
        {
            Filters.Add(filter);
        }

        /// <summary>
        /// Add many filters to the Filters collection.
        /// </summary>
        /// <param name="filter"></param>
        public void Fill(IEnumerable<IFilter<T>> filters)
        {
            Filters.AddRange(filters);
        }

        /// <summary>
        /// Process a single filter, with support for skipping filter or stopping completely.
        /// </summary>
        /// <param name="data">Container for data to be processed.</param>
        /// <returns>Returns true when filter is processed, false when flow is interrupted.</returns>
        public bool Drip(ref T data, IFilter<T> filter)
        {
            if(filter == null)
            {
                return true;
            }

            if (filter.Stop(data))
            {
                return false;
            }

            if (filter.CanModify(data))
            {
                data = filter.Modify(data);
            }

            return true;
        }

        /// <summary>
        /// Process the collection of filters, with support for skipping individual filters or stopping completely.
        /// </summary>
        /// <param name="data">Container for data to be processed.</param>
        /// <returns>Returns true when all filters processed, false when flow is interrupted.</returns>
        public bool Flow(ref T data)
        {
            if (Filters != null)
            {
                foreach (var filter in Filters)
                {
                    if(!Drip(ref data, filter))
                    {
                        return false;
                    }
                };
            }

            return true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class Pipeline<T, U> : IPipeline<T, U>
    {
        protected List<IFilter<T, U>> Filters { get; private set; }

        /// <summary>
        /// Public constructor.
        /// </summary>
        public Pipeline()
        {
            Filters = new List<IFilter<T, U>>();
        }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="filters">Collection of filters to be processed.</param>
        public Pipeline(IEnumerable<IFilter<T, U>> filters)
        {
            Filters = filters.ToList();
        }

        /// <summary>
        /// Remove a single filter from the Filters collection.
        /// </summary>
        /// <param name="filter"></param>
        public void Drain(IFilter<T, U> filter)
        {
            Filters.Remove(filter);
        }

        /// <summary>
        /// Remove many filters from the Filters collection.
        /// </summary>
        /// <param name="filter"></param>
        public void Drain(IEnumerable<IFilter<T, U>> filters)
        {
            foreach (var filter in filters)
            {
                Drain(filter);
            }
        }

        /// <summary>
        /// Add a single filter to the Filters collection.
        /// </summary>
        /// <param name="filter"></param>
        public void Fill(IFilter<T, U> filter)
        {
            Filters.Add(filter);
        }

        /// <summary>
        /// Add many filters to the Filters collection.
        /// </summary>
        /// <param name="filter"></param>
        public void Fill(IEnumerable<IFilter<T, U>> filters)
        {
            Filters.AddRange(filters);
        }

        /// <summary>
        /// Handle a single filter, with support for skipping filter or stopping completely.
        /// </summary>
        /// <param name="data">Container for data to be processed.</param>
        /// <returns>Returns true when filter is processed, false when flow is interrupted.</returns>
        public bool Drip(T input, ref U output, IFilter<T, U> filter)
        {
            if (filter == null)
            {
                return true;
            }

            if (filter.Stop(input, output))
            {
                return false;
            }

            if (filter.CanModify(input, output))
            {
                output = filter.Modify(input, output);
            }

            return true;
        }

        /// <summary>
        /// Iterates the given collection of filters, with options to skip over filters or stop as desired.
        /// </summary>
        /// <param name="input">Input (example: an API request container)</param>
        /// <param name="output">Output (example: an API response container)</param>
        /// <returns>Returns true when all filters processed, false when flow is interrupted.</returns>
        public bool Flow(T input, ref U output)
        {
            if (Filters != null)
            {
                foreach (var filter in Filters)
                {
                    if (!Drip(input, ref output, filter))
                    {
                        return false;
                    }
                };
            }

            return true;
        }
    }
}
