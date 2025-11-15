using _25._10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using _25._10.Models.Entities.Entities;
using _25._10.Models.Repositories;
using _25._10.Commands;
using System.Collections.Specialized;
using System.Linq;
using _25._10.Models.Entities;

namespace _25._10.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private MyCommand _addCommand;
        private MyCommand _updateCommand;
        private MyCommand _deleteCommand;
        private ObservableCollection<Account> _accounts;
        private readonly AccountRepository _accountRepository;

        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set
            {
                if (value != null)
                {
                    _accounts = value;
                    OnPropertyChanged();
                }
            }
        }

        public MyCommand AddCommand
        {
            get => _addCommand ??= new MyCommand(
            (obj) =>
            {
                Account account = new();
                GetAccountsView();
                _accountRepository.Add(account);
            }, (obj) => true
            );
        }

        public MyCommand UpdateCommand
        {
            get => _updateCommand ??= new MyCommand(
            (obj) =>
            {
                var account = Accounts.Last();
                account.AccountDescription = "Обнова описания";
                _accountRepository.Update(account.AccountId, account);
                GetAccountsView();
            }, (obj) => Accounts.Count > 0
            );
        }

        public MyCommand DeleteCommand
        {
            get => _deleteCommand ??= new MyCommand(
            (obj) =>
            {
                var account = Accounts.Last();
                _accountRepository.Delete(account.AccountId);
                GetAccountsView();
            }, (obj) => Accounts.Count > 0
            );
        }

        public MainWindowViewModel()
        {
            _accountRepository = new AccountRepository();
            GetAccountsView();
            Accounts.CollectionChanged += Accounts_CollectionChanged;
        }

        private void Accounts_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems != null)
                {
                    foreach (Account account in e.NewItems)
                    {
                        _accountRepository.Add(account);
                    }
                }
            }
            //другие проверки...
        }

        private void GetAccountsView()
        {
            var collection = _accountRepository.GetAll();
            Accounts = new ObservableCollection<Account>(collection);
        }
    }
}