using UTB.Utulek.Application.Abstraction;
using UTB.Utulek.Application.ViewModels;
using UTB.Utulek.Domain.Entities;
using UTB.Utulek.Domain.Repositories;

namespace UTB.Utulek.Application.Implementation;

public class VirtualAdoptionAppService : IVirtualAdoptionAppService
{
    private readonly IVirtualAdoptionRepository _adoptionRepository;
    private readonly IAnimalRepository _animalRepository;

    public VirtualAdoptionAppService(IVirtualAdoptionRepository adoptionRepository, IAnimalRepository animalRepository)
    {
        _adoptionRepository = adoptionRepository;
        _animalRepository = animalRepository;
    }

    public IList<VirtualAdoption> SelectForUser(string userId)
    {
        return _adoptionRepository.GetByUserWithAnimal(userId);
    }

    public bool Create(string userId, VirtualAdoptionCreateViewModel model)
    {
        if (_animalRepository.GetById(model.AnimalId) == null)
        {
            return false;
        }

        VirtualAdoption adoption = new VirtualAdoption
        {
            AnimalId = model.AnimalId,
            UserId = userId,
            MonthlyAmount = model.MonthlyAmount,
            Message = string.IsNullOrWhiteSpace(model.Message) ? null : model.Message.Trim(),
            StartDate = DateTime.UtcNow,
            IsActive = true
        };

        _adoptionRepository.Add(adoption);
        return true;
    }

    public bool Cancel(int id, string userId)
    {
        VirtualAdoption? adoption = _adoptionRepository.GetById(id);

        // Cizí adopci nelze zrušit, navenek se chová stejně jako neexistující.
        if (adoption == null || adoption.UserId != userId || !adoption.IsActive)
        {
            return false;
        }

        // Adopce se nemaže, jen se ukončí; v historii uživatele zůstane jako zrušená.
        adoption.IsActive = false;
        _adoptionRepository.Edit(adoption);
        return true;
    }
}
