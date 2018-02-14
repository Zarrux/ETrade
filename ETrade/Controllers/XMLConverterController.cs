using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ETrade.Controllers
{
    public class XMLConverterController : Controller
    {
        // GET: XMLConverter
        public ActionResult Index(string format)
        {
            var products = new ProductRepository().GetAll();
            var xDoc = new XDocument();
            xDoc.Declaration = new XDeclaration("1.0", "utf-8", "no");
            if(format == "html")
            {
                xDoc.Add(new XProcessingInstruction("xml-stylesheet", "type='text/xsl' href='/xml/productsToHtml.xslt'"));
            }

            xDoc.Add(new XElement("Products",
                products.Select(p =>
                new XElement("Product", new XAttribute("Id", p.Id),
                new XElement("Name", p.Name),
                new XElement("Price", p.Price),
                new XElement("Category", p.Category),
                new XElement("Active", p.Active),
                new XElement("Description", p.Description)))));

            var schemas = new XmlSchemaSet();
            schemas.Add("", "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/xml/productSchema.xsd");
            var isValid = true;
            var errorMessage = "";

            xDoc.Validate(schemas, (o, e) =>
                {
                isValid = false;
                errorMessage = e.Message;
                },true);
            if(isValid)
            {
                xDoc = new XDocument();
                xDoc.Declaration = new XDeclaration("1.0", "utf-8", "no");
                xDoc.Add(new XElement("Error", errorMessage));
            }
            var sw = new StringWriter();
            xDoc.Save(sw);
            return View("","text/xml");
        }
    }
}