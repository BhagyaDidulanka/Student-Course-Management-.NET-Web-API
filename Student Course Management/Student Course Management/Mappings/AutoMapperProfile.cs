using Student_Course_Management.DTOs;
using Student_Course_Management.Models;
using AutoMapper;

namespace Student_Course_Management.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses.Select(c => c.Title)));
            CreateMap<StudentDto, Student>();
        }
    }
}
