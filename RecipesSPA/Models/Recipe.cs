using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesSPA.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Serving { get; set; }
        public string SourceUrl { get; set; }
        public int OpenLicense { get; set; }
        public string Image { get; set; }
        


    }
}