using BuchungsManager.Lib.Interfaces;
using BuchungsManager.Lib.Modell;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuchungsManager.Lib.Repositories
{
    public class XMLRepository : IRepository
    {
        private string _path;
        private XElement _rootElement;

        public XMLRepository(string path)
        {
            _path = path;
            if (File.Exists(path))
            {

                _rootElement = XElement.Load(path);

            }
            else
            {
                _rootElement = new XElement("buchungen");
            }


        }

        public bool Add(Buchungen buchungen)
        {
            try
            {
                XElement node = new XElement("buchung");

                var idAttrib = new XAttribute("id", buchungen.Id.ToString());
                node.Add(idAttrib);

                var gastNameAttrib = new XAttribute("gastname", buchungen.GastName.ToString());
                node.Add(gastNameAttrib);

                var anreiseDatumAttrib = new XAttribute("einreisedatum", buchungen.AnreiseDatum.ToString());
                node.Add(anreiseDatumAttrib);

                var preisProNachtAttrib = new XAttribute("preispronacht", buchungen.PreisProNacht.ToString());
                node.Add(preisProNachtAttrib);

                var allInklusivAttrib = new XAttribute("inklusiv", buchungen.AllInklusiv.ToString());
                node.Add(allInklusivAttrib);

                _rootElement.Add(node);

                return this.Save();
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            
        }

        public bool Delete(Buchungen buchungen)
        {

            try
            {
                var itemToDelete = from e in this._rootElement.Descendants("buchung")
                                   where (string)e.Attribute("id").Value == buchungen.Id
                                   select e;

                itemToDelete.Remove();

                return this.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            
        }

        public List<Buchungen> GetAll()
        {
            var buchungen = from e in this._rootElement.Descendants("buchung")
                           select new Buchungen(
                               e.Attribute("id").Value,
                               e.Attribute("gastname").Value,
                               Convert.ToDateTime(e.Attribute("einreisedatum").Value),
                               Convert.ToDouble(e.Attribute("preispronacht").Value),
                               Convert.ToBoolean(e.Attribute("inklusiv").Value)
                               );

            return buchungen.ToList<Buchungen>();
        }

        public bool Save()
        {
            try
            {
                this._rootElement.Save(_path);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Update(Buchungen buchungen)
        {
            var itemToUpdate = (from e in this._rootElement.Descendants("buchung")
                               where e.Attribute("id").Value == buchungen.Id
                               select e).FirstOrDefault();

            if (itemToUpdate != null)
            {
                itemToUpdate.SetAttributeValue("gastname", buchungen.GastName);
                itemToUpdate.SetAttributeValue("anreisedatum", buchungen.AnreiseDatum.ToString());
                itemToUpdate.SetAttributeValue("preispronacht", buchungen.PreisProNacht.ToString());
                itemToUpdate.SetAttributeValue("inklusiv", buchungen.AllInklusiv.ToString());
                return this.Save();
            }
            else
            {
                return false;
            }
        }
    }
}
