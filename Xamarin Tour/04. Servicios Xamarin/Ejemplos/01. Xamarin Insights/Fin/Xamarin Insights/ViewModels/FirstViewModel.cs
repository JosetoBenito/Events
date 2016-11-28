using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Xamarin_Insights.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private MvxCommand _gotoSecondViewCommand;

        public ICommand GotoSecondViewCommand
        {
            get
            {
                _gotoSecondViewCommand = _gotoSecondViewCommand ?? new MvxCommand(DoGotoSecondViewCommand);
                return _gotoSecondViewCommand;
            }
        }

        private void DoGotoSecondViewCommand()
        {
            Xamarin.Insights.Track("ShowViewModel", new Dictionary<string, string> {
                {"ViewModelName", "SecondViewModel"}
            });

            ShowViewModel<SecondViewModel>();
        }
    }
}
