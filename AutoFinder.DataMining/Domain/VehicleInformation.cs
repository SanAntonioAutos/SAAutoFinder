namespace AutoFinder.DataMining.Domain {
    public class VehicleInformation {
#region Properties
        public string BodyStyle { get; set; }
        public VehicleCondition Condition { get; set; }
        public DealerInformation Dealer { get; private set; }
        public string DetailUrl { get; set; }
        public string DriveTrain { get; set; }
        public string Engine { get; set; }
        public string ExteriorColor { get; set; }
        public string FuelEconomy { get; set; }
        public string InteriorColor { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Odometer { get; set; }
        public decimal Price { get; set; }
        public string Transmission { get; set; }
        public string Trim { get; set; }
        public string Vin { get; set; }
        public int Year { get; set; }
#endregion

#region Public Methods
        public VehicleInformation(DealerInformation dealer, string bodyStyle = "",
                                  VehicleCondition condition = VehicleCondition.Unknown,
                                  string detailUrl = "", string engine = "", string exteriorColor = "",
                                  string fuelEconomy = "", string interiorColor = "", string make = "",
                                  string model = "", int odometer = 0, decimal price = 0.0m,
                                  string transmission = "", string trim = "", string vin = "", int year = 1900) {
            this.Dealer = new DealerInformation(dealer);
            this.BodyStyle = string.Copy(bodyStyle);
            this.Condition = condition;
            this.DetailUrl = string.Copy(detailUrl);
            this.Engine = string.Copy(engine);
            this.ExteriorColor = string.Copy(exteriorColor);
            this.FuelEconomy = string.Copy(fuelEconomy);
            this.InteriorColor = string.Copy(interiorColor);
            this.Make = string.Copy(make);
            this.Model = string.Copy(model);
            this.Odometer = odometer;
            this.Price = price;
            this.Transmission = string.Copy(transmission);
            this.Trim = string.Copy(trim);
            this.Vin = string.Copy(vin);
            this.Year = year;
        }
#endregion
    }
}