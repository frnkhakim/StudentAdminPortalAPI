using AutoMapper;
using StudentAdminPortalAPI.DomainModels;
using DataModels = StudentAdminPortalAPI.DataModels;

namespace StudentAdminPortalAPI.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>()
                .ReverseMap();

            CreateMap<DataModels.Gender, Student>()
                .ReverseMap();

            CreateMap<DataModels.Address, Student>()
                .ReverseMap();

        }
        
    }
}
