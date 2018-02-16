
using ETrade.Helper;
using Store.DAL.Entities;
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
    [Authorize]
    public class XMLConverterController : Controller
    {
        private Log log = new Log();
        // GET: XMLConverter
        public ActionResult Index(string format)
        {
            log.Action = "AddToBasket";
            log.IPAddress = Request.UserHostAddress.ToString();
            log.Method = "Get";
            log.User = User.Identity.Name;

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

            log.Action = log.Action;
            Helper.LogHelper.Error(log);

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
            LogHelper.Info(log);
            return View("","text/xml");
        }
    }
}