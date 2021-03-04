using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Models;
using YMCAProject.Data;
using YMCAProject.WebAPI.Data;

namespace YMCAProject.Services
{
    public class InstructorService
    {
        public bool CreateInstructor(InstructorCreate model)
        {
            var entity = new Instructor
            {
                InstructorName = model.InstructorName,
                LocationID = model.LocationID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Instructors.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        } 

        public IEnumerable<InstructorListItem> GetAllInstructors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Instructors
                    .Select(
                        e => new InstructorListItem
                        {
                            InstructorID = e.InstructorID,
                            InstructorName = e.InstructorName,
                            Location = e.Location
                        }
                    );

                return query.ToList();
            }
        }

        public InstructorDetail GetInstructorByID(int instructorID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Instructors
                    .Single(e => e.InstructorID == instructorID);

                return new InstructorDetail
                {
                    InstructorID = entity.InstructorID,
                    InstrcutorName = entity.InstructorName,
                    Location = entity.Location,
                    CoursesTaught = entity.CoursesTaught,
                    MembersTaught = entity.MembersTaught
                };
            }
        }

        public IEnumerable<InstructorListItem> GetInstructorsByLocation(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Instructors
                    .Where(e => e.LocationID == locationID)
                    .Select(
                        e => new InstructorListItem
                        {
                            InstructorID = e.InstructorID,
                            InstructorName = e.InstructorName,
                            Location = e.Location
                        }
                    );

                return query.ToList();
            }
        }

        public IEnumerable<InstructorListItem> GetInstructorsByCourse(int courseID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var courseEntity =
                    ctx.Courses
                    .Single(e => e.CourseID == courseID);

                var instructorQuery =
                    ctx.Instructors
                    .Where(e => e.CoursesTaught.Contains(courseEntity))
                    .Select(
                        e => new InstructorListItem
                        {
                            InstructorID = e.InstructorID,
                            InstructorName = e.InstructorName,
                            Location = e.Location
                        }
                    );

                return instructorQuery.ToList();
            }
        }

        public bool UpdateInstructor(InstructorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Instructors
                    .Single(e => e.InstructorID == model.InstructorID);

                entity.InstructorName = model.InstructorName;
                entity.Location = model.Location;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteInstructor(int instructorID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Instructors
                    .Single(e => e.InstructorID == instructorID);

                ctx.Instructors.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
