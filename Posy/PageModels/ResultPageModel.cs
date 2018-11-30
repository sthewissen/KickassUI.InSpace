using System;
using FreshMvvm;
using Posy.Models;
using Xamarin.Forms;

namespace Posy.PageModels
{
    public class ResultPageModel : FreshBasePageModel
    {
        private InputModel _input;

        private void SetResultValues()
        {
            RiskPercentage = _input.RiskPercentage;
            SuggestedQuantity = ((_input.RiskPercentage / 100) * _input.CapitalSize) / (_input.EntryPrice - _input.StopPrice);
            PositionCost = SuggestedQuantity * _input.EntryPrice;
            PositionRisk = SuggestedQuantity * (_input.EntryPrice - _input.StopPrice);
            TargetGain = (SuggestedQuantity * _input.TargetPrice) - PositionCost;
            RaisePropertyChanged(nameof(TargetGainPercentage));
        }

        public double RiskPercentage { get; set; }
        public double SuggestedQuantity { get; set; }
        public double PositionCost { get; set; }
        public double PositionRisk { get; set; }
        public double TargetGain { get; set; }
        public double TargetGainPercentage => TargetGain / PositionCost * 100;

        public override void Init(object initData)
        {
            base.Init(initData);

            if (initData is InputModel input)
            {
                _input = input;
                SetResultValues();
            }
        }
    }
}

