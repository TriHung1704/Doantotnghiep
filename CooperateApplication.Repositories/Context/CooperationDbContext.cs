using CooperateApplication.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto.Generators;
using System;
using static CooperateApplication.Repositories.Enums.CooperateEnums;

namespace CooperateApplication.Repositories.Context
{
    public class CooperationDbContext : DbContext
    {
        public CooperationDbContext(DbContextOptions<CooperationDbContext> options) : base(options)
        {

        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<ClassStudent> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseField> EnterpriseFields { get; set; }
        public DbSet<EnterpriseFacility> EnterpriseFacilities { get; set; }
        public DbSet<EnterpriseEmployee> EnterpriseEmployees { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostMajors> PostMajors { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SlideImage> SlideImages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PostStudent> RecruitmentStudents { get; set; }
        public DbSet<SenimarStudent> SenimarStudents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(new Role { Id = 1,RoleName = "Administrator", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2,RoleName = "EmployeeHRM", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3,RoleName = "EmployeeMentor", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4,RoleName = "EmployeeAdmin", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 5,RoleName = "Student", CreateAt = DateTime.UtcNow });
           

            //create S ADMIN
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "admin", Password = BCrypt.Net.BCrypt.HashPassword("1234"), FullName = "Quản trị viên 1", UserType = UserTypeName.SAdmin, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, UserId = 1, RoleId = 1, CreateAt = DateTime.UtcNow });

            //create enterprise
            modelBuilder.Entity<Enterprise>().HasData(new Enterprise { Id = 1, Name = "Test Company", Description = "Là doanh nghiệp phát triển các phần mềm ứng dụng chất lượng ca và ổn định", Email = "hr@gmail.com", Website = "https://www.google.com.vn/", Phone = "0325867435", CreateAt = DateTime.UtcNow });
            //create employee with name test_employee
            modelBuilder.Entity<User>().HasData(new User { Id = 2, UserName = "employee_hrm", Password = BCrypt.Net.BCrypt.HashPassword("1234"), FullName = "Employee HRM", UserType = UserTypeName.Employee, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<EnterpriseEmployee>().HasData(new EnterpriseEmployee { Id = 1, UserId = 2, EnterpriseId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 2, UserId = 2, RoleId = 2, CreateAt = DateTime.UtcNow });

            //create Employee ADMIN
            modelBuilder.Entity<User>().HasData(new User { Id = 3, UserName = "employee_admin", Password = BCrypt.Net.BCrypt.HashPassword("1234"), FullName = "Employee admin", UserType = UserTypeName.Employee, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 3, UserId = 3, RoleId = 4, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<EnterpriseEmployee>().HasData(new EnterpriseEmployee { Id = 2, UserId = 3, EnterpriseId = 1, CreateAt = DateTime.UtcNow });

            //create enterprise facility 
            modelBuilder.Entity<EnterpriseFacility>().HasData(new EnterpriseFacility { Id = 1, Name = "Tầng 23, Tòa nhà ACB Bank", DetailAddress = "Đường 3/2", EnterpriseId = 1, ProvinceAddress = "Thuận Phước", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<EnterpriseFacility>().HasData(new EnterpriseFacility { Id = 2, Name = "Tầng 13, Tòa nhà Viettin Bank", DetailAddress = "Đường Hùng Vương", EnterpriseId = 1, ProvinceAddress = "Hải Châu", CreateAt = DateTime.UtcNow });
            //create enterprise field 
            modelBuilder.Entity<EnterpriseField>().HasData(new EnterpriseField { Id = 1, Name = "Software", EnterpriseId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<EnterpriseField>().HasData(new EnterpriseField { Id = 2, Name = "Giải trí/ Game", EnterpriseId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<EnterpriseField>().HasData(new EnterpriseField { Id = 3, Name = "Dịch vụ IT", EnterpriseId = 1, CreateAt = DateTime.UtcNow });

            //university
            modelBuilder.Entity<University>().HasData(new University { Id = 1, Name = "Test University", Introduction = "description", Address = "Đà Nẵng", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Khoa Công Nghệ Số", UniversityId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "Khoa Điện - Điện Tử", UniversityId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Khoa Cơ Khí", UniversityId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 4, Name = "Khoa Xây Dựng", UniversityId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 5, Name = "Khoa Hóa Học và Môi Trường", UniversityId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 1, Name = "Ngành Công Nghệ Thông Tin", DepartmentId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 2, Name = "Ngành Công nghệ kỹ thuật nhiệt", DepartmentId = 2, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 3, Name = "Ngành Công nghệ kỹ thuật điện, điện tử", DepartmentId = 2, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 5, Name = "Ngành Công nghệ kỹ thuật điện tử - viễn thông", DepartmentId = 2, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 6, Name = "Ngành Công nghệ kỹ thuật điều khiển và tự động hóa", DepartmentId = 2, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 7, Name = "Ngành Công nghệ kỹ thuật cơ khí", DepartmentId = 3, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 8, Name = "Ngành Công nghệ kỹ thuật cơ điện tử", DepartmentId = 3, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 9, Name = "Ngành Công nghệ kỹ thuật xây dựng", DepartmentId = 4, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 10, Name = "Ngành Công nghệ kỹ thuật giao thông", DepartmentId = 4, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 11, Name = "Ngành Công nghệ kỹ thuật kiến trúc", DepartmentId = 4, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 12, Name = "Kỹ thuật cơ sở hạ tầng", DepartmentId = 4, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 13, Name = "Công nghệ kỹ thuật môi trường", DepartmentId = 5, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 14, Name = "Ngành Kỹ Thuật thực phẩm", DepartmentId = 5, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 15, Name = "Ngành Công nghệ vật liệu", DepartmentId = 5, CreateAt = DateTime.UtcNow });
            //class student
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 1, MajorsId = 1,  Name = "20T1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 2, MajorsId = 1,  Name = "20T2", CreateAt = DateTime.UtcNow });


        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    In order to be able to create migrations and update database:
        //    if (!options.IsConfigured)
        //    {
        //        options.UseMySQL("server=localhost; port=3306; database=CooperationDb; user=root; password=1234");
        //    }
        //    base.OnConfiguring(options);
        //}
    }

    public class CooperationDbContextFactory : IDesignTimeDbContextFactory<CooperationDbContext>
    {
        public CooperationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CooperationDbContext>();
            optionsBuilder.UseMySQL("server=localhost; port=3306; database=DoanDb; user=root; password=1234");

            return new CooperationDbContext(optionsBuilder.Options);

        }
    }
}
