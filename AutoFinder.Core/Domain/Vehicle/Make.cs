using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFinder.Core {
    public class Make {
#region Private Members
        protected string _id;
        protected string _name;
#endregion

#region Properties
        /// <summary>
        /// Unique auto maker id
        /// </summary>
        public readonly string Id {
            get {
                return this._id;
            }
        }

        /// <summary>
        /// Name of auto maker
        /// </summary>
        public readonly string Name {
            get {
                return this._name;
            }
        }
#endregion

#region Public Methods
#region Constructors
        /// <summary>
        /// Initializes a new instance of the Make class
        /// </summary>
        /// <param name="copy">Make instance to copy</param>
        public Make(Make copy) : this(copy.Id, copy.Name) {
            
        }

        /// <summary>
        /// Initializes a new instance of the Make class
        /// </summary>
        /// <param name="id">Unique auto maker id</param>
        /// <param name="name">Name of auto maker</param>
        public Make(string id, string name) {
            this._id = string.Copy(id);
            this._name = string.Copy(name);
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
            if (obj is Make) {
                areEqual = (
                    (((Make)obj).Id == this.Id) &&
                    (((Make)obj).Name == this.Name)
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
                this._id +
                this._name
            ).GetHashCode();
        }

        /// <summary>
        /// Generates a string that represents the current instance object
        /// </summary>
        /// <returns>A string that represents the current instance object</returns>
        public override string ToString() {
            return this._name;
        }
#endregion
#endregion

#region Operators
        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="obj1">First object to compare</param>
        /// <param name="obj2">Second object to compare</param>
        /// <returns>True if the objects are equal, false otherwise</returns>
        public static bool operator ==(Make obj1, Make obj2) {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="obj1">First object to compare</param>
        /// <param name="obj2">Second object to compare</param>
        /// <returns>True if the objects are not equal, false otherwise</returns>
        public static bool operator !=(Make obj1, Make obj2) {
            return !obj1.Equals(obj2);
        }
#endregion
    }
}