using AutoFinder.DataMining.Domain;
using System.Data.SqlClient;
using System.Text;

namespace AutoFinder.DataMining.Infrastructure.Factories {
    internal class StatementFactory {
#region Delete Statements
#region MinableDealer
        public SqlCommand BuildDeleteMinableDealerCommand(string dealerId, SqlConnection connection) {
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

#region VehicleInformation
        public SqlCommand BuildDeleteVehicleInformationForDealerCommand(string dealerId, SqlConnection connection) {
            StringBuilder statementString = new StringBuilder();

            statementString.Append("DELETE FROM [Vehicles] ");
            statementString.Append("WHERE");
            statementString.Append("    [DealerId] = @VEHICLEDEALERID");

            SqlCommand command = new SqlCommand(statementString.ToString(), connection);
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@VEHICLEDEALERID", dealerId)
            });

            return command;
        }
#endregion
#endregion

#region Insert Statements
#region MinableDealer
        public SqlCommand BuildInsertMinableDealerCommand(MinableDealer dealer, SqlConnection connection) {
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
        
#region VehicleInformation
        public SqlCommand BuildInsertVehicleCommand(VehicleInformation vehicle, SqlConnection connection) {
            StringBuilder statementString = new StringBuilder();

            statementString.Append("INSERT INTO [Vehicles] (");
            statementString.Append("    [DealerId],");
            statementString.Append("    [Make],");
            statementString.Append("    [Model],");
            statementString.Append("    [Year],");
            statementString.Append("    [BodyStyle],");
            statementString.Append("    [DriveTrain],");
            statementString.Append("    [Engine],");
            statementString.Append("    [ExteriorColor],");
            statementString.Append("    [InteriorColor],");
            statementString.Append("    [Mileage],");
            statementString.Append("    [Price],");
            statementString.Append("    [Transmission],");
            statementString.Append("    [Trim],");
            statementString.Append("    [Vin],");
            statementString.Append("    [Condition],");
            statementString.Append("    [DetailUrl]");
            statementString.Append(") VALUES (");
            statementString.Append("    @VEHICLEDEALERID,");
            statementString.Append("    @VEHICLEMAKE,");
            statementString.Append("    @VEHICLEMODEL,");
            statementString.Append("    @VEHICLEYEAR,");
            statementString.Append("    @VEHICLEBODYSTYLE,");
            statementString.Append("    @VEHICLEDRIVETRAIN,");
            statementString.Append("    @VEHICLEENGINE,");
            statementString.Append("    @VEHICLEEXTERIORCOLOR,");
            statementString.Append("    @VEHICLEINTERIORCOLOR,");
            statementString.Append("    @VEHICLEMILEAGE,");
            statementString.Append("    @VEHICLEPRICE,");
            statementString.Append("    @VEHICLETRANSMISSION,");
            statementString.Append("    @VEHICLETRIM,");
            statementString.Append("    @VEHICLEVIN,");
            statementString.Append("    @VEHICLECONDITION,");
            statementString.Append("    @VEHICLEDETAILURL");
            statementString.Append(")");

            SqlCommand command = new SqlCommand(statementString.ToString(), connection);
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@VEHICLEDEALERID", vehicle.Dealer.DealerId),
                new SqlParameter("@VEHICLEMAKE", vehicle.Make),
                new SqlParameter("@VEHICLEMODEL", vehicle.Model),
                new SqlParameter("@VEHICLEYEAR", vehicle.Year),
                new SqlParameter("@VEHICLEBODYSTYLE", vehicle.BodyStyle),
                new SqlParameter("@VEHICLEDRIVETRAIN", vehicle.DriveTrain),
                new SqlParameter("@VEHICLEENGINE", vehicle.Engine),
                new SqlParameter("@VEHICLEEXTERIORCOLOR", vehicle.ExteriorColor),
                new SqlParameter("@VEHICLEINTERIORCOLOR", vehicle.InteriorColor),
                new SqlParameter("@VEHICLEMILEAGE", vehicle.Odometer),
                new SqlParameter("@VEHICLEPRICE", vehicle.Price),
                new SqlParameter("@VEHICLETRANSMISSION", vehicle.Transmission),
                new SqlParameter("@VEHICLETRIM", vehicle.Trim),
                new SqlParameter("@VEHICLEVIN", vehicle.Vin),
                new SqlParameter("@VEHICLECONDITION", vehicle.Condition.ToString()),
                new SqlParameter("@VEHICLEDETAILURL", vehicle.DetailUrl)
            });

            return command;
        }
#endregion
#endregion

#region Select Statements
#region MinableDealer
        public SqlCommand BuildSelectAllMinableDealersCommand(SqlConnection connection) {
            StringBuilder statementString = new StringBuilder();

            statementString.Append("SELECT");
            statementString.Append("    [DealerId] AS MINABLEDEALERID,");
            statementString.Append("    [DealerName] AS MINABLEDEALERNAME,");
            statementString.Append("    [DealerUrl] AS MINABLEDEALERURL,");
            statementString.Append("    [MiningClass] AS MINABLEDEALERMININGPAGETYPENAME ");
            statementString.Append("FROM [MinableDealers]");

            return new SqlCommand(statementString.ToString(), connection);
        }

        public SqlCommand BuildSelectMinableDealerCommand(string dealerId, SqlConnection connection) {
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
        public SqlCommand BuildUpdateMinableDealerCommand(MinableDealer dealer, SqlConnection connection) {
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