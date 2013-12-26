internal class CommandLineArgsManager {
#region Private Members
    private string[] _arguments;
#endregion

#region Properties
    
#endregion

#region Public Methods
    public CommandLineArgsManager(string[] args) {
        args.CopyTo(this._arguments, 0);
    }
#endregion

#region Private Methods
    private void ProcessCommandLineArguments() {
        
    }
#endregion
}