using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UTB.Utulek.Domain.Entities;
using UTB.Utulek.Application.Abstraction;

namespace UTB.Utulek.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AnimalController : Controller
{
    // Hodnota volby "Jiné" v selectu druhů (žádný skutečný druh nemá záporné Id).
    private const int OtherSpeciesId = -1;

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

    [HttpGet]
    public IActionResult Create()
    {
        LoadSpecies();
        return View(new Animal { BirthDate = DateTime.Today });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Animal animal)
    {
        if (animal.SpeciesId == null)
        {
            ModelState.AddModelError(nameof(Animal.SpeciesId), "Vyberte druh zvířete.");
        }
        else if (animal.SpeciesId == OtherSpeciesId && string.IsNullOrWhiteSpace(animal.OtherSpeciesName))
        {
            ModelState.AddModelError(nameof(Animal.OtherSpeciesName), "Napište, o jaký druh zvířete jde.");
        }

        if (ModelState.IsValid)
        {
            if (animal.SpeciesId == OtherSpeciesId)
            {
                // Vlastní druh se neukládá do tabulky druhů, patří jen k tomuto zvířeti.
                animal.SpeciesId = null;
                animal.OtherSpeciesName = animal.OtherSpeciesName!.Trim();
            }
            else
            {
                animal.OtherSpeciesName = null;
            }

            _animalAppService.Create(animal);
            return RedirectToAction(nameof(Index));
        }

        LoadSpecies();
        return View(animal);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        bool deleted = _animalAppService.Delete(id);
        if (deleted)
        {
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

    private void LoadSpecies()
    {
        List<SelectListItem> items = _animalAppService.SelectAllSpecies()
            .Select(s => new SelectListItem(s.Name, s.Id.ToString()))
            .ToList();
        items.Add(new SelectListItem("Jiné…", OtherSpeciesId.ToString()));

        ViewBag.Species = items;
    }
}
