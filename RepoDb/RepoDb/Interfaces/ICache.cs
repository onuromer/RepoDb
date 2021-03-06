﻿using System.Collections.Generic;

namespace RepoDb.Interfaces
{
    /// <summary>
    /// An interface used to mark the class to be a cacher for an object.
    /// </summary>
    public interface ICache : IEnumerable<CacheItem>
    {
        /// <summary>
        /// Adds a cache item value.
        /// </summary>
        /// <param name="key">The key to the cache.</param>
        /// <param name="value">The value of the cache.</param>
        /// <param name="expiration">The expiration in minutes of the cache item.</param>
        /// <param name="throwException">Throws an exception if the operation has failed to add an item.</param>
        void Add(string key, object value, int expiration = Constant.DefaultCacheItemExpirationInMinutes, bool throwException = true);

        /// <summary>
        /// Adds a cache item value.
        /// </summary>
        /// <param name="item">The cache item to be added in the collection.</param>
        /// <param name="throwException">Throws an exception if the operation has failed to add an item.</param>
        void Add(CacheItem item, bool throwException = true);

        /// <summary>
        /// Clears the collection of the cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Checks whether the key is present in the collection.
        /// </summary>
        /// <param name="key">The name of the key to be checked.</param>
        /// <returns>A boolean value that signifies the presence of the key from the collection.</returns>
        bool Contains(string key);

        /// <summary>
        /// Gets an object from the cache collection.
        /// </summary>
        /// <param name="key">The key of the cache object to be retrieved.</param>
        /// <returns>A cached item object from the cache collection based on the given key.</returns>
        /// <param name="throwException">Throws an exception if the item is not found.</param>
        CacheItem Get(string key, bool throwException = true);

        /// <summary>
        /// Removes the item from the cache collection.
        /// </summary>
        /// <param name="key">The key of the item to be removed from the cache collection.</param>
        /// <param name="throwException">Throws an exception if the operation has failed to remove an item.</param>
        void Remove(string key, bool throwException = true);
    }
}
