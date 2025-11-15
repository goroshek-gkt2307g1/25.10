using _25._10.Domain;
using _25._10.Interfaces;
using _25._10.Models.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _25._10.Models.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        public void Add(Account account)
        {
            try
            {
                using var context = new MyDatabaseContext();
                context.Accounts.Add(account);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Логируем ошибку
                Console.WriteLine($"Error adding account: {ex.Message}");
            }
        }

        public void Update(int id, Account account)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var accountInDb = context.Accounts.FirstOrDefault(x => x.AccountId == id);
                if (accountInDb != null)
                {
                    accountInDb.Username = account.Username;
                    accountInDb.Password = account.Password;
                    accountInDb.FullName = account.FullName;
                    accountInDb.RoleIdFk = account.RoleIdFk;
                    accountInDb.AccountDescription = account.AccountDescription;
                    accountInDb.HireDate = account.HireDate;
                    accountInDb.AccountStatusFk = account.AccountStatusFk;

                    context.Accounts.Update(accountInDb);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating account: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var account = context.Accounts.FirstOrDefault(x => x.AccountId == id);
                if (account != null)
                {
                    context.Accounts.Remove(account);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting account: {ex.Message}");
            }
        }

        public Account? Find(Predicate<Account> predicate)
        {
            using var context = new MyDatabaseContext();
            return context.Accounts
                .Include(a => a.RoleIdFkNavigation)
                .Include(a => a.AccountStatusFkNavigation)
                .FirstOrDefault(a => predicate(a));
        }

        public Account? Get(int id)
        {
            using var context = new MyDatabaseContext();
            return context.Accounts
                .Include(a => a.RoleIdFkNavigation)
                .Include(a => a.AccountStatusFkNavigation)
                .FirstOrDefault(x => x.AccountId == id);
        }

        public IEnumerable<Account> GetAll()
        {
            using var context = new MyDatabaseContext();
            return context.Accounts
                .Include(a => a.RoleIdFkNavigation)
                .Include(a => a.AccountStatusFkNavigation)
                .ToList();
        }
    }
}