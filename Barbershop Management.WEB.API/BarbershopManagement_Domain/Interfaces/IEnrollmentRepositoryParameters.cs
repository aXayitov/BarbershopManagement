using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Interfaces
{
    public interface IEnrollmentRepositoryParameters : IRepositoryBase<Enrollment>
    {
        List<Enrollment> FindAllEnrollments(EnrollmentQueryParameters queryParameters);
        Enrollment FindEnrollmentById(int id);
        Enrollment CreateEnrollment(Enrollment enrollment);
        Enrollment UpdateEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int id);
    }
}
