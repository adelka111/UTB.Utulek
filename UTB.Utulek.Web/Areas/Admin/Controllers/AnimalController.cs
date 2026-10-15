using Microsoft.AspNetCore.Mvc;
using UTB.Utulek.Domain.Entities;
using UTB.Utulek.Application.Abstraction;

namespace UTB.Utulek.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AnimalController : Controller
{
    IAnimalAppService _animalAppService;
    public AnimalController(IAnimalAppService animalAppService)
    {
        _animalAppService = animalAppService;
    }

    public IActionResult Index()
    {
        IList<Animal> animals = _animalAppService.SelectAll();
        return View(animals);
    }
}
