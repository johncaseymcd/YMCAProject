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
                            LocationID = e.LocationID
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
                var courseNames = new List<string>();
                var memberNames = new List<string>();
                foreach(var course in entity.CoursesTaught)
                {
                    courseNames.Add(course.CourseName);
                }
                foreach(var member in entity.MembersTaught)
                {
                    memberNames.Add(member.Name);
                }

                return new InstructorDetail
                {
                    InstructorID = entity.InstructorID,
                    InstructorName = entity.InstructorName,
                    LocationID = entity.LocationID,
                    CoursesTaught = courseNames,
                    MembersTaught = memberNames
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
                            LocationID = e.LocationID
                        }
                    );

                return query.ToList();
            }
        }

        public InstructorDetail GetInstructorsByCourse(int courseID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var courseEntity =
                    ctx.Courses
                    .Single(e => e.CourseID == courseID);

                var instructor = courseEntity.Instructor;
                var courseNames = new List<string>();
                var memberNames = new List<string>();
                foreach(var course in instructor.CoursesTaught)
                {
                    courseNames.Add(course.CourseName);
                }
                foreach(var member in instructor.MembersTaught)
                {
                    memberNames.Add(member.Name);
                }

                return new InstructorDetail
                {
                    InstructorID = instructor.InstructorID,
                    InstructorName = instructor.InstructorName,
                    LocationID = instructor.LocationID,
                    CoursesTaught = courseNames,
                    MembersTaught = memberNames
                };
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
                entity.LocationID = model.LocationID;

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
