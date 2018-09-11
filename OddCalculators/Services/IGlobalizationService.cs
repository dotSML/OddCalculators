using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OddCalculators.Services
{
    public interface IGlobalizationService
    {
        List<string> PopulateCountriesDropdown();
    }

    public class GlobalizationService : IGlobalizationService
    {
        public List<string> CountryList { get; set; }

        public List<string> PopulateCountriesDropdown()
        {
            var tempList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(tempList.Contains(R.EnglishName)))
                {
                    tempList.Add(R.EnglishName);
                }
            }

            tempList.Sort();

            CountryList = tempList;
            return CountryList;
        }

        
    }
}
