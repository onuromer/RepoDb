﻿using System;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepoDb
{
    /// <summary>
    /// A base object for all entity-based repositories.
    /// </summary>
    public abstract partial class BaseRepository<TEntity, TDbConnection> : IDisposable
    {
        #region SumAll<TEntity>

        /// <summary>
        /// Computes the sum value of the target field.
        /// </summary>
        /// <param name="field">The field to be summarized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>The sum value of the target field.</returns>
        public object SumAll(Field field,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.SumAll<TEntity>(field: field,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Computes the sum value of the target field.
        /// </summary>
        /// <param name="field">The field to be summarized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>The sum value of the target field.</returns>
        public object SumAll(Expression<Func<TEntity, object>> field,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.SumAll<TEntity>(field: field,
                hints: hints,
                transaction: transaction);
        }

        #endregion

        #region SumAllAsync<TEntity>

        /// <summary>
        /// Computes the sum value of the target field in an asynchronous way.
        /// </summary>
        /// <param name="field">The field to be summarized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>The sum value of the target field.</returns>
        public Task<object> SumAllAsync(Field field,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.SumAllAsync<TEntity>(field: field,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Computes the sum value of the target field in an asynchronous way.
        /// </summary>
        /// <param name="field">The field to be summarized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>The sum value of the target field.</returns>
        public Task<object> SumAllAsync(Expression<Func<TEntity, object>> field,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.SumAllAsync<TEntity>(field: field,
                hints: hints,
                transaction: transaction);
        }

        #endregion
    }
}
