using Fakturisanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fakturisanje.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice - list of all invoices
        public ActionResult Index()
        {
            List<Invoice> listOfInvoices = Document.GetInvoices();
            return View(listOfInvoices);
        }

        //GET: create invoice - saradnik
        public ActionResult Create()
        {
            return View();
        }

        //POST: create invoice - saradnik
        [HttpPost]
        public ActionResult Create(Invoice i)
        {
            if (ModelState.IsValid)
            {
                Invoice newInvoice = new Invoice
                {
                    DocumentId = i.DocumentId,
                    InvoiceId = i.InvoiceId,
                    InvoiceDate = DateTime.Now,
                    Total = 0.0
                };
                string added = Document.CreateInvoice(newInvoice);
                switch (added)
                {
                    case "ok":
                        {
                            return RedirectToAction("Index");
                        }
                    case "pkViolation":
                        {
                            TempData["error"] = "Postoji dokument pod tim brojem";
                            return RedirectToAction("Create");
                        }
                    default:
                        {
                            TempData["error"] = "Greška.";
                            return RedirectToAction("Create");
                        }
                }
                
            }
            else
            {
                return View();
            }
        }

        //GET: edit invoice - opens selected invoice
        public ActionResult EditInvoice(string id)
        {
            InvoiceModel invoice = Document.FindInvoice(id);
            return View(invoice);
        }


        //POST: edit invoice
        [HttpPost]
        public ActionResult EditInvoice(InvoiceModel im, string submitBtn)
        {
            string docId = im.DocumentId;
            switch (submitBtn)
                {
                    case "Dodaj":
                    {
                            Field field = new Field
                            {
                                FieldName = im.FieldName,
                                Price = im.Price,
                                Amount = im.Amount,
                                DocumentId = docId
                            };
                            Item.AddField(field);
                            return RedirectToAction("EditInvoice", new { id = docId });
                    }
                    case "Izmeni fakturu":
                    {
                        if (ModelState.IsValid)
                        {
                            Invoice invoice = new Invoice
                            {
                                DocumentId = im.DocumentId,
                                InvoiceId = im.InvoiceId,
                                InvoiceDate = im.InvoiceDate,
                                Total = im.Total
                            };
                            Document.EditInvoice(invoice);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return View(im);
                        } 
                    }
                    default:
                        return RedirectToAction("Index");
                }
        }

        public ActionResult DeleteInvoice(string id)
        {
            Document.DeleteInvoice(id);
            return RedirectToAction("Index");
        }

        public void CreateField(Field field)
        {
            Item.AddField(field);
        }

        
        public ActionResult DeleteField(int id)
        {
            string documentId = Item.DeleteField(id);
            return RedirectToAction("EditInvoice", new { id = documentId });
        }

        public ActionResult EditField(int? id)
        {
            InvoiceModel im = Item.FindField(id);
            return View(im);
        }

        [HttpPost]
        public ActionResult EditField(Field im)
        {
            if (ModelState.IsValid)
            {
                Field field = new Field()
                {
                    FieldId = im.FieldId,
                    FieldName = im.FieldName,
                    Price = im.Price,
                    Amount = im.Amount
                };
                Item.EditField(field);
                return RedirectToAction("EditInvoice", new { id = im.DocumentId });
            }
            else
            {
                return View(im);
            }
        }
    }
}