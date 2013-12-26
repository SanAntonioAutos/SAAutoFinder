using AutoFinder.DataMining.Domain.Interfaces;
using HtmlAgilityPack;

namespace AutoFinder.DataMining.Domain {
    internal class GunnAutoMiningPage : IMiningPage {
#region Private Members
        private MinableDealer _minableDealer;
#endregion

#region Properties

#endregion

#region Public Methods
        public GunnAutoMiningPage(MinableDealer dealer) {
            this._minableDealer = dealer;
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

        }
#endregion
    }
}