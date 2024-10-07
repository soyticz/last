using wpf1.Firebase.FirebaseRepository;
using wpf1.Interfaces;
using wpf1.Models;

namespace wpf1.ViewModels;

public class AddWindowViewModel
{
    private readonly FirestoreRepository _repository;
    public AddWindowViewModel()
    {
        _repository = FirestoreRepository.Instance;
    }
}
