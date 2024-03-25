using ERP.Reports.Api.Interfaces.Repository;
using ERP.Reports.Api.Models.Core;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace ERP.Reports.Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConnectionString _connectionString;
        private SqlConnection _connection;
        private DbTransaction _transaction;

        public SqlConnection Connection => EnsureConnection();

        public DbTransaction Transaction => _transaction;

        private SqlConnection EnsureConnection()
        {
            _connection = _connection ?? new SqlConnection(_connectionString.Connection);
            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();
            return _connection;
        }

        public UnitOfWork(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public void Begin()
        {
            if (_transaction != null)
                throw new InvalidOperationException("Cannot start a new transaction while the existing other one is still open.");
            _transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("There is no active transaction to commit.");
            }
            using (_transaction)
            {
                _transaction.Commit();
            }
            _transaction = null;
        }

        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("There is no active transaction to rollback.");
            }
            using (_transaction)
            {
                _transaction.Rollback();
            }
            _transaction = null;
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }

        public void Dispose()
        {
            //If throw error any SP rollback transaction
            if (_transaction != null)
                Rollback();
            if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
                _connection.Close();
            _connection?.Dispose();
        }
    }
}