using CSharpFunctionalExtensions;
using Dapper;
using ERP.Reports.Api.Interfaces.Repository;
using ERP.Reports.Api.Models.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Repository
{
    public class ReportRepository : BaseRepository, IReportRepository
    {
        public ReportRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<DataSet> GetReportData(ReportView report, Dictionary<string, object> parameters)
        {
            var param = new DynamicParameters();

            foreach (var p in parameters)
            {
                if (p.Value is DataTable)
                    param.Add(name: p.Key, value: p.Value ?? (object)DBNull.Value, dbType: DbType.Object);
                else if (p.Value is JArray)
                {
                    var dataTable = JsonConvert.DeserializeObject<DataTable>(p.Value.ToString());
                    param.Add(name: p.Key, value: dataTable ?? (object)DBNull.Value, dbType: DbType.Object);
                }
                else
                    param.Add(name: p.Key, value: p.Value);
            }

            var alias = report.ReportAliases
                .OrderBy(x => x.Sequence)
                .Select(x => x.Name)
                .ToList();


            var result = await UnitOfWork.Connection.ExecuteReaderAsync(report.StoreProcedure, param: param, transaction: UnitOfWork.Transaction, commandType: CommandType.StoredProcedure, commandTimeout: this.UnitOfWork.Connection.ConnectionTimeout);
            var ds = new DataSet();
            ds.Load(reader: result, loadOption: LoadOption.OverwriteChanges, alias.ToArray());

            for (int i = 0; i < alias.Count; i++)
            {
                var dt = ds.Tables[i];
                dt.TableName = alias[i];
                this.AssignDefaultColumnTypes(dt);
            }

            return ds;
        }
        public async Task<Maybe<ReportView>> GetReport(int organizationId, string reportId)
        {
            var report = await UnitOfWork.Connection.QueryMultipleAsync("dbo.GetReport", param: new { OrganizationId = organizationId, ReportId = reportId }, transaction: UnitOfWork.Transaction, commandType: CommandType.StoredProcedure, commandTimeout: this.UnitOfWork.Connection.ConnectionTimeout);
            return await Map(report);
        }

        private async Task<Maybe<ReportView>> Map(SqlMapper.GridReader report)
        {
            Maybe<ReportView> maybeReportView = await report.ReadSingleOrDefaultAsync<ReportView>();
            if (maybeReportView.HasNoValue)
                return maybeReportView;

            maybeReportView.Value.Initialize(await report.ReadAsync<ReportCustomizationView>()
                , await report.ReadAsync<ReportAliasView>()
                , await report.ReadAsync<ReportEntityPrinterView>());
            return maybeReportView;
        }

        private void AssignDefaultColumnTypes(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                return;

            foreach (DataColumn c in dt.Columns)
            {
                c.ReadOnly = false;
                c.Unique = false;

                var typeCode = Type.GetTypeCode(c.DataType);

                if (c.AutoIncrement)
                    continue;

                switch (typeCode)
                {
                    case TypeCode.Boolean:
                        c.DefaultValue = false;
                        break;

                    case TypeCode.DateTime:
                        c.DefaultValue = DateTime.MinValue;
                        break;

                    case TypeCode.String:
                    case TypeCode.Char:
                        c.DefaultValue = "-";
                        break;

                    case TypeCode.Byte:
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.SByte:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        c.DefaultValue = 0;
                        break;

                    case TypeCode.DBNull:
                    case TypeCode.Empty:
                    case TypeCode.Object:
                    default:
                        break;
                }
            }

            dt.Rows.Add(dt.NewRow());
        }
    }
}