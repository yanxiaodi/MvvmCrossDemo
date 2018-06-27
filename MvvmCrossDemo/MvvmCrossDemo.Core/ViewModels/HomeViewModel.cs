using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCrossDemo.Core.Services;

namespace MvvmCrossDemo.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;

        public HomeViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public override void Prepare()
        {
            // This is the first method to be called after construction
        }

        public override async Task Initialize()
        {
            // Async initialization, YEY!

            await base.Initialize();
            _subTotal = 100;
            _generosity = 10;

            Recalculate();

        }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                Recalculate();
            }
        }

        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                SetProperty(ref _generosity, value);
                Recalculate();
            }
        }

        private double _tip;
        public double Tip
        {
            get => _tip;
            set => SetProperty(ref _tip, value);
        }

        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }



        //public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        //private void ResetText()
        //{
        //    Text = "Hello MvvmCross";
        //}

        //private string _text = "Hello MvvmCross";
        //public string Text
        //{
        //    get => _text;
        //    set => SetProperty(ref _text, value);
        //}
    }
}
