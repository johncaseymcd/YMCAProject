﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Models;
using YMCAProject.Data;
using YMCAProject.WebAPI.Data;

namespace YMCAProject.Services
{
    public class CourseService
    {
        public bool CreateCourse(CourseCreate model)
        {
            var entity = new Course
            {
                CourseName = model.CourseName,
                CourseDescription = model.CourseDescription,
                CourseCost = model.CourseCost,
                MaxCourseSize = model.MaxCourseSize,
                CourseStartDate = model.CourseStartDate,
                CourseEndDate = model.CourseEndDate
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<CourseListItem> GetAllCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Select(
                            e =>
                            new CourseListItem
                            {
                                CourseID = e.CourseID,
                                CourseName = e.CourseName,
                                CourseCost = e.CourseCost,
                                MaxCourseSize = e.MaxCourseSize,
                                HasAvailability = e.HasAvailability,
                                CourseStartDate = e.CourseStartDate,
                                CourseEndDate = e.CourseEndDate,
                                IsCurrentlyRunning = e.IsCurrentlyRunning,
                                // Instructor = e.Instructor,
                                // Location = e.Location,
                            }
                        );

                return query.ToList();
            }
        }

        public CourseDetail GetCourseByID(int courseID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseID == courseID);

                return
                    new CourseDetail
                    {
                        CourseID = entity.CourseID,
                        CourseName = entity.CourseName,
                        CourseDescription = entity.CourseDescription,
                        CourseCost = entity.CourseCost,
                        MaxCourseSize = entity.MaxCourseSize,
                        HasAvailability = entity.HasAvailability,
                        ListOfMembers = entity.ListOfMembers,
                        CourseStartDate = entity.CourseStartDate,
                        CourseEndDate = entity.CourseEndDate,
                        IsCurrentlyRunning = entity.IsCurrentlyRunning,
                        // Instructor = entity.Instructor,
                        // Location = entity.Location
                    };
            }
        }

        public IEnumerable<CourseListItem> GetOpenCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Courses
                    .Where(e => e.HasAvailability)
                    .Select(
                        e =>
                        new CourseListItem
                        {
                            CourseID = e.CourseID,
                            CourseName = e.CourseName,
                            CourseCost = e.CourseCost,
                            MaxCourseSize = e.MaxCourseSize,
                            HasAvailability = e.HasAvailability,
                            CourseStartDate = e.CourseStartDate,
                            CourseEndDate = e.CourseEndDate,
                            IsCurrentlyRunning = e.IsCurrentlyRunning,
                            // Instructor = e.Instructor,
                            // Location = e.Location
                        }
                    );

                return query.ToList();
            }
        }

        // Stretch goal
        // ------------
        public IEnumerable<CourseListItem> GetCurrentCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Where(e => e.IsCurrentlyRunning)
                        .Select(
                            e =>
                            new CourseListItem
                            {
                                CourseID = e.CourseID,
                                CourseName = e.CourseName,
                                CourseCost = e.CourseCost,
                                MaxCourseSize = e.MaxCourseSize,
                                HasAvailability = e.HasAvailability,
                                CourseStartDate = e.CourseStartDate,
                                CourseEndDate = e.CourseEndDate,
                                IsCurrentlyRunning = e.IsCurrentlyRunning,
                                // Instructor = e.Instructor,
                                // Location = e.Location
                            }
                        );

                return query.ToList();
            }
        }

        // Stretch goal
        // ------------
        //public bool AddCourseToCourse(int courseID, int courseID)
        //{
          //  using (var ctx = new ApplicationDbContext())
            //{
              //  var courseinvoice =
                //    ctx.Courses
                  //      .Single(e => e.CourseID == courseID);
        
                //var course =
                  //  ctx.Courses
                    //    .Single(e => e.CourseID == courseID);

                //course.Courses.Add(course);
                //return ctx.SaveChanges() > 0;
            //}
        //}

        // Stretch goal
        // ------------
        public IEnumerable<CourseListItem> GetCoursesByInstructor(int instructorID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Courses
                    .Where(e => e.Instructor.InstructorID == instructorID)
                    .Select(
                        e =>
                        new CourseListItem
                        {
                           CourseID = e.CourseID,
                            CourseName = e.CourseName,
                            CourseCost = e.CourseCost,
                            MaxCourseSize = e.MaxCourseSize,
                            HasAvailability = e.HasAvailability,
                            CourseStartDate = e.CourseStartDate,
                            CourseEndDate = e.CourseEndDate,
                            IsCurrentlyRunning = e.IsCurrentlyRunning,
                            // Instructor = e.Instructor,
                            // Location = e.Location
                        }
                    );

                return query.ToList();
            }
        }



        // Stretch goal
        // ------------
        public IEnumerable<CourseListItem> GetCoursesByLocation(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Where(e => e.Location.LocationID == locationID)
                        .Select(
                            e =>
                            new CourseListItem
                            {
                                CourseID = e.CourseID,
                                CourseName = e.CourseName,
                                CourseCost = e.CourseCost,
                                MaxCourseSize = e.MaxCourseSize,
                                HasAvailability = e.HasAvailability,
                                CourseStartDate = e.CourseStartDate,
                                CourseEndDate = e.CourseEndDate,
                                IsCurrentlyRunning = e.IsCurrentlyRunning,
                                // Instructor = e.Instructor,
                                // Location = e.Location
                            }
                        );
                
                    return query.ToList();
            }
        }

        public bool UpdateCourse(CourseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseID == model.CourseID);

                entity.CourseName = model.CourseName;
                entity.CourseDescription = model.CourseDescription;
                entity.CourseCost = model.CourseCost;
                entity.MaxCourseSize = model.MaxCourseSize;
                entity.CourseStartDate = model.CourseStartDate;
                entity.CourseEndDate = model.CourseEndDate;
                // entity.Instructor = model.Instructor;
                // entity.Location = model.Location;

                return ctx.SaveChanges() > 0;
            };
        }

        public bool DeleteCourse(int courseID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseID == courseID);

                ctx.Courses.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
