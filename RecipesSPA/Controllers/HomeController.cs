using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecipesSPA.Models;

namespace RecipesSPA.Controllers
{
    public class HomeController : Controller
    {
        const string API_KEY = "d910b4f73cd24685adeb7ee7326acc3d";


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            //ViewBag.Message = "Search Page";

            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {

            string url = "https://api.spoonacular.com/recipes/search";


            WebRequest request = WebRequest.Create(url + "?query=" + searchTerm + "&apiKey=" + API_KEY);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(dataStream);
            String jsonStr = sr.ReadToEnd();

            sr.Close();
            response.Close();

            JObject jsonObj = JObject.Parse(jsonStr);

            IList<JToken> results = jsonObj["results"].Children().ToList();
            JToken imgBaseURI = jsonObj["baseUri"].Value<JToken>();

            IList<Recipe> recipes = new List<Recipe>();

            foreach(JToken result in results)
            {
                Recipe recipe = result.ToObject<Recipe>();
                recipe.Image = imgBaseURI.ToString() + recipe.Image;
                recipes.Add(recipe);
                
            }
            
            return View(recipes);
        }

    }
}