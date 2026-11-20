using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Utulek.Application.Abstraction;
using UTB.Utulek.Application.ViewModels;
using UTB.Utulek.Domain.Entities;
using UTB.Utulek.Domain.Enums;
using UTB.Utulek.Domain.Interfaces;

namespace UTB.Utulek.Web.Controllers;

[Authorize(Roles = nameof(UserRole.Customer))]
public class VirtualAdoptionController : Controller
{
    private readonly IVirtualAdoptionAppService _adoptionAppService;
    private readonly IAnimalAppService _animalAppService;
    private readonly ICurrentUserService _currentUserService;

    public VirtualAdoptionController(IVirtualAdoptionAppService adoptionAppService, IAnimalAppService animalAppService, ICurrentUserService currentUserService)
    {
        _adoptionAppService = adoptionAppService;
        _animalAppService = animalAppService;
        _currentUserService = currentUserService;
    }

    public async Task<IActionResult> Index()
    {
        IApplicationUser? user = await _currentUserService.GetCurrentUser(User);
        if (user == null)
        {
            return Challenge();
        }

        IList<VirtualAdoption> adoptions = _adoptionAppService.SelectForUser(user.Id);
        return View(adoptions);
    }

    [HttpGet]
    public IActionResult Create(int animalId)
    {
        Animal? animal = _animalAppService.GetById(animalId);
        if (animal == null)
        {
            return NotFound();
        }

        VirtualAdoptionCreateViewModel model = new VirtualAdoptionCreateViewModel
        {
            AnimalId = animal.Id,
            AnimalName = animal.Name
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VirtualAdoptionCreateViewModel model)
    {
        Animal? animal = _animalAppService.GetById(model.AnimalId);
        if (animal == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            // Jméno zvířete se bere z databáze, ne z formuláře.
            model.AnimalName = animal.Name;
            return View(model);
        }

        // UserId se nikdy nebere z formuláře, jen z přihlášeného uživatele.
        IApplicationUser? user = await _currentUserService.GetCurrentUser(User);
        if (user == null)
        {
            return Challenge();
        }

        if (!_adoptionAppService.Create(user.Id, model))
        {
            return NotFound();
        }

        TempData["Success"] = $"Děkujeme, virtuálně jste adoptovali zvíře {animal.Name}.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int id)
    {
        IApplicationUser? user = await _currentUserService.GetCurrentUser(User);
        if (user == null)
        {
            return Challenge();
        }

        if (!_adoptionAppService.Cancel(id, user.Id))
        {
            return NotFound();
        }

        TempData["Success"] = "Adopce byla zrušena.";
        return RedirectToAction(nameof(Index));
    }
}
