using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using System.Collections.Generic;

namespace MagniUniveristy
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public List<TeacherDTO> GetTeachers(string query)
        {
            return _teacherRepository.GetTeachers(query);
        }

        public decimal CalculateWagesPaid()
        {
            decimal wagesPaid = 0;

            var teachers = GetTeachers(string.Empty);

            foreach (var item in teachers)
                wagesPaid += item.Salary;

            return wagesPaid;
        }

    }
}