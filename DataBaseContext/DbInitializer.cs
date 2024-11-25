using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataBaseContext
{
    //This object initialize database with test data from json files
    public static class DbInitializer
    {
        /*
        const string casesPath = "/Testdata/json/Cases.json";
        const string bonusImagesPath = "/Testdata/json/BonusImages.json"; 
        const string mainImagesPath = "/Testdata/json/MainImage.json";
            
        public static void Seed(AppDbContext context)
        {
            string casesJson;
            string bonusImagesJson;
            string mainImagesJson;

            try
            { 
                casesJson = File.ReadAllText(casesPath);
                bonusImagesJson = File.ReadAllText(bonusImagesPath);
                mainImagesJson = File.ReadAllText(mainImagesPath);
            }
            catch {
                throw new Exception("Cannot read file");
            }

            try
            { 
                ICollection<Case> cases = JsonSerializer.Deserialize<ICollection<Case>>(casesJson);
            }
            catch
            {
                throw new Exception("Json deserialization failed");
            }

        }
        */
    }

}
