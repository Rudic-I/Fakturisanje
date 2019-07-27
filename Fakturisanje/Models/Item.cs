using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fakturisanje.Models
{
    public class Item
    {
        public static List<Field> GetFields(string documentId)
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                List<Field> fields = (from f in dbEntity.Fields
                                      where f.DocumentId == documentId
                                      select f).ToList();
                return fields;
            }
        }

        public static void AddField(Field field)
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                dbEntity.Fields.Add(field);
                dbEntity.SaveChanges();
            }
        }

        public static string DeleteField(int id)
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                Field field = (from f in dbEntity.Fields
                               where f.FieldId == id
                               select f).SingleOrDefault();
                string documentId = field.DocumentId;

                try
                {
                    dbEntity.Fields.Remove(field);
                    dbEntity.SaveChanges();
                    return documentId;
                }
                catch (Exception)
                {
                    return "error";
                }
            }
        }

        public static InvoiceModel FindField(int? id)
        {
            using(FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                InvoiceModel field = (from f in dbEntity.Fields
                                      where f.FieldId == id
                                      select new InvoiceModel { DocumentId = f.DocumentId, FieldId = f.FieldId, FieldName = f.FieldName, Price = f.Price, Amount = f.Amount }).SingleOrDefault();
                return field;
            }
        }

        public static void EditField(Field field)
        {
            using (FakturisanjeEntities dbEntity = new FakturisanjeEntities())
            {
                Field newField = (from f in dbEntity.Fields
                                  where f.FieldId == field.FieldId
                                  select f).SingleOrDefault();
                newField.FieldName = field.FieldName;
                newField.Price = field.Price;
                newField.Amount = field.Amount;

                dbEntity.SaveChanges();
            }
        }
    }
}