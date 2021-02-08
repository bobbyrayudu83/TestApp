using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestPocApp.Core.Models;
using TestPocApp.Core.Services;
using TestPocApp.Data;

namespace TestPocApp.Core.ViewModels
{
    public class UsersViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IAccountService _accountService;

        public UsersViewModel(IMvxNavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            var lstAcc = await App.LocalDB.GetAccountsAsync();

            var tempList = lstAcc.ConvertAll(p => new User
            {
                Name = p.FirstName + ", " + p.LastName,
                Username = p.Username
            });

            tempList.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach (var usr in tempList)
            {
                AccountsList.Add(usr);
            }
        }

        public MvxObservableCollection<User> AccountsList => new MvxObservableCollection<User>();

        //private List<User> _accountsList;
        //public MvxObservableCollection<User> AccountsList
        //{
        //    get => _accountsList;
        //}

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
            //await _navigationService.Navigate<SignInViewModel>();
            await _navigationService.Navigate<ConfirmationViewModel>();
        }

    }

}