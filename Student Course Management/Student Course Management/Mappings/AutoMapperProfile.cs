using Student_Course_Management.DTOs;
using Student_Course_Management.Models;
using AutoMapper;

namespace Student_Course_Management.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping from Student to StudentDto
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses.Select(c => c.Title).ToList()));

            // Mapping from StudentDto to Student
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses.Select(title => new Course { Title = title }).ToList()));
        }
    }
}
