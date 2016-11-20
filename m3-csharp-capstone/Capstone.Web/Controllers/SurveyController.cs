using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{

    public class SurveyController : Controller
    {

        private ISurveyDAL surveyDAL;

        public SurveyController(ISurveyDAL surveyDAL)
        {
            this.surveyDAL = surveyDAL;
        }

        public ActionResult SurveyForm()
        {
            ViewBag.ActivityOptions = ActivityOptions;
            ViewBag.ParkOptions = GetParkDropDownItems();
            return View("SurveyForm", new Survey());
        }

        [HttpPost]
        public ActionResult SurveyForm(Survey survey)
        {
            if (ModelState.IsValid)
            {

                surveyDAL.SaveNewSurvey(survey);
                return RedirectToAction("SurveyResult");
            }
            else
            {
                ViewBag.ActivityOptions = ActivityOptions;
                ViewBag.ParkOptions = GetParkDropDownItems();
                return View("SurveyForm", survey);
            }
        }


        public ActionResult SurveyResult()
        {
            List<SurveyResult> result = surveyDAL.SurveyResults();
            Dictionary<string, string> parks = GetParkNameAndCode();
            foreach(SurveyResult sr in result)
            {
                sr.ParkName = parks[sr.ParkCode];
            }
            return View("SurveyResult", result);
        }

        private IParkDAL dal = new ParksSqlDAL();
        private List<SelectListItem> output = new List<SelectListItem>();
        public Dictionary<string, string> GetParkNameAndCode()
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
            List<Park> parks = dal.GetAllParks();
            foreach (Park park in parks)
            {
                output[park.imgName] = park.parkName;
            }
            return output;
        }
        public List<SelectListItem> GetParkDropDownItems()
        {

            Dictionary<string, string> parks = GetParkNameAndCode();
            foreach (KeyValuePair<string, string> kvp in parks)
            {
                SelectListItem selItem = new SelectListItem() { Text = kvp.Value, Value = kvp.Key };
                output.Add(selItem);
            }
            return output;

        }


        private List<SelectListItem> ActivityOptions = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Inactive", Value="Inactive" },
            new SelectListItem() { Text = "Sedentary", Value = "Sedentary" },
            new SelectListItem() { Text = "Active", Value = "Active" },
            new SelectListItem() { Text = "Extremely Active", Value = "Extremely Active" },

        };

    }
}