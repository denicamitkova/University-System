using Data1901321073.Context;
using Data1901321073.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private StudentSystemDBContext context = new StudentSystemDBContext();
        private GenericRepository<University> universityRepository;
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Teacher> teacherRepository;

        public GenericRepository<University> UniversityRepository
        {
            get
            {

                if (this.universityRepository == null)
                {
                    this.universityRepository = new GenericRepository<University>(context);
                }
                return universityRepository;
            }
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public GenericRepository<Teacher> TeacherRepository
        {
            get
            {

                if (this.teacherRepository == null)
                {
                    this.teacherRepository = new GenericRepository<Teacher>(context);
                }
                return teacherRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
