using AutoFinder.DataMining.Domain;
using System.Collections.Generic;

namespace AutoFinder.DataMining.Domain.Interfaces {
    public interface IMiningPage {
#region Properties
        List<VehicleInformation> MinedVehicles { get; }
#endregion

#region Methods
        void Mine();
        void Mine(string html);
#endregion
    }
}