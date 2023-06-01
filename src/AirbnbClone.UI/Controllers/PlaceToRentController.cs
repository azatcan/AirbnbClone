using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AirbnbClone.UI.Controllers
{
    public class PlaceToRentController : Controller
    {
        CityService _cityService;
        DistrictService _districtService;
        CountryService _countryService;
        CategoryService _categoryService;

        public PlaceToRentController(CityService cityService, DistrictService districtService, CountryService countryService, CategoryService categoryService)
        {
            _cityService = cityService;
            _districtService = districtService;
            _countryService = countryService;
            _categoryService = categoryService;
        }

        public IActionResult List()
        {
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token").ToString());
            var request = client.GetAsync("http://localhost:5272/api/PlaceToRent/List").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<PlaceToRent>>(response);
            return View(value);
        }
        public IActionResult CityGet(int id)
        {
            List<City> cities = _cityService.List(x => x.CountryId == id);
            ViewBag.district = new SelectList(cities, "Id", "Name");
            return PartialView("CityPartial");
        }


        public List<Country> CountryGet()
        {
            List<Country> countries = _countryService.List();
            return countries;
        }

        public List<Category> CategoryGet()
        {
            List<Category> categories = _categoryService.List();
            return categories;
        }

        public IActionResult DistrictGet(int id)
        {
            List<District> districts = _districtService.List(x=>x.CityId == id);
            ViewBag.district = new SelectList(districts, "Id", "Name");
            return PartialView("DistrictPartial");
        }

        public void DropDown()
        {
            ViewBag.citylist = new SelectList(CountryGet(), "Id", "Name");
        }
    }
}
