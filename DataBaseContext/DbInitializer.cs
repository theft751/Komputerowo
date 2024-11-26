using Domain.AppModel;
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
        //Path to Testdata folder
        const string TestDataDirectoryPath = "C:\\Users\\Miłosz\\source\\repos\\PracaInzynierska\\DataBaseContext\\Testdata";
        
        const string casesPath = "json\\Cases.json";
        const string bonusImagesPath = "json\\BonusImages.json"; 
        const string mainImagesPath = "json\\MainImages.json";
        
        public static void Seed(AppDbContext context)
        {
            if (context.Database.EnsureCreated())
            {
                //json strings
                string casesJson;
                string bonusImagesJson;
                string mainImagesJson;

                //Deserialized collections from json file declaration
                ICollection<Case> cases;
                ICollection<BonusImageSeedingModel> bonusImageSeedingModels;
                ICollection<MainImageSeedingModel> mainImageSeedingModels;

                //Reading data from json files
                try
                {
                    casesJson = File.ReadAllText($"{TestDataDirectoryPath }\\{casesPath}");
                    bonusImagesJson = File.ReadAllText(bonusImagesPath);
                    mainImagesJson = File.ReadAllText(mainImagesPath);
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException("Json file cannot be found");
                }
                catch (FileLoadException)
                {
                    throw new FileLoadException("Json file cannot be loaded");
                }
                catch (Exception)
                {
                    throw new FileLoadException("An unidentified problem has occurred");
                }

                //Deserializing json data
                try
                {
                    cases = JsonSerializer.Deserialize<ICollection<Case>>(casesJson);
                    bonusImageSeedingModels = JsonSerializer.Deserialize<ICollection<BonusImageSeedingModel>>(bonusImagesJson);
                    mainImageSeedingModels = JsonSerializer.Deserialize<ICollection<MainImageSeedingModel>>(mainImagesJson);
                }
                catch
                {
                    throw new Exception("Json deserialization failed");
                }

                //Converting bonusImageSeedingModels to BonusProductImages and mainImageSeedingModels to MainImages
                ICollection <BonusProductImage> bonusProductImages = convertToBonusImage(bonusImageSeedingModels);

                try
                {
                    context.Cases.AddRange(cases);
                    context.BonusProductImages.AddRange(bonusProductImages);
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Adding test data to Database failed");
                }
            }
        }

       static ICollection<BonusProductImage> convertToBonusImage(ICollection<BonusImageSeedingModel> bonusImageSeedingModels)
        {
            ICollection<BonusProductImage> bonusProductImages = new List<BonusProductImage>();
            foreach(var element in bonusImageSeedingModels)
            {
                try
                {
                    byte[] imageData = File.ReadAllBytes($"{casesPath}\\{element.Path}");
                    bonusProductImages.Add(new BonusProductImage()
                    {
                        Id = element.Id,
                        ProductId = element.ProductId,
                        Data = imageData,
                        Title = element.Title,
                        Type = element.Type
                    });
                }
                catch (FileNotFoundException) 
                {
                    throw new FileNotFoundException("Image file cannot be found");
                }
                catch (FileLoadException)
                {
                    throw new FileLoadException("Image file cannot be loaded");
                }
                catch (Exception)
                {
                    throw new FileLoadException("An unidentified problem has occurred");
                }
            }
            return bonusProductImages;

       }
    }

}
