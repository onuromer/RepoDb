﻿using System;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepoDb
{
    /// <summary>
    /// A base object for all shared-based repositories.
    /// </summary>
    public partial class DbRepository<TDbConnection> : IDisposable
        where TDbConnection : DbConnection
    {
        #region MinAll<TEntity>

        /// <summary>
        /// Computes the min value of the target field.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data entity.</typeparam>
        /// <param name="field">The field to be minimized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>The min value of the target field.</returns>
        public object MinAll<TEntity>(Field field,
            string hints = null,
            IDbTransaction transaction = null)
            where TEntity : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.MinAll<TEntity>(field: field,
                    hints: hints,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            catch
            {
                // Throw back the error
                throw;
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Computes the min value of the target field.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data entity.</typeparam>
        /// <param name="field">The field to be minimized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>The min value of the target field.</returns>
        public object MinAll<TEntity>(Expression<Func<TEntity, object>> field,
            string hints = null,
            IDbTransaction transaction = null)
            where TEntity : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.MinAll<TEntity>(field: field,
                    hints: hints,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            catch
            {
                // Throw back the error
                throw;
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region MinAllAsync<TEntity>

        /// <summary>
        /// Computes the min value of the target field in an asynchronous way.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data entity.</typeparam>
        /// <param name="field">The field to be minimized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>The min value of the target field.</returns>
        public async Task<object> MinAllAsync<TEntity>(Field field,
            string hints = null,
            IDbTransaction transaction = null)
            where TEntity : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.MinAllAsync<TEntity>(field: field,
                    hints: hints,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            catch
            {
                // Throw back the error
                throw;
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Computes the min value of the target field in an asynchronous way.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data entity.</typeparam>
        /// <param name="field">The field to be minimized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>The min value of the target field.</returns>
        public async Task<object> MinAllAsync<TEntity>(Expression<Func<TEntity, object>> field,
            string hints = null,
            IDbTransaction transaction = null)
            where TEntity : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.MinAllAsync<TEntity>(field: field,
                    hints: hints,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            catch
            {
                // Throw back the error
                throw;
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region MinAll(TableName)

        /// <summary>
        /// Computes the min value of the target field.
        /// </summary>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="tableName">The name of the target table.</param>
        /// <param name="field">The field to be minimized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <returns>The min value of the target field.</returns>
        public object MinAll(string tableName,
            Field field,
            string hints = null,
            IDbTransaction transaction = null)
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.MinAll(tableName: tableName,
                    field: field,
                    hints: hints,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            catch
            {
                // Throw back the error
                throw;
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region MinAllAsync(TableName)

        /// <summary>
        /// Computes the min value of the target field in an asynchronous way.
        /// </summary>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="tableName">The name of the target table.</param>
        /// <param name="field">The field to be minimized.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <returns>The min value of the target field.</returns>
        public async Task<object> MinAllAsync(string tableName,
            Field field,
            string hints = null,
            IDbTransaction transaction = null)
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.MinAllAsync(tableName: tableName,
                    field: field,
                    hints: hints,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            catch
            {
                // Throw back the error
                throw;
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion
    }
}
