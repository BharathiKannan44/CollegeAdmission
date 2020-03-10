using CollegeAdmission.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeAdmission.ViewModel
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<CollegeDepartment,DepartmentViewModel>();
                config.CreateMap<UserViewModel, User>();
                config.CreateMap<DepartmentViewModel, CollegeDepartment>();
                config.CreateMap<CollegeViewModel, College>();
                config.CreateMap<CollegeViewModel, College>();
            });
        }
    }
}