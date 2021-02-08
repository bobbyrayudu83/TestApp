using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestPocApp.Core.Models;
using TestPocApp.Core.Services;
using TestPocApp.Data;

namespace TestPocApp.Core.ViewModels
{
    public class CreateAccountViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IAccountService _accountService;

        public CreateAccountViewModel(IMvxNavigationService navigationService, IAccountService accountService)
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
        public string Username
        {
            get => _userName;
            set { 
                SetProperty(ref _userName, value.Trim());
                ValidateFields(); 
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value.Trim());
                ValidateFields();
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                SetProperty(ref _phone, value.Trim());
                ValidateFields();
            }
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value.Trim());
                ValidateFields();
            }
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                SetProperty(ref _lastName, value.Trim());
                ValidateFields();
            }
        }
        private string _serviceDate;
        public string ServiceDate
        {
            get => _serviceDate;
            set
            {
                SetProperty(ref _serviceDate, value.Trim());
                ValidateFields();
            }
        }

        private bool _enableCreateAccount;
        public bool EnableCreateAccount
        {
            get
            {
                _enableCreateAccount = ValidateFields(); 
                return _enableCreateAccount;
            }
            set => SetProperty(ref _enableCreateAccount, value);
        }
        private bool _hasErrors;
        public bool HasErrors
        {
            get => _hasErrors;
            set
            {
                SetProperty(ref _hasErrors, value);
            }
        }

        private bool ValidateFields()
        {
            ErrorText = string.Empty;
            _hasErrors = true;

            if (string.IsNullOrWhiteSpace(_firstName) || string.IsNullOrWhiteSpace(_lastName)
                || string.IsNullOrWhiteSpace(_userName) || string.IsNullOrWhiteSpace(_password)
                || string.IsNullOrWhiteSpace(_phone) || string.IsNullOrWhiteSpace(_serviceDate))
            {
                return false;
            }
            if (_firstName.Contains("!") || _firstName.Contains("@")
                || _firstName.Contains("#") || _firstName.Contains("$")
                || _firstName.Contains("%") || _firstName.Contains("^")
                || _firstName.Contains("&"))
            {
                ErrorText = "First Name cannot have these special characters (!@#$%^&)";
                return false;
            }
            if (_lastName.Contains("!") || _lastName.Contains("@")
                || _lastName.Contains("#") || _lastName.Contains("$")
                || _lastName.Contains("%") || _lastName.Contains("^")
                || _lastName.Contains("&"))
            {
                ErrorText = "Last Name cannot have these special characters (!@#$%^&)";
                return false;
            }
            if (_password.Length < 8 || _password.Length > 15)
            {
                ErrorText = "Password must have from 8 to 15 characters";
                return false;
            }
            //var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            if (hasUpperChar.IsMatch(_password) == false)
            {
                ErrorText = "Password must have at least one uppercase letter";
                return false;
            }
            if (hasLowerChar.IsMatch(_password) == false)
            {
                ErrorText = "Password must have at least one lowercase letter";
                return false;
            }
            if (Regex.Match(_phone, @"^\(\d{3}\) \d{3}-\d{4}$").Success == false)
            {
                ErrorText = "Enter valid phone number (XXX) XXX-XXXX";
                return false;
            }
            DateTime serviceDt = new DateTime();
            if(DateTime.TryParse(_serviceDate, out serviceDt)==false)
            {
                ErrorText = "Enter valid service date";
                return false;
            }
            if(serviceDt < DateTime.Today)
            {
                ErrorText = "Service date cannot be past date"; 
                return false;
            }
            if (serviceDt > DateTime.Today.AddDays(30))
            {
                ErrorText = "Service date cannot be more than 30 days into the future";
                return false;
            }

            //Password Length 8 and Maximum 15 character
            //Require Unique Chars
            //Require Digit
            //Require Lower Case
            //Require Upper Case
            //var validPasswordReg = new Regex(@"^(? !.* ([A - Za - z0 - 9]))(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,15}$");

            _hasErrors = false;
            EnableCreateAccount = true;
            return true;
        }

        private string _errorText;
        public string ErrorText
        {
            get => _errorText;
            set => SetProperty(ref _errorText, value);
        }
        private IMvxAsyncCommand _confirmAsyncCommand;
        public IMvxAsyncCommand ConfirmAsyncCommand
        {
            get
            {
                _confirmAsyncCommand =
                    _confirmAsyncCommand ?? new MvxAsyncCommand(ConfirmationAsync);
                return _confirmAsyncCommand;
            }
        }
        private async Task ConfirmationAsync()
        {
            if (ValidateFields())
            {
                Account newAccount = new Account();
                newAccount.FirstName = _firstName.Trim();
                newAccount.LastName = _lastName.Trim();
                newAccount.Username = _userName.Trim();
                newAccount.Password = _password;
                newAccount.Phone = _phone;
                newAccount.ServiceDate = _serviceDate;

                await App.LocalDB.SaveAccountAsync(newAccount); 

                await _navigationService.Navigate<ConfirmationViewModel>();

            }
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