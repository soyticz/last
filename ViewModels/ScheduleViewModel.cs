using wpf1.Abstracts;
namespace wpf1.ViewModels
{
    public class ScheduleViewModel : BaseNavigation
    {
        public ScheduleViewModel()
        {
            ViewMappings["Accepted"] = () => new ScheduleDatagridViewModel();
        }
    }
}
