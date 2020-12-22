using Microsoft.AspNetCore.Identity;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Controllers
{
    public class Seeder
    {
        private readonly UserManager<User> _usermanager;
        private readonly RoleManager<Role> _rolemanager;
        private readonly RemoteStudyContext _context;

        public Seeder(UserManager<User> usermanager, RemoteStudyContext context, RoleManager<Role> roleManager)
        {
            _usermanager = usermanager;
            _context = context;
            _rolemanager = roleManager;
        }
        public async Task Seed()
        {
            string[] roleNames = { "Admin", "Teacher", "Student" };

            foreach (var x in roleNames)
            {
                if (_context.Roles.Where(r => r.Name == x).Count() == 0)
                {
                    await _rolemanager.CreateAsync(new Role { Name = x });
                }
            }

            if (!_context.Tags.Any())
            {
                _context.Tags.AddRange(
                new Tag { Id = Guid.Parse("26bb3a68-03c4-40ac-b36b-a0c105c97bb4"), Name = "Programming from scratch" },
                new Tag { Id = Guid.Parse("45839468-f85f-4d31-8d7c-d320e316528e"), Name = "Web design for advanced users" },
                new Tag { Id = Guid.Parse("7427036c-0765-4fad-85dc-eb0dc20d5dc9"), Name = "Full-stack development on Python" },
                new Tag { Id = Guid.Parse("2eafc5bf-c1c2-44f9-9dfd-82d1ae498ae7"), Name = "Data analysis in Jupiter" },
                new Tag { Id = Guid.Parse("c9622618-f8ba-46a0-89b4-ea9c9b9719be"), Name = "Networks and computer systems" },
                new Tag { Id = Guid.Parse("0bc53fb2-ee3a-42f1-a4ce-2f90e7ee12c4"), Name = "Algorithms theory" },
                new Tag { Id = Guid.Parse("45de5daf-31bd-4903-bd1c-16bc23b67c38"), Name = "Mobile programming" },
                new Tag { Id = Guid.Parse("4a5f6df1-fe20-4a42-8d3c-48e92ce93ef3"), Name = "C#/.NET" });
            }

            _context.SaveChanges();

            if (!_context.Subjects.Any())
            {
                _context.Subjects.AddRange(
                new Subject { Id = Guid.Parse("32d8f821-60ce-40dc-b799-c7b360789746"), Title = "iOS", Description = "iOS development" },
                new Subject { Id = Guid.Parse("b6e52fff-f18e-4dd8-b46c-d34960a3e109"), Title = "Android", Description = "Android development" },
                new Subject { Id = Guid.Parse("dd1e94b5-17a9-4550-bf61-c1b5bf23cbf4"), Title = "C#", Description = "C# developments" },
                new Subject { Id = Guid.Parse("d0d1b273-1173-4204-a661-d56c358db292"), Title = "Python", Description = "Python development" },
                new Subject { Id = Guid.Parse("015649d0-4107-43f3-ac99-0e73261e3817"), Title = "NodeJS", Description = "NodeJS development" });
            }

            _context.SaveChanges();

            if (!_context.Users.Any())
            {
                _context.Users.AddRange(
                new User { Id = Guid.Parse("e099b8db-f859-4089-97fd-c4d6c86b1f1a"), Email = "test_user1@gmail.com", NormalizedEmail = "TEST_USER1@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("32848a55-29a0-4bf5-bbe9-31e73c8de6d5"), Email = "test_user2@gmail.com", NormalizedEmail = "TEST_USER2@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("6d71b5f6-c860-4367-8536-13b49ba5c0b4"), Email = "test_user3@gmail.com", NormalizedEmail = "TEST_USER3@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("d0d1b273-1173-4204-a661-d56c358db292"), Email = "test_user4@gmail.com", NormalizedEmail = "TEST_USER4@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("74748c52-09ab-42b9-adfa-8df1516f0b4f"), Email = "test_user5@gmail.com", NormalizedEmail = "TEST_USER5@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("2a8bea88-5258-4b3f-9bf9-fb67b94b3638"), Email = "test_user6@gmail.com", NormalizedEmail = "TEST_USER6@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("4cd08acf-117f-46b1-8203-18ecee161a53"), Email = "test_user7@gmail.com", NormalizedEmail = "TEST_USER7@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("a5379e84-d0b6-4668-8cf1-9dea364a54d9"), Email = "test_user8@gmail.com", NormalizedEmail = "TEST_USER8@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("0db5c20f-b0c3-4c87-a437-fa2dbb884d47"), Email = "test_user9@gmail.com", NormalizedEmail = "TEST_USER9@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" },
                new User { Id = Guid.Parse("7eb97f70-db7a-489a-931d-7fb46b684699"), Email = "test_user10@gmail.com", NormalizedEmail = "TEST_USER10@GMAIL.COM", Password = "test123", PasswordHash = "AQAAAAEAACcQAAAAEG2Mg0kn+m3vp7vNruYEDWWSxrVKFK8CmcjHJEQZxJ6/RSfqgngBtJ7Mc8/jByzXMw==" });
            }

            _context.SaveChanges();
            
            if (!_context.HomeAssignmentUsers.Any())
            {
                _context.UserRoles.AddRange(
                new UserRole { UserId = Guid.Parse("e099b8db-f859-4089-97fd-c4d6c86b1f1a"), RoleId = _context.Roles.First(x => x.Name == "Teacher").Id },
                new UserRole { UserId = Guid.Parse("32848a55-29a0-4bf5-bbe9-31e73c8de6d5"), RoleId = _context.Roles.First(x => x.Name == "Teacher").Id },
                new UserRole { UserId = Guid.Parse("6d71b5f6-c860-4367-8536-13b49ba5c0b4"), RoleId = _context.Roles.First(x => x.Name == "Teacher").Id },
                new UserRole { UserId = Guid.Parse("d0d1b273-1173-4204-a661-d56c358db292"), RoleId = _context.Roles.First(x => x.Name == "Student").Id },
                new UserRole { UserId = Guid.Parse("74748c52-09ab-42b9-adfa-8df1516f0b4f"), RoleId = _context.Roles.First(x => x.Name == "Student").Id },
                new UserRole { UserId = Guid.Parse("2a8bea88-5258-4b3f-9bf9-fb67b94b3638"), RoleId = _context.Roles.First(x => x.Name == "Student").Id },
                new UserRole { UserId = Guid.Parse("4cd08acf-117f-46b1-8203-18ecee161a53"), RoleId = _context.Roles.First(x => x.Name == "Student").Id },
                new UserRole { UserId = Guid.Parse("a5379e84-d0b6-4668-8cf1-9dea364a54d9"), RoleId = _context.Roles.First(x => x.Name == "Student").Id },
                new UserRole { UserId = Guid.Parse("0db5c20f-b0c3-4c87-a437-fa2dbb884d47"), RoleId = _context.Roles.First(x => x.Name == "Student").Id },
                new UserRole { UserId = Guid.Parse("7eb97f70-db7a-489a-931d-7fb46b684699"), RoleId = _context.Roles.First(x => x.Name == "Student").Id });
            }

            _context.SaveChanges();

            if (!_context.Profiles.Any())
            {
                _context.Profiles.AddRange(
                new Profile { Id = Guid.Parse("44a97b54-de82-4967-81f3-c56094d6f546"), FirstName = "FirstName1", LastName = "LastName1", Phone = "+380954728466", UserId = Guid.Parse("e099b8db-f859-4089-97fd-c4d6c86b1f1a") },
                new Profile { Id = Guid.Parse("4cdb29cc-411d-4d0c-8da7-be04a67fb182"), FirstName = "FirstName2", LastName = "LastName2", Phone = "+380954728466", UserId = Guid.Parse("32848a55-29a0-4bf5-bbe9-31e73c8de6d5") },
                new Profile { Id = Guid.Parse("fc36bf40-1763-4952-a946-a55a8a5cc137"), FirstName = "FirstName3", LastName = "LastName3", Phone = "+380954728466", UserId = Guid.Parse("6d71b5f6-c860-4367-8536-13b49ba5c0b4") },
                new Profile { Id = Guid.Parse("c3cb4610-7693-46cb-acef-b23e191e064c"), FirstName = "FirstName4", LastName = "LastName4", Phone = "+380954728466", UserId = Guid.Parse("d0d1b273-1173-4204-a661-d56c358db292") },
                new Profile { Id = Guid.Parse("b5aaa234-2470-4593-8225-a9eff7f4b923"), FirstName = "FirstName5", LastName = "LastName5", Phone = "+380954728466", UserId = Guid.Parse("74748c52-09ab-42b9-adfa-8df1516f0b4f") },
                new Profile { Id = Guid.Parse("8afc0372-77b9-4602-b927-695f1bc5f5ec"), FirstName = "FirstName6", LastName = "LastName6", Phone = "+380954728466", UserId = Guid.Parse("2a8bea88-5258-4b3f-9bf9-fb67b94b3638") },
                new Profile { Id = Guid.Parse("2abc9098-fb95-4805-bb53-5797c37f7c59"), FirstName = "FirstName7", LastName = "LastName7", Phone = "+380954728466", UserId = Guid.Parse("4cd08acf-117f-46b1-8203-18ecee161a53") },
                new Profile { Id = Guid.Parse("cb2ac3a8-e491-433a-a8eb-c33da18bb938"), FirstName = "FirstName8", LastName = "LastName8", Phone = "+380954728466", UserId = Guid.Parse("a5379e84-d0b6-4668-8cf1-9dea364a54d9") },
                new Profile { Id = Guid.Parse("e6c0eb73-38d7-4bf9-9944-acd53c790730"), FirstName = "FirstName9", LastName = "LastName9", Phone = "+380954728466", UserId = Guid.Parse("0db5c20f-b0c3-4c87-a437-fa2dbb884d47") },
                new Profile { Id = Guid.Parse("d79442ee-09d8-4fbf-91ab-2dd8c1bf8885"), FirstName = "FirstName10", LastName = "LastName10", Phone = "+380954728466", UserId = Guid.Parse("7eb97f70-db7a-489a-931d-7fb46b684699") });
            }

            _context.SaveChanges();

            if (!_context.Courses.Any())
            {
                _context.Courses.AddRange(
                new Course { Id = Guid.Parse("8c15afce-f75b-4856-bfa1-b247b5689f6f"), Name = "Mobile development for beginners", Description = "Description of the course of mobile development", SubjectId = Guid.Parse("b6e52fff-f18e-4dd8-b46c-d34960a3e109"), TeacherId = Guid.Parse("e099b8db-f859-4089-97fd-c4d6c86b1f1a") },
                new Course { Id = Guid.Parse("f3f8b6c1-1d79-4176-9aac-7201b60c3f5f"), Name = "Mobile development for advanced programmers", Description = "Description of the course of mobile development 2", SubjectId = Guid.Parse("b6e52fff-f18e-4dd8-b46c-d34960a3e109"), TeacherId = Guid.Parse("e099b8db-f859-4089-97fd-c4d6c86b1f1a") },
                new Course { Id = Guid.Parse("23c04dd7-38a0-487e-8114-41598debbae1"), Name = "Mobile development on Kotlin", Description = "Description of the course of mobile development 3", SubjectId = Guid.Parse("b6e52fff-f18e-4dd8-b46c-d34960a3e109"), TeacherId = Guid.Parse("e099b8db-f859-4089-97fd-c4d6c86b1f1a") },
                new Course { Id = Guid.Parse("b2bbad65-5731-4722-bc16-90bddea22d75"), Name = "Back-end development on C#", Description = "Description of the course of C#", SubjectId = Guid.Parse("dd1e94b5-17a9-4550-bf61-c1b5bf23cbf4"), TeacherId = Guid.Parse("32848a55-29a0-4bf5-bbe9-31e73c8de6d5") },
                new Course { Id = Guid.Parse("7b1dda37-d27b-4f4b-a581-30dcf4f509ac"), Name = "Back-end development on C# (Vol.2)", Description = "Description of the course of C# (Vol.2)", SubjectId = Guid.Parse("dd1e94b5-17a9-4550-bf61-c1b5bf23cbf4"), TeacherId = Guid.Parse("32848a55-29a0-4bf5-bbe9-31e73c8de6d5") },
                new Course { Id = Guid.Parse("4c0439ba-f520-41d4-b509-d7b3bb5c68e4"), Name = "Back-end development on Python", Description = "Description of the course of Python programming", SubjectId = Guid.Parse("d0d1b273-1173-4204-a661-d56c358db292"), TeacherId = Guid.Parse("6d71b5f6-c860-4367-8536-13b49ba5c0b4") },
                new Course { Id = Guid.Parse("4e7b1a0d-832c-4f98-9927-970a67bd8273"), Name = "Python data analysis", Description = "Description of the course of Python programming 2", SubjectId = Guid.Parse("d0d1b273-1173-4204-a661-d56c358db292"), TeacherId = Guid.Parse("6d71b5f6-c860-4367-8536-13b49ba5c0b4") });
            }

            _context.SaveChanges();

            if (!_context.Lessons.Any())
            {
                _context.Lessons.AddRange(
                new Lesson { Id = Guid.Parse("de052e14-5195-4f6d-90a1-eb91f3157f47"), Text = "Lesson 1 of Mobile development for beginners", CourseId = Guid.Parse("8c15afce-f75b-4856-bfa1-b247b5689f6f") },
                new Lesson { Id = Guid.Parse("78f736b5-2a7d-4b82-84dc-89242f31b9ca"), Text = "Lesson 2 of Mobile development for beginners", CourseId = Guid.Parse("8c15afce-f75b-4856-bfa1-b247b5689f6f") },
                new Lesson { Id = Guid.Parse("141dc365-5dd0-49b4-84bd-c528b7ca63f1"), Text = "Lesson 3 of Mobile development for beginners", CourseId = Guid.Parse("8c15afce-f75b-4856-bfa1-b247b5689f6f") },
                new Lesson { Id = Guid.Parse("9d1189ea-5f63-4c23-a007-8ea55a434b03"), Text = "Lesson 1 of Mobile development for advanced programmers", CourseId = Guid.Parse("f3f8b6c1-1d79-4176-9aac-7201b60c3f5f") },
                new Lesson { Id = Guid.Parse("a32b1ffc-f721-48d0-80a2-043d8708c1e2"), Text = "Lesson 2 of Mobile development for advanced programmers", CourseId = Guid.Parse("f3f8b6c1-1d79-4176-9aac-7201b60c3f5f") },
                new Lesson { Id = Guid.Parse("f057ba52-a3d0-4352-84cc-3d215bcaa5c8"), Text = "Lesson 1 of Mobile development on Kotlin", CourseId = Guid.Parse("23c04dd7-38a0-487e-8114-41598debbae1") },
                new Lesson { Id = Guid.Parse("63dbe750-8946-4bc7-8b9d-5dbf4134bb59"), Text = "Lesson 1 of Back-end development on C#", CourseId = Guid.Parse("b2bbad65-5731-4722-bc16-90bddea22d75") },
                new Lesson { Id = Guid.Parse("b0b5e52d-8b33-4b78-98d2-e5042bbef35c"), Text = "Lesson 2 of Back-end development on C#", CourseId = Guid.Parse("b2bbad65-5731-4722-bc16-90bddea22d75") },
                new Lesson { Id = Guid.Parse("164a8d60-3631-41ec-b009-6cf3c2c62534"), Text = "Lesson 1 of Back-end development on C# (Vol.2)", CourseId = Guid.Parse("7b1dda37-d27b-4f4b-a581-30dcf4f509ac") },
                new Lesson { Id = Guid.Parse("521954e2-0906-493b-87d4-51f2e7a25848"), Text = "Lesson 2 of Back-end development on C# (Vol.2)", CourseId = Guid.Parse("7b1dda37-d27b-4f4b-a581-30dcf4f509ac") },
                new Lesson { Id = Guid.Parse("dbc21c44-caa0-4057-8c23-b31ce852e639"), Text = "Lesson 3 of Back-end development on C# (Vol.2)", CourseId = Guid.Parse("7b1dda37-d27b-4f4b-a581-30dcf4f509ac") },
                new Lesson { Id = Guid.Parse("39d2bdc3-73b4-4ff7-a704-1d43416397be"), Text = "Lesson 1 of Back-end development on Python", CourseId = Guid.Parse("4c0439ba-f520-41d4-b509-d7b3bb5c68e4") },
                new Lesson { Id = Guid.Parse("489887c7-87ed-4a6f-8d52-3020971b8329"), Text = "Lesson 2 of Back-end development on Python", CourseId = Guid.Parse("4c0439ba-f520-41d4-b509-d7b3bb5c68e4") },
                new Lesson { Id = Guid.Parse("93727a94-036b-43c2-97a8-241d1ea4f492"), Text = "Lesson 1 of Python data analysis", CourseId = Guid.Parse("4e7b1a0d-832c-4f98-9927-970a67bd8273") },
                new Lesson { Id = Guid.Parse("643e736e-2626-4562-9b50-bbda17ef2f53"), Text = "Lesson 2 of Python data analysis", CourseId = Guid.Parse("4e7b1a0d-832c-4f98-9927-970a67bd8273") },
                new Lesson { Id = Guid.Parse("c0c85a63-068e-41f8-b70d-c694ae84fade"), Text = "Lesson 3 of Python data analysis", CourseId = Guid.Parse("4e7b1a0d-832c-4f98-9927-970a67bd8273") });
            }

            _context.SaveChanges();

            if (!_context.CourseTags.Any())
            {
                _context.CourseTags.AddRange(
                new CourseTag { Id = Guid.Parse("036f9706-c570-4bfc-bbfb-d2b15b493f4b"), CourseId = Guid.Parse("8c15afce-f75b-4856-bfa1-b247b5689f6f"), TagId = Guid.Parse("45de5daf-31bd-4903-bd1c-16bc23b67c38") },
                new CourseTag { Id = Guid.Parse("8e637852-8283-4e34-ae51-8e63d50b6c28"), CourseId = Guid.Parse("f3f8b6c1-1d79-4176-9aac-7201b60c3f5f"), TagId = Guid.Parse("45de5daf-31bd-4903-bd1c-16bc23b67c38") },
                new CourseTag { Id = Guid.Parse("8d6cacb3-f4cd-4ae3-86ed-6b1e4635a72b"), CourseId = Guid.Parse("23c04dd7-38a0-487e-8114-41598debbae1"), TagId = Guid.Parse("45de5daf-31bd-4903-bd1c-16bc23b67c38") },
                new CourseTag { Id = Guid.Parse("cc379d67-0dc9-44d2-aeba-945a2a9496af"), CourseId = Guid.Parse("23c04dd7-38a0-487e-8114-41598debbae1"), TagId = Guid.Parse("26bb3a68-03c4-40ac-b36b-a0c105c97bb4") },
                new CourseTag { Id = Guid.Parse("339f1ed4-46e5-4345-9ed5-6ae4f1cfc9c6"), CourseId = Guid.Parse("7b1dda37-d27b-4f4b-a581-30dcf4f509ac"), TagId = Guid.Parse("4a5f6df1-fe20-4a42-8d3c-48e92ce93ef3") },
                new CourseTag { Id = Guid.Parse("cc523181-061f-4055-b4a5-d84137d2461b"), CourseId = Guid.Parse("b2bbad65-5731-4722-bc16-90bddea22d75"), TagId = Guid.Parse("4a5f6df1-fe20-4a42-8d3c-48e92ce93ef3") },
                new CourseTag { Id = Guid.Parse("7222cbfb-2c09-4aaa-ba9e-598920a166aa"), CourseId = Guid.Parse("b2bbad65-5731-4722-bc16-90bddea22d75"), TagId = Guid.Parse("26bb3a68-03c4-40ac-b36b-a0c105c97bb4") });
            }

            _context.SaveChanges();

            if (!_context.UserCourses.Any())
            {
                _context.UserCourses.AddRange(
                new UserCourse { Id = Guid.Parse("b9227b2d-4df0-425d-8793-d93bc3f4baad"), CourseId = Guid.Parse("8c15afce-f75b-4856-bfa1-b247b5689f6f"), UserId = Guid.Parse("4cd08acf-117f-46b1-8203-18ecee161a53"), HasAccess = false, IsFavourite = false },
                new UserCourse { Id = Guid.Parse("7ac790c7-2e2c-4cde-ad7e-b56a73977142"), CourseId = Guid.Parse("f3f8b6c1-1d79-4176-9aac-7201b60c3f5f"), UserId = Guid.Parse("4cd08acf-117f-46b1-8203-18ecee161a53"), HasAccess = true, IsFavourite = false },
                new UserCourse { Id = Guid.Parse("fecdadc6-d788-4c38-895a-821f95600b5a"), CourseId = Guid.Parse("23c04dd7-38a0-487e-8114-41598debbae1"), UserId = Guid.Parse("7eb97f70-db7a-489a-931d-7fb46b684699"), HasAccess = true, IsFavourite = true },
                new UserCourse { Id = Guid.Parse("ed3f9989-26c7-4365-b16d-a9a12d598e57"), CourseId = Guid.Parse("23c04dd7-38a0-487e-8114-41598debbae1"), UserId = Guid.Parse("74748c52-09ab-42b9-adfa-8df1516f0b4f"), HasAccess = true, IsFavourite = true },
                new UserCourse { Id = Guid.Parse("0794d411-ba51-4016-8b4b-620bf73207a9"), CourseId = Guid.Parse("7b1dda37-d27b-4f4b-a581-30dcf4f509ac"), UserId = Guid.Parse("2a8bea88-5258-4b3f-9bf9-fb67b94b3638"), HasAccess = true, IsFavourite = false },
                new UserCourse { Id = Guid.Parse("0c049b42-68c0-449b-a2fd-74566279bb88"), CourseId = Guid.Parse("b2bbad65-5731-4722-bc16-90bddea22d75"), UserId = Guid.Parse("0db5c20f-b0c3-4c87-a437-fa2dbb884d47"), HasAccess = true, IsFavourite = false },
                new UserCourse { Id = Guid.Parse("af0deced-f770-4bec-acd5-281aacab97b5"), CourseId = Guid.Parse("b2bbad65-5731-4722-bc16-90bddea22d75"), UserId = Guid.Parse("7eb97f70-db7a-489a-931d-7fb46b684699"), HasAccess = false, IsFavourite = false });
            }
            
            _context.SaveChanges();

            if (!_context.Comments.Any())
            {
                _context.Comments.AddRange(
                new Comment { LessonId = Guid.Parse("78f736b5-2a7d-4b82-84dc-89242f31b9ca"), UserId = Guid.Parse("4cd08acf-117f-46b1-8203-18ecee161a53"), Text = "Great lesson!" },
                new Comment { LessonId = Guid.Parse("de052e14-5195-4f6d-90a1-eb91f3157f47"), UserId = Guid.Parse("4cd08acf-117f-46b1-8203-18ecee161a53"), Text = "Nice teacher." },
                new Comment { LessonId = Guid.Parse("78f736b5-2a7d-4b82-84dc-89242f31b9ca"), UserId = Guid.Parse("7eb97f70-db7a-489a-931d-7fb46b684699"), Text = "I love it!" },
                new Comment { LessonId = Guid.Parse("141dc365-5dd0-49b4-84bd-c528b7ca63f1"), UserId = Guid.Parse("74748c52-09ab-42b9-adfa-8df1516f0b4f"), Text = "Don`t like this course." },
                new Comment { LessonId = Guid.Parse("141dc365-5dd0-49b4-84bd-c528b7ca63f1"), UserId = Guid.Parse("2a8bea88-5258-4b3f-9bf9-fb67b94b3638"), Text = "Good spelling." },
                new Comment { LessonId = Guid.Parse("39d2bdc3-73b4-4ff7-a704-1d43416397be"), UserId = Guid.Parse("0db5c20f-b0c3-4c87-a437-fa2dbb884d47"), Text = "Can you give some more examples?" },
                new Comment { LessonId = Guid.Parse("39d2bdc3-73b4-4ff7-a704-1d43416397be"), UserId = Guid.Parse("7eb97f70-db7a-489a-931d-7fb46b684699"), Text = "Thanks for nice lesson." });
            }
 
            _context.SaveChanges();

            if (!_context.HomeAssignments.Any())
            {
                _context.HomeAssignments.AddRange(
                new HomeAssignment { Id = Guid.Parse("b4c5dd65-06df-4403-a99f-1c261d35662d"), LessonId = Guid.Parse("de052e14-5195-4f6d-90a1-eb91f3157f47"), Text = "Text of Home assignment 1" },
                new HomeAssignment { Id = Guid.Parse("8c1ad993-fd92-4b79-895f-0a42f535a89c"), LessonId = Guid.Parse("9d1189ea-5f63-4c23-a007-8ea55a434b03"), Text = "Text of Home assignment 2" },
                new HomeAssignment { Id = Guid.Parse("8a41d317-4f4c-4de3-b7b5-c46a32c6e46c"), LessonId = Guid.Parse("78f736b5-2a7d-4b82-84dc-89242f31b9ca"), Text = "Text of Home assignment 3" },
                new HomeAssignment { Id = Guid.Parse("f2ad7b77-e746-4453-8980-5706d5c9c950"), LessonId = Guid.Parse("a32b1ffc-f721-48d0-80a2-043d8708c1e2"), Text = "Text of Home assignment 4" },
                new HomeAssignment { Id = Guid.Parse("d9a9d06a-30df-4e33-844f-830a5cdafa07"), LessonId = Guid.Parse("141dc365-5dd0-49b4-84bd-c528b7ca63f1"), Text = "Text of Home assignment 5" },
                new HomeAssignment { Id = Guid.Parse("ca93b78d-6906-4908-bcae-297a97342292"), LessonId = Guid.Parse("f057ba52-a3d0-4352-84cc-3d215bcaa5c8"), Text = "Text of Home assignment 6" },
                new HomeAssignment { Id = Guid.Parse("d421e6ec-a952-4e08-9498-022e67a202c4"), LessonId = Guid.Parse("39d2bdc3-73b4-4ff7-a704-1d43416397be"), Text = "Text of Home assignment 7" });
            }

            _context.SaveChanges();

            if (!_context.HomeAssignmentUsers.Any())
            {
                _context.HomeAssignmentUsers.AddRange(
                new HomeAssignmentUser { Id = Guid.Parse("8c3836b0-0dcb-41c0-8296-d8b85e783d79"), HomeAssignmentId = Guid.Parse("b4c5dd65-06df-4403-a99f-1c261d35662d"), UserId = Guid.Parse("d0d1b273-1173-4204-a661-d56c358db292") },
                new HomeAssignmentUser { Id = Guid.Parse("83f0d4ac-0645-48ab-a397-71a6f1b340ac"), HomeAssignmentId = Guid.Parse("8c1ad993-fd92-4b79-895f-0a42f535a89c"), UserId = Guid.Parse("d0d1b273-1173-4204-a661-d56c358db292") },
                new HomeAssignmentUser { Id = Guid.Parse("bfa780fd-13c9-4cae-a466-0f4f3fa7960b"), HomeAssignmentId = Guid.Parse("b4c5dd65-06df-4403-a99f-1c261d35662d"), UserId = Guid.Parse("74748c52-09ab-42b9-adfa-8df1516f0b4f") },
                new HomeAssignmentUser { Id = Guid.Parse("accaa3a1-6dea-4fd9-ad80-15075e5c6bde"), HomeAssignmentId = Guid.Parse("8c1ad993-fd92-4b79-895f-0a42f535a89c"), UserId = Guid.Parse("74748c52-09ab-42b9-adfa-8df1516f0b4f") },
                new HomeAssignmentUser { Id = Guid.Parse("f91e5b46-e817-483d-b318-6ec83f38e2a5"), HomeAssignmentId = Guid.Parse("8c1ad993-fd92-4b79-895f-0a42f535a89c"), UserId = Guid.Parse("2a8bea88-5258-4b3f-9bf9-fb67b94b3638") },
                new HomeAssignmentUser { Id = Guid.Parse("275a9967-c245-4961-8a58-fdef4406229a"), HomeAssignmentId = Guid.Parse("f2ad7b77-e746-4453-8980-5706d5c9c950"), UserId = Guid.Parse("2a8bea88-5258-4b3f-9bf9-fb67b94b3638") },
                new HomeAssignmentUser { Id = Guid.Parse("20e86ac5-7742-4b01-b2e0-91aeadade37b"), HomeAssignmentId = Guid.Parse("d9a9d06a-30df-4e33-844f-830a5cdafa07"), UserId = Guid.Parse("2a8bea88-5258-4b3f-9bf9-fb67b94b3638") },
                new HomeAssignmentUser { Id = Guid.Parse("2ae383a0-d0c6-4159-876b-a8d57f55fb0a"), HomeAssignmentId = Guid.Parse("d9a9d06a-30df-4e33-844f-830a5cdafa07"), UserId = Guid.Parse("4cd08acf-117f-46b1-8203-18ecee161a53") },
                new HomeAssignmentUser { Id = Guid.Parse("0f367199-b18e-4f48-b4d5-611d0dab3fbd"), HomeAssignmentId = Guid.Parse("b4c5dd65-06df-4403-a99f-1c261d35662d"), UserId = Guid.Parse("a5379e84-d0b6-4668-8cf1-9dea364a54d9") },
                new HomeAssignmentUser { Id = Guid.Parse("fadb749c-8f60-41e2-9464-f44f0328ea7d"), HomeAssignmentId = Guid.Parse("d9a9d06a-30df-4e33-844f-830a5cdafa07"), UserId = Guid.Parse("0db5c20f-b0c3-4c87-a437-fa2dbb884d47") });
            }

            _context.SaveChanges();
        }
    }
}
