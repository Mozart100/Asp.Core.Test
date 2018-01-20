using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCore.Dto.Poco;
using TestCore.Model;

namespace TestCore.Dto
{
    public interface IDtoMapper
    {
        IEnumerable<StudentDto> ConvertToStudentDtos(IEnumerable<Student> students);
    }

    public class DtoMapper : IDtoMapper
    {
        private IMapper _mapper;

        public DtoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Student, StudentDto>()
                .ForMember(des => des.FirstName, src => src.MapFrom(x => x.FirstMidName))
                //.ForMember(des=>des.BirthDate, src =>src. DateTime.Now)
                ;

            });

            _mapper = config.CreateMapper();
        }


        public IEnumerable<StudentDto> ConvertToStudentDtos(IEnumerable<Student> students)
        {
            var dtos = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(students);
            return dtos;
        }
    }
}
