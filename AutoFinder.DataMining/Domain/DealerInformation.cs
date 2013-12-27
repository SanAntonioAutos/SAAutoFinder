using AutoFinder.DataMining.Domain.Interfaces;
using System;

namespace AutoFinder.DataMining.Domain {
    public class DealerInformation {
#region Private Members
        protected string _dealerId;
        protected string _dealerName;
#endregion

#region Properties
        /// <summary>
        /// Unique assigned dealer id
        /// </summary>
        internal string DealerId {
            get {
                return this._dealerId;
            }
        }

        /// <summary>
        /// Name of the dealer that is mined
        /// </summary>
        public string DealerName {
            get {
                return this._dealerName;
            }
        }
#endregion

#region Public Methods
#region Constructor(s)
        /// <summary>
        /// Initializes a new instance of the DealerInformation class
        /// </summary>
        /// <param name="copy">MinableDealer instance to copy</param>
        public DealerInformation(DealerInformation copy) : this(copy.DealerId, copy.DealerName) {

        }

        /// <summary>
        /// Initializes a new instance of the DealerInformation class
        /// </summary>
        /// <param name="dealerId">Unique assigned dealer id</param>
        /// <param name="dealerName">Name of the dealer that is mined</param>
        public DealerInformation(string dealerId, string dealerName) {
            this._dealerId = string.Copy(dealerId);
            this._dealerName = string.Copy(dealerName);
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
                    (((MinableDealer)obj).DealerName == this.DealerName)
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
                this._dealerName
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