using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestPocApp.Core.Services;

namespace TestPocApp.Core.ViewModels
{
    public class ConfirmationViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IAccountService _accountService;

        public ConfirmationViewModel(IMvxNavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            //
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        private IMvxAsyncCommand _navToCreateAccountAsyncCommand;
        public IMvxAsyncCommand NavToCreateAccountAsyncCommand
        {
            get
            {
                _navToCreateAccountAsyncCommand =
                    _navToCreateAccountAsyncCommand ?? new MvxAsyncCommand(NavToConfirmationAsync);
                return _navToCreateAccountAsyncCommand;
            }
        }
        private async Task NavToConfirmationAsync()
        {
            await _navigationService.Navigate<ConfirmationViewModel>();
        }

        private IMvxAsyncCommand _signInAsyncCommand;
        public IMvxAsyncCommand NavToSignInAsyncCommand
        {
            get
            {
                _signInAsyncCommand =
                    _signInAsyncCommand ?? new MvxAsyncCommand(NavToSignInAsync);
                return _signInAsyncCommand;
            }
        }
        private async Task NavToSignInAsync()
        {
            await _navigationService.Navigate<SignInViewModel>();
        }

    }
}