using CollegeAdmission.Entity;
using CollegeAdmission.ViewModel;

namespace CollegeAdmission.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<CollegeDepartment, DepartmentViewModel>();
                config.CreateMap<DepartmentViewModel, CollegeDepartment>();
                config.CreateMap<UserViewModel, User>();
                config.CreateMap<CollegeViewModel, College>();
            });
        }
    }
}