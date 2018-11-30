using System;
using System.Windows.Input;
using FreshMvvm;
using Posy.Models;
using Xamarin.Forms;

namespace Posy.PageModels
{
    public class MainPageModel : FreshBasePageModel
    {
        // Not proud of this construction, but with Bitcoin there are a lot of decimals to
        // take into account which somehow get magically converted to e7 blabla.
        public string RiskPercentage { get; set; }
        public string CapitalSize { get; set; }
        public string TargetPrice { get; set; }
        public string EntryPrice { get; set; }
        public string StopPrice { get; set; }

        public ICommand OpenResultCommand { get; set; }

        public MainPageModel()
        {
            RiskPercentage = "2";
            CapitalSize = "0.2";

            OpenResultCommand = new Command(async () =>
            {
                double riskPerc, capSize, entryPrice, stopPrice, targetPrice;

                if (double.TryParse(RiskPercentage, out riskPerc) &&
                    double.TryParse(CapitalSize, out capSize) &&
                    double.TryParse(EntryPrice, out entryPrice) &&
                    double.TryParse(StopPrice, out stopPrice) &&
                    double.TryParse(TargetPrice, out targetPrice))
                {
                    var model = new InputModel
                    {
                        RiskPercentage = riskPerc,
                        CapitalSize = capSize,
                        EntryPrice = entryPrice,
                        StopPrice = stopPrice,
                        TargetPrice = targetPrice
                    };

                    await CoreMethods.PushPageModel<ResultPageModel>(model);
                }
            });
        }
    }
}
