namespace RiakProject
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using RiakClient;
    using RiakClient.Models;
    using RiakClient.Models.Index;
    using RiakProject.Controllers;
    using RiakProject.Models;

    static class Program
    {
        static void Main(string[] args)
        {
            AppStoreController appStoreController = new AppStoreController();
            appStoreController.ImportData();

            appStoreController.GetById(284882215);

            AppStore updateAppStore = new AppStore
            {
                Id = 284882215,
                TrackName = "Suppin Detective: Expose their true visage!",
                SizeBytes = 83026944,
                Currency = "USD",
                Price = 313,
                RatingCountTot = 131,
                RatingCountVer = 1231,
                UserRating = 32,
                UserRatingVer = 0,
                Ver = "1.2.3",
                ContRating = "12+",
                PrimeGenre = "Entertainment"
            };
            appStoreController.Update(updateAppStore.Id, updateAppStore);

            appStoreController.Delete(284882215);
        }
    }
}
