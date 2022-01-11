using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        // Look for any students.
        if (context.Students.Any())
        {
            return;   // DB has been seeded
        }

        if (!await context.Students.AnyAsync())
        {
            await context.Students.AddRangeAsync(GetPreconfiguredStudent());
            await context.SaveChangesAsync();
        }

        if (!await context.Pizzas.AnyAsync())
        {
            await context.Pizzas.AddRangeAsync(GetPreconfiguredPizza());
            await context.SaveChangesAsync();
        }

        if (!await context.Instructors.AnyAsync())
        {
            await context.Instructors.AddRangeAsync(GetPreconfiguredInstructor());
            await context.SaveChangesAsync();
        }

        if (!await context.Departments.AnyAsync())
        {
            await context.Departments.AddRangeAsync(GetPreconfiguredDepartment(context));
            await context.SaveChangesAsync();
        }

        if (!await context.Courses.AnyAsync())
        {
            await context.Courses.AddRangeAsync(GetPreconfiguredCourses(context));
            await context.SaveChangesAsync();
        }

        if (!await context.OfficeAssignments.AnyAsync())
        {
            await context.OfficeAssignments.AddRangeAsync(GetPreconfiguredOfficeAssignment(context));
            await context.SaveChangesAsync();
        }

        if (!await context.CourseAssignments.AnyAsync())
        {
            await context.CourseAssignments.AddRangeAsync(GetPreconfiguredCourseAssignment(context));
            await context.SaveChangesAsync();
        }

        if (!await context.Enrollments.AnyAsync())
        {
            await context.Enrollments.AddRangeAsync(GetPreconfiguredEnrollment(context));
            await context.SaveChangesAsync();
        }

    }

    static IEnumerable<Student> GetPreconfiguredStudent()
    {
        return new List<Student>{
            new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
        };
    }

    static IEnumerable<Pizza> GetPreconfiguredPizza()
    {
        return
            new List<Pizza>{
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false ,Size = PizzaSize.Small},
                new Pizza { Id = 2, Name = "Vietnamese Pizza", IsGlutenFree = true ,Size = PizzaSize.Large},
                new Pizza { Id = 3, Name = "Japanese Pizza", IsGlutenFree = false ,Size = PizzaSize.Medium},
                new Pizza { Id = 4, Name = "Veggie", IsGlutenFree = true ,Size = PizzaSize.Large}
            };

    }

    static IEnumerable<Instructor> GetPreconfiguredInstructor()
    {
        return new List<Instructor>{
            new Instructor { FirstMidName = "Kim",LastName = "Abercrombie",HireDate = DateTime.Parse("1995-03-11") },
            new Instructor { FirstMidName = "Fadi",LastName = "Fakhouri",HireDate = DateTime.Parse("2002-07-06") },
            new Instructor { FirstMidName = "Roger",   LastName = "Harui",HireDate = DateTime.Parse("1998-07-01") },
            new Instructor { FirstMidName = "Candace", LastName = "Kapoor",HireDate = DateTime.Parse("2001-01-15") },
            new Instructor { FirstMidName = "Roger",   LastName = "Zheng",HireDate = DateTime.Parse("2004-02-12") }
        };
    }

    static IEnumerable<Department> GetPreconfiguredDepartment(ApplicationDbContext context)
    {
        var departments = new List<Department> {
            new Department{Name = "Economics",Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                InstructorID = context.Instructors.Single(i => i.LastName == "Abercrombie").ID,
            },
            new Department { Name = "Mathematics", Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                InstructorID  = context.Instructors.Single(i => i.LastName == "Fakhouri").ID},
            new Department { Name = "Engineering", Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                InstructorID  = context.Instructors.Single(i => i.LastName == "Harui").ID},
            new Department { Name = "English",   Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                InstructorID  =  context.Instructors.Single(i => i.LastName == "Kapoor").ID}
        };

        return departments;
    }

    static IEnumerable<Course> GetPreconfiguredCourses(ApplicationDbContext context)
    {
        var courses = new List<Course>
           {
                    new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                        DepartmentID = context.Departments.Single( s => s.Name == "Engineering").DepartmentID
                    },
                    new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                        DepartmentID = context.Departments.Single( s => s.Name == "Economics").DepartmentID
                    },
                    new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                        DepartmentID = context.Departments.First( s => s.Name == "Economics").DepartmentID
                    },
                    new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                        DepartmentID = context.Departments.First( s => s.Name == "Mathematics").DepartmentID
                    },
                    new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                        DepartmentID = context.Departments.First( s => s.Name == "Mathematics").DepartmentID
                    },
                    new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                        DepartmentID = context.Departments.First( s => s.Name == "English").DepartmentID
                    },
                    new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                        DepartmentID = context.Departments.First( s => s.Name == "English").DepartmentID
                    },
           };

        return courses;

    }
    private static IEnumerable<OfficeAssignment> GetPreconfiguredOfficeAssignment(ApplicationDbContext context)
    {
        var officeAssignments = new List<OfficeAssignment>{
            new OfficeAssignment {
                InstructorID = context.Instructors.First( i => i.LastName == "Fakhouri").ID,
                Location = "Smith 17" },
            new OfficeAssignment {
                InstructorID = context.Instructors.First( i => i.LastName == "Harui").ID,
                Location = "Gowan 27" },
            new OfficeAssignment {
                InstructorID = context.Instructors.First( i => i.LastName == "Kapoor").ID,
                Location = "Thompson 304" },
        };
        return officeAssignments;
    }

    static IEnumerable<CourseAssignment> GetPreconfiguredCourseAssignment(ApplicationDbContext context)
    {
        var courseAssignments = new List<CourseAssignment>
        {
            new CourseAssignment {
                CourseID = context.Courses.First(c => c.Title == "Chemistry" ).CourseID,
                InstructorID = context.Instructors.First(i => i.LastName == "Kapoor").ID
                },
            new CourseAssignment {
                CourseID = context.Courses.First(c => c.Title == "Chemistry" ).CourseID,
                InstructorID = context.Instructors.First(i => i.LastName == "Harui").ID
                },
            new CourseAssignment {
                CourseID = context.Courses.First(c => c.Title == "Microeconomics" ).CourseID,
                InstructorID =context.Instructors.First(i => i.LastName == "Zheng").ID
                },
            new CourseAssignment {
                CourseID = context.Courses.First(c => c.Title == "Macroeconomics" ).CourseID,
                InstructorID = context.Instructors.First(i => i.LastName == "Zheng").ID
                },
            new CourseAssignment {
                CourseID = context.Courses.First(c => c.Title == "Calculus" ).CourseID,
                InstructorID = context.Instructors.First(i => i.LastName == "Fakhouri").ID
                },
            new CourseAssignment {
                CourseID = context.Courses.First(c => c.Title == "Trigonometry" ).CourseID,
                InstructorID = context.Instructors.First(i => i.LastName == "Harui").ID
                },
            new CourseAssignment {
                CourseID = context.Courses.First(c => c.Title == "Composition" ).CourseID,
                InstructorID = context.Instructors.First(i => i.LastName == "Abercrombie").ID
                },
            new CourseAssignment {
                CourseID = context.Courses.First(c => c.Title == "Literature" ).CourseID,
                InstructorID = context.Instructors.First(i => i.LastName == "Abercrombie").ID
                },
        };
        return courseAssignments;
    }

    static IEnumerable<Enrollment> GetPreconfiguredEnrollment(ApplicationDbContext context)
    {
        var enrollments = new List<Enrollment>
        {
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Alexander").ID,
                CourseID = context.Courses.First(c => c.Title == "Chemistry" ).CourseID,
                Grade = Grade.A},
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Alexander").ID,
                CourseID = context.Courses.First(c => c.Title == "Microeconomics" ).CourseID,
                Grade = Grade.C},
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Alexander").ID,
                CourseID = context.Courses.First(c => c.Title == "Macroeconomics" ).CourseID,
                Grade = Grade.B},
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Alonso").ID,
                CourseID = context.Courses.First(c => c.Title == "Calculus" ).CourseID,
                Grade = Grade.B},
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Alonso").ID,
                CourseID = context.Courses.First(c => c.Title == "Trigonometry" ).CourseID,
                Grade = Grade.B},
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Alonso").ID,
                CourseID = context.Courses.First(c => c.Title == "Composition" ).CourseID,
                Grade = Grade.B},
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Anand").ID,
                CourseID = context.Courses.First(c => c.Title == "Chemistry" ).CourseID
                },
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Anand").ID,
                CourseID = context.Courses.First(c => c.Title == "Microeconomics").CourseID,
                Grade = Grade.B },
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Barzdukas").ID,
                CourseID = context.Courses.First(c => c.Title == "Chemistry").CourseID,
                Grade = Grade.B},
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Li").ID,
                CourseID = context.Courses.First(c => c.Title == "Composition").CourseID,
                Grade = Grade.B},
            new Enrollment {
                StudentID = context.Students.First(s => s.LastName == "Justice").ID,
                CourseID = context.Courses.First(c => c.Title == "Literature").CourseID,
                Grade = Grade.B
                }
        };

        return enrollments;
    }
}
