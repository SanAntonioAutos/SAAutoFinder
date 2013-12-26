internal class CommandLineArg {
#region Private Members
    private string _option;
    private string _value;
#endregion

#region Properties
    public string Option { 
        get { 
            return this._option;
        }
    }

    public string Value {
        get {
            return this._value;
        }
    }
#endregion

#region Public Methods
    public CommandLineArg(string option, string value) {
        this._option = string.Copy(option);
        this._value = string.Copy(value);
    }
#endregion
}