using AutoFinder.DataMining.Domain.Interfaces;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace AutoFinder.DataMining.Domain {
    internal class GunnAutoMiningPage : IMiningPage {
#region Private Members
        private MinableDealer _minableDealer;
        private List<VehicleInformation> _pageVehicles;
#endregion

#region Properties
        public List<VehicleInformation> MinedVehicles {
            get {
                return this._pageVehicles;
            }
        }
#endregion

#region Public Methods
        public GunnAutoMiningPage(MinableDealer dealer) {
            this._minableDealer = dealer;
            this._pageVehicles = null;
        }

#region Interface Methods
        public void Mine() {
            HtmlDocument miningDocument = this.LoadHtmlDocument();
            this.MineHtmlDocument(miningDocument);
        }

        public void Mine(string html) {
            HtmlDocument miningDocument = this.LoadHtmlDocument(html);
            this.MineHtmlDocument(miningDocument);
        }
#endregion
#endregion

#region Private Methods
        private HtmlDocument LoadHtmlDocument() {
            HtmlWeb minableHtml = new HtmlWeb();
            return minableHtml.Load(this._minableDealer.DealerUrl);
        }

        private HtmlDocument LoadHtmlDocument(string html) {
            HtmlDocument minableDocument = new HtmlDocument();
            minableDocument.LoadHtml(html);
            return minableDocument;
        }

        private void MineHtmlDocument(HtmlDocument minableDocument) {
            this._pageVehicles = new List<VehicleInformation>();

            HtmlNodeCollection vehicleNodes = minableDocument.DocumentNode.SelectNodes("//div[@class='searchresults']/div");
            foreach (HtmlNode vehicleNode in vehicleNodes) {
                VehicleInformation vehicleInfo = new VehicleInformation(this._minableDealer);

                HtmlNode vehicleYearNode = vehicleNode.SelectSingleNode(".//span[@class='year']");
                if (vehicleYearNode != null) {
                    vehicleInfo.Year = int.Parse(vehicleYearNode.InnerText.Trim());
                }

                HtmlNode vehicleMakeNode = vehicleNode.SelectSingleNode(".//span[@class='make']");
                if (vehicleMakeNode != null) {
                    vehicleInfo.Make = vehicleMakeNode.InnerText.Trim();
                }

                HtmlNode vehicleModelNode = vehicleNode.SelectSingleNode(".//span[@class='model']");
                if (vehicleModelNode != null) {
                    vehicleInfo.Model = vehicleModelNode.InnerText.Trim();
                }

                HtmlNode vehicleTrimNode = vehicleNode.SelectSingleNode(".//span[@class='trim']");
                if (vehicleTrimNode != null) {
                    vehicleInfo.Trim = vehicleTrimNode.InnerText.Trim();
                }

                HtmlNode vehicleEngineNode = vehicleNode.SelectSingleNode(".//span[@class='vehicleengine']");
                if (vehicleEngineNode != null) {
                    vehicleInfo.Engine = vehicleEngineNode.InnerText.Trim(new char[] { ' ', ',' });
                }

                HtmlNode vehicleDriveTrainNode = vehicleNode.SelectSingleNode(".//span[@class='vehicledriveline']");
                if (vehicleDriveTrainNode != null) {
                    vehicleInfo.DriveTrain = vehicleDriveTrainNode.InnerText.Trim(new char[] { ' ', ',' });
                }

                HtmlNode vehicleTransmissionNode = vehicleNode.SelectSingleNode(".//span[@class='vehicletrans']");
                if (vehicleTransmissionNode != null) {
                    vehicleInfo.Transmission = vehicleTransmissionNode.InnerText.Trim(new char[] { ' ', ',' });
                }

                HtmlNode vehicleOdometerNode = vehicleNode.SelectSingleNode(".//span[@class='vehicleodometer']");
                if (vehicleOdometerNode != null) {
                    string vehicleOdometerNodeText = vehicleOdometerNode.InnerText.Trim(new char[] { ' ', ',' }).Replace("miles", string.Empty);
                    vehicleOdometerNodeText = vehicleOdometerNodeText.Replace("mile", string.Empty);
                    if (vehicleOdometerNodeText.Contains("k")) {
                        vehicleInfo.Odometer = int.Parse(vehicleOdometerNodeText.Replace("k", string.Empty)) * 1000;
                    }
                    else {
                        vehicleInfo.Odometer = int.Parse(vehicleOdometerNodeText);
                    }
                }

                HtmlNode vehicleFuelEconomyNode = vehicleNode.SelectSingleNode(".//span[@class='mpg']");
                if (vehicleFuelEconomyNode != null) {
                    vehicleInfo.FuelEconomy = vehicleFuelEconomyNode.InnerText.Trim(new char[] { ' ', ',' });
                }

                HtmlNode vehicleExteriorColorNode = vehicleNode.SelectSingleNode(".//span[@class='vehiclecolor']");
                if (vehicleExteriorColorNode != null) {
                    vehicleInfo.ExteriorColor = vehicleExteriorColorNode.InnerText.Trim(new char[] { ' ', ',' });
                }

                HtmlNode vehicleConditionNode = vehicleNode.SelectSingleNode(".//span[@class='vehiclecondition']");
                if (vehicleConditionNode != null) {
                    string vehicleConditionNodeText = vehicleConditionNode.InnerText.Replace(",", string.Empty).Trim().ToLower();
                    if (vehicleConditionNodeText.Contains("certified")) {
                        vehicleInfo.Condition = VehicleCondition.Certified;
                    }
                    else if (vehicleConditionNodeText == "new") {
                        vehicleInfo.Condition = VehicleCondition.New;
                    }
                    else if (vehicleConditionNodeText == "used" || vehicleConditionNodeText.Contains("pre-owned")) {
                        vehicleInfo.Condition = VehicleCondition.Used;
                    }
                    else {
                        vehicleInfo.Condition = VehicleCondition.Unknown;
                    }
                }

                HtmlNode vehiclePricingNode = vehicleNode.SelectSingleNode(".//div[@class='pricing']/ul/li/span");
                if (vehiclePricingNode != null) {
                    vehicleInfo.Price = decimal.Parse(vehiclePricingNode.InnerText.Replace("$", string.Empty).Trim());
                }

                HtmlNode vehicleDetailLinkNode = vehicleNode.SelectSingleNode(".//div[@class='view']/a");
                if (vehicleDetailLinkNode != null) {
                    vehicleInfo.DetailUrl = "http://gunnauto.com" + vehicleDetailLinkNode.Attributes["href"].Value;
                }

                this._pageVehicles.Add(vehicleInfo);
            }
        }
#endregion
    }
}