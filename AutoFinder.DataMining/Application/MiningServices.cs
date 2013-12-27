using AutoFinder.DataMining.Domain;
using AutoFinder.DataMining.Infrastructure;
using AutoFinder.DataMining.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace AutoFinder.DataMining.Application {
    public class MiningServices {
#region Private Members
        private IMiningRepository _repository;
#endregion

#region Public Methods
#region Constructor(s)
        /// <summary>
        /// Initializes a new instance of the MiningServices class
        /// </summary>
        public MiningServices() : this(new MiningRepository()) {

        }

        /// <summary>
        /// Initializes a new instance of the MiningServices class
        /// </summary>
        /// <param name="repository">Data repository object to be used</param>
        internal MiningServices(IMiningRepository repository) {
            this._repository = repository;
        }
#endregion

#region Service Methods
#region MinableDealer Methods
        public void AddMinableDealer(string dealerName, string dealerUrl, string miningPageTypeName) {
            this._repository.AddMinableDealer(
                new MinableDealer(
                    this.GenerateGuid(),
                    dealerName,
                    dealerUrl,
                    miningPageTypeName
                )
            );
        }

        public List<MinableDealer> GetAllMinableDealers() {
            return this._repository.GetAllMinableDealers();
        }

        public MinableDealer GetMinableDealer(string dealerId) {
            return this._repository.GetMinableDealer(dealerId);
        }

        public void RemoveMinableDealer(MinableDealer dealer) {
            this._repository.RemoveMinableDealer(dealer.DealerId);
        }

        public void UpdateMinableDealer(MinableDealer dealer) {
            this._repository.UpdateMinableDealer(dealer);
        }
#endregion

#region VehicleInformation Methods
        public void AddVehicleInformation(List<VehicleInformation> vehicles) {
            this._repository.AddVehicleInformation(vehicles);
        }

        public void RemoveVehicleInformationForDealer(DealerInformation dealer) {
            this._repository.RemoveVehicleInformationForDealer(dealer);
        }
#endregion
#endregion
#endregion

        #region Private Methods
        private string GenerateGuid() {
            return System.Guid.NewGuid().ToString().ToUpper();
        }
#endregion
    }
}