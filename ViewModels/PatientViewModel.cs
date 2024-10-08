using System.ComponentModel;
using wpf1.Models;
using wpf1.Abstracts;
namespace wpf1.ViewModels
{
    public class PatientViewModel : BaseNavigation
    {
        public PatientViewModel()
        {
            ViewMappings["Patient"] = () => new PatientDatagridViewModel();
            // ViewMappings["Diagnosis"] = () => new DiagnosisViewModel();
        }
    }
}
