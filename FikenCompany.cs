using System;
using System.Collections.Generic;
using System.Linq;
using Fiken.Net.HalClient.Models;

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

        public FikenInvoice GetInvoice(int invoiceNo)
        {
            var parent = Session.Root().Get("invoices");

            //if (!parent.Has("invoices"))
            //    return null;

            var invoice = parent.Get("invoices", new { invoiceNumber = invoiceNo }).Item<FikenInvoice>();
            var deSerialized = invoice.Data;
            deSerialized.Url = new Uri(invoice.Links[0].Href);

            return deSerialized;
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

        public FikenInvoice InsertInvoice(FikenCreateInvoice invoice)
        {
            var results = Session.Root().Post("create-invoice-service", invoice);
            
            return results.Item<FikenInvoice>().Data;
        }

        public FikenProduct SaveProduct(FikenProduct product)
        {
            var root = Session.Root();
            IResource<FikenProduct> response;

            if (string.IsNullOrEmpty(product.Url.ToString()))
            {
                response = root.Post("products", product).Item<FikenProduct>();
            }
            else
            {
                response = root.Put("products", product).Item<FikenProduct>();
            }

            return response.Data;
        }

        public FikenContact SaveContact(FikenContact contact)
        {
            var root = Session.Root();
            IResource<FikenContact> response;

            if (string.IsNullOrEmpty(contact.CustomerNumber))
            {
                response = root.Post("contacts", contact).Item<FikenContact>();
            }
            else
            {
                response = root.Put("contacts", contact).Item<FikenContact>();
            }

            return response.Data;
        }

        public FikenSale SaveSale(FikenSale sale)
        {
            var root = Session.Root();

            var response = root.Post("sales", sale).Item<FikenSale>();

            return response.Data;
        }

        public FikenPayment SavePayment(FikenPayment payment)
        {
            var root = Session.Root();

            var response = root.Post("payments", payment).Item<FikenPayment>();

            return response.Data;
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

        public FikenContact GetContact(string email)
        {
            var contact = Session.Root().Get("contacts").Get("contacts", new { email }).Item<FikenContact>();

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

        public void SendInvoiceEmail(int invoiceNo, string recipientEmail, string recipientName, string emailSendOption = "auto")
        {
            var invoice = GetInvoice(invoiceNo);

            Session.Root().Post("document-sending-service", new { resource = invoice.Url, method = "email", recipientEmail, recipientName = recipientEmail, emailSendOption });
        }

        public void SendInvoiceEhf(int invoiceNo, string organizationNumber)
        {
            var invoice = GetInvoice(invoiceNo);

            Session.Root().Post("document-sending-service", new { resource = invoice.Url, method = "ehf", organizationNumber });
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
