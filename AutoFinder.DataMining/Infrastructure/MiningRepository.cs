using AutoFinder.DataMining.Domain;
using AutoFinder.DataMining.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AutoFinder.DataMining.Infrastructure {
    internal class MiningRepository : Interfaces.IMiningRepository {
#region Private Members
        private const string CONNECTION_STRING = 
            "Server=camellia.arvixe.com;" +
            "Database=SAAutoFinder_Dev;" +
            "User Id=JRehkop87;" +
            "Password=athlon2500";

        private SqlConnection _dbConnection;
        private ObjectFactory _objectFactory;
        private StatementFactory _statementFactory;
#endregion

#region Properties

#endregion

#region Public Methods
        public MiningRepository() {
            this._dbConnection = new SqlConnection(MiningRepository.CONNECTION_STRING);
            this._objectFactory = new ObjectFactory();
            this._statementFactory = new StatementFactory();
        }

#region Interface Methods
#region Minable Dealers
        public void AddNewMinableDealer(MinableDealer dealer) {
            try {
                this._dbConnection.Open();

                SqlCommand command = this._statementFactory.BuildInsertMinableDealerStatement(
                    dealer,
                    this._dbConnection
                );

                if (command.ExecuteNonQuery() != 1) {
                    throw new Exception(string.Empty);
                }
            }
            catch (Exception ex) {
                throw;
            }
            finally {
                this._dbConnection.Close();
            }
        }

        public List<MinableDealer> GetAllMinableDealers() {
            try {
                this._dbConnection.Open();

                SqlCommand command = this._statementFactory.BuildSelectAllMinableDealersStatement(
                    this._dbConnection
                );

                return this._objectFactory.BuildMinableDealerCollectionFromDataReader(
                    command.ExecuteReader()
                );
            }
            catch (Exception ex) {
                throw;
            }
            finally {
                this._dbConnection.Close();
            }
        }

        public MinableDealer GetMinableDealer(string dealerId) {
            try {
                this._dbConnection.Open();

                SqlCommand command = this._statementFactory.BuildSelectMinableDealerStatement(
                    dealerId,
                    this._dbConnection
                );

                List<MinableDealer> dealerList = this._objectFactory.BuildMinableDealerCollectionFromDataReader(
                    command.ExecuteReader()
                );

                MinableDealer dealer = null;
                if (dealerList.Count == 1) {
                    dealer = dealerList[0];
                }
                else if (dealerList.Count > 1) {
                    // TODO: Throw exception
                }

                return dealer;
            }
            catch (Exception ex) {
                throw;
            }
            finally {
                this._dbConnection.Close();
            }
        }

        public void RemoveMinableDealer(string dealerId) {
            try {
                this._dbConnection.Open();

                SqlCommand command = this._statementFactory.BuildDeleteMinableDealerStatement(
                    dealerId,
                    this._dbConnection
                );

                if (command.ExecuteNonQuery() != 1) {
                    throw new Exception(string.Empty);
                }
            }
            catch (Exception ex) {
                throw;
            }
            finally {
                this._dbConnection.Close();
            }
        }

        public void UpdateMinableDealer(MinableDealer dealer) {
            try {
                this._dbConnection.Open();

                SqlCommand command = this._statementFactory.BuildUpdateMinableDealerStatement(
                    dealer,
                    this._dbConnection
                );

                if (command.ExecuteNonQuery() != 1) {
                    throw new Exception(string.Empty);
                }
            }
            catch (Exception ex) {
                throw;
            }
            finally {
                this._dbConnection.Close();
            }
        }
#endregion
#endregion
#endregion
    }
}