using AutoFinder.DataMining.Domain;
using System.Collections.Generic;

namespace AutoFinder.DataMining.Infrastructure.Interfaces {
    public interface IMiningRepository {
#region Minable Dealers
        void AddNewMinableDealer(MinableDealer dealer);
        List<MinableDealer> GetAllMinableDealers();
        MinableDealer GetMinableDealer(string dealerId);
        void RemoveMinableDealer(string dealerId);
        void UpdateMinableDealer(MinableDealer dealer);
#endregion
    }
}