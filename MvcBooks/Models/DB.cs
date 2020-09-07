using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MvcBooks.Models
{
    public class DB
    {
        public List<Book> books { get; set; }
        public List<Category> cats { get; set; }

        public List<string> TitlesInCat(int catid)
        {
            List<string> titles = new List<string>();
            foreach (Book bk in books)
            {
                if (bk.CategoryId == catid)
                    titles.Add(bk.Title);
            }
            return titles;
        }

        public string Save()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(DB));
                FileStream s = new FileStream("App_Data\\books.xml",
                                              FileMode.Create);
                ser.Serialize(s, this);
                s.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "OK";
        }

        public static DB Restore()
        {
            DB db;
            XmlSerializer ser = new XmlSerializer(typeof(DB));
            FileStream s = new FileStream("App_Data\\books.xml", FileMode.Open);
            db = (DB) ser.Deserialize(s);
            s.Close();
            return db;
        }

        public static string AddCategory(Category cat)
        {
            DB db = Restore();
            db.cats.Add(cat);
            string msg = db.Save();
            if (msg == "OK")
                msg = string.Format("Category {0} has been added", cat.Description);
            return msg;
        }
    }
}
