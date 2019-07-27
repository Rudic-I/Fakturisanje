using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Fakturisanje.Models
{
    public class Document
    {
        //GET: list of all invoices - index.cshtml
        public static List<Invoice> GetInvoices()
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                List<Invoice> listOfInvoices = (from i in dbEntity.Invoices
                                                select i).ToList();
                return listOfInvoices;
            }
        }

        public static InvoiceModel FindInvoice(string id)
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                InvoiceModel im = (from i in dbEntity.Invoices
                                   where i.DocumentId == id
                                   select new InvoiceModel { DocumentId = i.DocumentId, InvoiceId = i.InvoiceId, InvoiceDate = i.InvoiceDate }).SingleOrDefault();
                return im;
            }
        }

        public static string CreateInvoice(Invoice invoice)
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                try
                {
                    dbEntity.Invoices.Add(invoice);
                    dbEntity.SaveChanges();
                    return "ok";
                }
                catch (DbUpdateException)
                {
                    return "pkViolation";
                }
                catch (Exception)
                {
                    return "general";
                }
            }
        }

        public static void DeleteInvoice(string id)
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                Invoice i = (from inv in dbEntity.Invoices
                             where inv.DocumentId == id
                             select inv).SingleOrDefault();
                dbEntity.Invoices.Remove(i);
                dbEntity.SaveChanges();
            }
        }

        public static void EditInvoice(Invoice i)
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                Invoice invoice = (from inv in dbEntity.Invoices
                                   where inv.DocumentId == i.DocumentId
                                   select inv).Single();
                invoice.InvoiceId = i.InvoiceId;
                invoice.InvoiceDate = i.InvoiceDate;
                invoice.Total = i.Total;
                dbEntity.SaveChanges();
            }
        }
    }
}