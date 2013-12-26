using AutoFinder.DataMining.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AutoFinder.DataMining.Infrastructure.Factories {
    internal class ObjectFactory {
#region MinableDealer
        public List<MinableDealer> BuildMinableDealerCollectionFromDataReader(SqlDataReader reader) {
            try {
                List<MinableDealer> objList = new List<MinableDealer>();
                while (reader.Read()) {
                    objList.Add(this.BuildMinableDealerObjectFromDataReader(reader));
                }
                return objList;
            }
            catch (Exception ex) {
                throw;
            }
        }

        private MinableDealer BuildMinableDealerObjectFromDataReader(SqlDataReader reader) {
            try {
                string dealerId = (string)reader["MINABLEDEALERID"];
                string dealerName = (string)reader["MINABLEDEALERNAME"];
                string dealerUrl = (string)reader["MINABLEDEALERURL"];
                string miningPageTypeName = (string)reader["MINABLEDEALERMININGPAGETYPENAME"];

                return new MinableDealer(
                    dealerId, dealerName, dealerUrl, miningPageTypeName
                );
            }
            catch (Exception ex) {
                throw;
            }
        }
#endregion
    }
}