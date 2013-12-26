using AutoFinder.DataMining.Domain;
using System.Data.SqlClient;
using System.Text;

namespace AutoFinder.DataMining.Infrastructure.Factories {
    internal class StatementFactory {
#region Delete Statements
#region MinableDealer
        public SqlCommand BuildDeleteMinableDealerStatement(string dealerId, SqlConnection connection) {
            StringBuilder statementString = new StringBuilder();

            statementString.Append("DELETE FROM [MinableDealers] ");
            statementString.Append("WHERE");
            statementString.Append("    [DealerId] = @MINABLEDEALERID");

            SqlCommand command = new SqlCommand(statementString.ToString(), connection);
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@MINABLEDEALERID", dealerId)
            });

            return command;
        }
#endregion
#endregion

#region Insert Statements
#region MinableDealer
        public SqlCommand BuildInsertMinableDealerStatement(MinableDealer dealer, SqlConnection connection) {
            StringBuilder statementString = new StringBuilder();

            statementString.Append("INSERT INTO [MinableDealers] (");
            statementString.Append("    [DealerId],");
            statementString.Append("    [DealerName],");
            statementString.Append("    [DealerUrl],");
            statementString.Append("    [MiningClass]");
            statementString.Append(") VALUES (");
            statementString.Append("    @MINABLEDEALERID,");
            statementString.Append("    @MINABLEDEALERNAME,");
            statementString.Append("    @MINABLEDEALERURL,");
            statementString.Append("    @MINABLEDEALERMININGPAGETYPENAME");
            statementString.Append(")");

            SqlCommand command = new SqlCommand(statementString.ToString(), connection);
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@MINABLEDEALERID", dealer.DealerId),
                new SqlParameter("@MINABLEDEALERNAME", dealer.DealerName),
                new SqlParameter("@MINABLEDEALERURL", dealer.DealerUrl),
                new SqlParameter("@MINABLEDEALERMININGPAGETYPENAME", dealer.MiningPageTypeName)
            });

            return command;
        }
#endregion
#endregion

#region Select Statements
#region MinableDealer
        public SqlCommand BuildSelectAllMinableDealersStatement(SqlConnection connection) {
            StringBuilder statementString = new StringBuilder();

            statementString.Append("SELECT");
            statementString.Append("    [DealerId] AS MINABLEDEALERID,");
            statementString.Append("    [DealerName] AS MINABLEDEALERNAME,");
            statementString.Append("    [DealerUrl] AS MINABLEDEALERURL,");
            statementString.Append("    [MiningClass] AS MINABLEDEALERMININGPAGETYPENAME ");
            statementString.Append("FROM [MinableDealers]");

            return new SqlCommand(statementString.ToString(), connection);
        }

        public SqlCommand BuildSelectMinableDealerStatement(string dealerId, SqlConnection connection) {
            StringBuilder statementString = new StringBuilder();

            statementString.Append("SELECT");
            statementString.Append("    [DealerId] AS MINABLEDEALERID,");
            statementString.Append("    [DealerName] AS MINABLEDEALERNAME,");
            statementString.Append("    [DealerUrl] AS MINABLEDEALERURL,");
            statementString.Append("    [MiningClass] AS MINABLEDEALERMININGPAGETYPENAME ");
            statementString.Append("FROM [MinableDealers] ");
            statementString.Append("WHERE");
            statementString.Append("    [DealerId] = @MINABLEDEALERID");

            SqlCommand command = new SqlCommand(statementString.ToString(), connection);
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@MINABLEDEALERID", dealerId),
            });

            return command;
        }
#endregion
#endregion

#region Update Statements
#region MinableDealer
        public SqlCommand BuildUpdateMinableDealerStatement(MinableDealer dealer, SqlConnection connection) {
            StringBuilder statementString = new StringBuilder();

            statementString.Append("UPDATE [MinableDealers] ");
            statementString.Append("SET");
            statementString.Append("    [DealerName] = @MINABLEDEALERNAME,");
            statementString.Append("    [DealerUrl] = @MINABLEDEALERURL,");
            statementString.Append("    [MiningClass] = @MINABLEDEALERMININGPAGETYPENAME ");
            statementString.Append("WHERE");
            statementString.Append("    [DealerId] = @MINABLEDEALERID");

            SqlCommand command = new SqlCommand(statementString.ToString(), connection);
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@MINABLEDEALERNAME", dealer.DealerName),
                new SqlParameter("@MINABLEDEALERURL", dealer.DealerUrl),
                new SqlParameter("@MINABLEDEALERMININGPAGETYPENAME", dealer.MiningPageTypeName),
                new SqlParameter("@MINABLEDEALERID", dealer.DealerId)
            });

            return command;
        }
#endregion
#endregion
    }
}