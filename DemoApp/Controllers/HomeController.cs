using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        public static List<Medicine> medicineList = GetMedicineDetails();
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Index()
        {
            //if (TempData["newMedicine"] != null)
            //    medicineList.Add(TempData["newMedicine"] as Medicine);

            //if (TempData["Index"] != null)
            //    medicineList.RemoveAt(Convert.ToInt32(TempData["Index"]));

            return View(medicineList);
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Filter(List<Medicine> filteredList)
        {
            if(filteredList == null)
            {
                medicineList = new List<Medicine> { };
            }
            else if(filteredList.Count>=1)
            {
                medicineList = filteredList;
            }
            
            
            return RedirectToAction("Index");
        }

        public ActionResult Envoice(string id)
        {
            Medicine md = medicineList.SingleOrDefault(m => m.MedicineName == id);

            return View(md);
        }

        public ActionResult Delete(string id)
        {
            int index = medicineList.FindIndex(m => m.MedicineName == id);

            medicineList.RemoveAt(index);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            Medicine md = new Medicine();
            md.MedicineName = collection["MedicineName"];
            md.ExpiryDate = Convert.ToDateTime(collection["ExpiryDate"]);
            md.Price = Convert.ToDecimal(collection["Price"]);
            md.Status = collection["Status"];

            medicineList.Add(md);
            return RedirectToAction("Index");
        }

        public static List<Medicine> GetMedicineDetails()
        {
            return new List<Medicine>
            {
                new Medicine
                {
                  MedicineName= "Medicine1" ,
                  Price = 10.0M,
                  ExpiryDate = new DateTime(2019, 1, 18),
                  Status = "status1"
                 },
                new Medicine
                {
                  MedicineName = "Medicine2" ,
                  Price = 101.0M,
                  ExpiryDate = new DateTime(2018, 1, 18),
                  Status = "status1"
                 },
                new Medicine
                {
                  MedicineName = "Medicine3" ,
                  Price = 10.0M,
                  ExpiryDate = new DateTime(2019, 1, 18),
                  Status = "status1"
                 },
                new Medicine
                {
                  MedicineName = "Medicine4" ,
                  Price = 104.0M,
                  ExpiryDate = new DateTime(2018, 4, 28),
                  Status = "status1"
                 },
            };
        }
    }
}
