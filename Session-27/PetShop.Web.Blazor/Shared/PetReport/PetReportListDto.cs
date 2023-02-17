using PetShop.Model.Enums;
using PetShop.Web.Blazor.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.PetReport
{
    public class PetReportListDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public AnimalType AnimalType { get; set; }
        public int BirdSold { get; set; }
        public int MammalSold { get; set; }
        public int ReptileSold { get; set; }
        public int FishSold { get; set; }
       // public int TotalSold { get; set; }
        public PetReportListDto(DateTime date)
        {
            Year = date.Year;
            Month = date.Month;
        }

        public void UpdateSold(int birdSold, int mammalSold, int reptileSold, int fishSold)
        {
            BirdSold = birdSold;
            MammalSold = mammalSold;
            ReptileSold = reptileSold;
            FishSold = fishSold;

        }


    }
}