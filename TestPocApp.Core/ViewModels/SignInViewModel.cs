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
    public class SignInViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IAccountService _accountService;

        public SignInViewModel(IMvxNavigationService navigationService, IAccountService accountService)
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
            set
            {
                SetProperty(ref _userName, value.Trim());

                if (!string.IsNullOrWhiteSpace(_userName) && !string.IsNullOrWhiteSpace(_password))
                    EnableSignIn = true;
                else
                    EnableSignIn = false;
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);

                if (!string.IsNullOrWhiteSpace(_userName) && !string.IsNullOrWhiteSpace(_password))
                    EnableSignIn = true;
                else
                    EnableSignIn = false;
            }
        }

        private string _loginError;
        public string LoginError
        {
            get => _loginError;
            set
            {
                SetProperty(ref _loginError, value);

                if (string.IsNullOrWhiteSpace(_loginError))
                    EnableSignIn = true;
                else
                    EnableSignIn = false;
            }
        }

        private bool _enableSignIn;
        public bool EnableSignIn
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_userName) && !string.IsNullOrWhiteSpace(_password))
                    _enableSignIn = true;
                else
                    _enableSignIn = false;

                return _enableSignIn;
            }
            set => SetProperty(ref _enableSignIn, value);
        }

        private IMvxAsyncCommand _navToCreateAccountAsyncCommand;
        public IMvxAsyncCommand NavToCreateAccountAsyncCommand
        {
            get
            {
                _navToCreateAccountAsyncCommand =
                    _navToCreateAccountAsyncCommand ?? new MvxAsyncCommand(NavToCreateAccountAsync);
                return _navToCreateAccountAsyncCommand;
            }
        }
        private async Task NavToCreateAccountAsync()
        {
            await _navigationService.Navigate<CreateAccountViewModel>();
        }

        private IMvxAsyncCommand _signInAsyncCommand;
        public IMvxAsyncCommand SignInAsyncCommand
        {
            get
            {
                _signInAsyncCommand =
                    _signInAsyncCommand ?? new MvxAsyncCommand(LoginAsync);
                return _signInAsyncCommand;
            }
        }
        private async Task LoginAsync()
        {
            if (!string.IsNullOrWhiteSpace(_userName) && !string.IsNullOrWhiteSpace(_password))
            {
                var tmp = await App.LocalDB.GetAccountsAsync();

                var userAcc = await App.LocalDB.GetAccountAsync(_userName);
                
                if (userAcc == null)
                {
                    LoginError = "account doesn’t exist";
                }
                else
                {
                    if (userAcc.Password != _password)
                    {
                        LoginError = "password is incorrect";
                    }
                    else
                    {
                        await _navigationService.Navigate<AccountsViewModel>();
                    }
                }
            }

        }

    }
}