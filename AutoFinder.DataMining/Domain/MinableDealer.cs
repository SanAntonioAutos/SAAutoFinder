using AutoFinder.DataMining.Domain.Interfaces;
using System;

namespace AutoFinder.DataMining.Domain {
    public class MinableDealer : DealerInformation {
#region Private Members
        private string _dealerUrl;
        private string _miningPageTypeName;

        private IMiningPage _miningPage;
#endregion

#region Properties
        /// <summary>
        /// Url of the dealer inventory
        /// </summary>
        public string DealerUrl {
            get {
                return this._dealerUrl;
            }
        }

        /// <summary>
        /// IMiningPage instance used to parse this dealers website
        /// </summary>
        public IMiningPage MiningPage {
            get {
                return this._miningPage;
            }
        }

        /// <summary>
        /// This internal property is used for maintaining the database
        /// </summary>
        internal string MiningPageTypeName {
            get {
                return this._miningPageTypeName;
            }
        }
#endregion

#region Public Methods
#region Constructor(s)
        /// <summary>
        /// Initializes a new instance of the MinableDealer class
        /// </summary>
        /// <param name="copy">MinableDealer instance to copy</param>
        public MinableDealer(MinableDealer copy) : this(copy.DealerId, copy.DealerName, copy.DealerUrl, copy._miningPageTypeName) {

        }

        /// <summary>
        /// Initializes a new instance of the MinableDealer class
        /// </summary>
        /// <param name="dealerId">Unique assigned dealer id</param>
        /// <param name="dealerName">Name of the dealer that is mined</param>
        /// <param name="dealerUrl">Url of the dealer inventory</param>
        /// <param name="miningPageTypeName">TypeName of IMiningPage instance used to parse this dealers website</param>
        public MinableDealer(string dealerId, string dealerName, string dealerUrl, string miningPageTypeName) : base(dealerId, dealerName) {
            this._dealerUrl = string.Copy(dealerUrl);
            this._miningPageTypeName = string.Copy(miningPageTypeName);

            this._miningPage = (IMiningPage)Activator.CreateInstance(
                Type.GetType("AutoFinder.DataMining.Domain." + this._miningPageTypeName),
                new object[] { this }
            );
        }
#endregion

#region Overriden Methods
        /// <summary>
        /// Tests another object for equivalency to this instance
        /// </summary>
        /// <param name="obj">The object to test for equivalency</param>
        /// <returns>True if the object is equal to the instance, false otherwise</returns>
        public override bool Equals(object obj) {
            bool areEqual = false;
            if (obj is MinableDealer) {
                areEqual = (
                    (((MinableDealer)obj).DealerId == this.DealerId) &&
                    (((MinableDealer)obj).DealerName == this.DealerName) &&
                    (((MinableDealer)obj).DealerUrl == this.DealerUrl) &&
                    (((MinableDealer)obj).MiningPageTypeName == this.MiningPageTypeName)
                );
            }
            return areEqual;
        }

        /// <summary>
        /// Generates a unique object hash code
        /// </summary>
        /// <returns>The object hash code</returns>
        public override int GetHashCode() {
            return (
                this._dealerId +
                this._dealerName +
                this._dealerUrl +
                this._miningPageTypeName
            ).GetHashCode();
        }

        /// <summary>
        /// Generates a string that represents the current instance object
        /// </summary>
        /// <returns>A string that represents the current instance object</returns>
        public override string ToString() {
            return this._dealerName;
        }
#endregion
#endregion
    }
}