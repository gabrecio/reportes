using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace ERP.Reports.Api.Interfaces.Repository
{
    public interface IUnitOfWork<TDbConnection> : IDisposable
    {
        TDbConnection Connection { get; }
        DbTransaction Transaction { get; }
        void Begin();
        void Rollback();
        void Commit();
    }

    public interface IUnitOfWork : IUnitOfWork<SqlConnection>
    {
    }
}