﻿using System.Collections.Generic;
using Waterworks.Filters;

namespace Waterworks
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pipeline<T> : IPipeline<T>
    {
        public IEnumerable<IFilter<T>> Filters { get; private set; }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="filters">Collection of filters to be processed.</param>
        public Pipeline(IEnumerable<IFilter<T>> filters)
        {
            Filters = filters;
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
                filter.Modify(ref data);
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
        public IEnumerable<IFilter<T, U>> Filters { get; private set; }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="filters">Collection of filters to be processed.</param>
        public Pipeline(IEnumerable<IFilter<T, U>> filters)
        {
            Filters = filters;
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
                filter.Modify(input, ref output);
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
