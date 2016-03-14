using System;
using System.Collections.Generic;
using System.Linq;
using HoneyBear.HalClient.Models;

namespace Fiken.Net
{
    public class FikenCompany
    {
        public string Name { get; set; }
        public string OrganizationNumber { get; set; }
        public string Slug { get; set; }

        private FikenSession Session { get; set; }

        public static IEnumerable<FikenCompany> List(FikenSession session)
        {
            var companies = session.Root().Items<FikenCompany>().Data();

            foreach (var company in companies)
            {
                company.Session = session;

                yield return company;
            }
        }

        public static FikenCompany FindBySlug(string slug, FikenSession session)
        {
            var company = session.Root(slug).Items<FikenCompany>().Data().FirstOrDefault();

            company.Session = session;

            return company;
        }

        public IEnumerable<FikenPayment> GetPayments()
        {
            return Session.Root().Get("payments").Get("payments").Items<FikenPayment>().Data();
        }

        public IEnumerable<FikenInvoice> GetInvoices()
        {
            var parent = Session.Root().Get("invoices");

            if (!parent.Has("invoices"))
                yield break;

            foreach (var invoice in parent.Get("invoices").Items<FikenInvoice>().Data())
            {
                yield return invoice;
            }
        }

        public void InsertInvoice(FikenCreateInvoice invoice)
        {
            Session.Root().Post("create-invoice-service", invoice);
        }

        public void SaveProduct(FikenProduct product)
        {
            var root = Session.Root();

            if (string.IsNullOrEmpty(product.Url.ToString()))
            {
                root.Post("products", product);
            }
            else
            {
                root.Put("products", product);
            }
        }

        public void SaveContact(FikenContact contact)
        {
            var root = Session.Root();

            if (string.IsNullOrEmpty(contact.CustomerNumber))
            {
                root.Post("contacts", contact);
            }
            else
            {
                root.Put("contacts", contact);
            }
        }

        public void SaveSale(FikenSale sale)
        {
            var root = Session.Root();

            root.Post("sales", sale);
        }

        public void SavePayment(FikenPayment payment)
        {
            var root = Session.Root();

            root.Post("payments", payment);
        }

        public IEnumerable<FikenProduct> GetProducts()
        {
            return Session.Root().Get("products").Get("products").Items<FikenProduct>().Data();
        }

        public FikenProduct GetProduct(string name)
        {
            var product = Session.Root().Get("products").Get("products", new { name }).Item<FikenProduct>();

            var deSerialized = product.Data;
            deSerialized.Url = new Uri(product.Links[0].Href);

            return deSerialized;
        }

        public IEnumerable<FikenBankAccount> GetBankAccounts()
        {
            return Session.Root().Get("bank-accounts").Get("bank-accounts").Items<FikenBankAccount>().Data();
        }

        public FikenBankAccount GetBankAccount(string name)
        {
            var bankAccount = Session.Root().Get("bank-accounts").Get("bank-accounts", new { name }).Item<FikenBankAccount>();

            var deSerialized = bankAccount.Data;
            deSerialized.Url = new Uri(bankAccount.Links[0].Href);

            return deSerialized;
        }

        public IEnumerable<FikenAttachment> GetAttachments()
        {
            return Session.Root().Get("attachments").Get("attachments").Items<FikenAttachment>().Data();
        } 

        public IEnumerable<FikenContact> GetContacts()
        {
            return Session.Root().Get("contacts").Get("contacts").Items<FikenContact>().Data();
        }

        public FikenContact GetContact(int customerNumber)
        {
            var contact = Session.Root().Get("contacts").Get("contacts", new { customerNumber }).Item<FikenContact>();

            var deSerialized = contact.Data;
            deSerialized.Url = new Uri(contact.Links[0].Href);

            return deSerialized;
        }

        public IEnumerable<FikenAccount> GetAccounts(int year)
        {
            return Session.Root().Get("accounts", new { year }).Get("accounts").Items<FikenAccount>().Data();
        }

        public FikenAccount GetAccount(int year, string code)
        {
            var account = Session.Root().Get("accounts", new { year }).Get("accounts", new { code }).Item<FikenAccount>();

            var deSerialized = account.Data;
            deSerialized.Url = new Uri(account.Links[0].Href);

            return deSerialized;
        }

        public IEnumerable<FikenSale> GetSales()
        {
            var parent = Session.Root().Get("sales");

            if (!parent.Has("sales"))
                yield break;

            foreach (var sale in parent.Get("sales").Items<FikenSale>().Data())
            {
                yield return sale;
            }
        } 
    }
}
