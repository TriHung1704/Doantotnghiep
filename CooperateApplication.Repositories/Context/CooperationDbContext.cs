﻿using CooperateApplication.Repositories.Entities;
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
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4,RoleName = "EmployeeAdmin", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 5,RoleName = "Student", CreateAt = DateTime.UtcNow });
           

            //create S ADMIN
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "admin", Password = BCrypt.Net.BCrypt.HashPassword("1234"), FullName = "Quản trị viên",Email="qtrv@gmail.com",Phone="0987654321", UserType = UserTypeName.SAdmin, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, UserId = 1, RoleId = 1, CreateAt = DateTime.UtcNow });

            //create enterprise
            modelBuilder.Entity<Enterprise>().HasData(new Enterprise { Id = 1, Name = "Test Company", Description = "Là doanh nghiệp phát triển các phần mềm ứng dụng chất lượng ca và ổn định", Email = "hr@gmail.com", Website = "https://www.google.com.vn/", Phone = "0325867435", CreateAt = DateTime.UtcNow, Status = true });
            //create employee with name test_employee
            modelBuilder.Entity<User>().HasData(new User { Id = 2, UserName = "employee_hrm", Password = BCrypt.Net.BCrypt.HashPassword("1234"), FullName = "Employee HRM", UserType = UserTypeName.Employee, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<EnterpriseEmployee>().HasData(new EnterpriseEmployee { Id = 1, UserId = 2, EnterpriseId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 2, UserId = 2, RoleId = 2, CreateAt = DateTime.UtcNow });

            //create Employee ADMIN
            modelBuilder.Entity<User>().HasData(new User { Id = 3, UserName = "employee_admin", Password = BCrypt.Net.BCrypt.HashPassword("1234"), FullName = "Employee admin", UserType = UserTypeName.Employee, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 3, UserId = 3, RoleId = 4, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<EnterpriseEmployee>().HasData(new EnterpriseEmployee { Id = 2, UserId = 3, EnterpriseId = 1, CreateAt = DateTime.UtcNow });

            //create enterprise facility 
            modelBuilder.Entity<EnterpriseFacility>().HasData(new EnterpriseFacility { Id = 1, DetailAddress = "Tầng 23, Tòa nhà ACB Bank - Đường 3/2 Thuận Phước Đà Nẵng", EnterpriseId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<EnterpriseFacility>().HasData(new EnterpriseFacility { Id = 2, DetailAddress = "Tầng 13, Tòa nhà Viettin Bank - Đường Hùng Vương Hải Châu Đà Nẵng", EnterpriseId = 1, CreateAt = DateTime.UtcNow });
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
            modelBuilder.Entity<Department>().HasData(new Department { Id = 6, Name = "Khoa Sư Phạm Công Nghiệp", UniversityId = 1, CreateAt = DateTime.UtcNow });
            //Majors
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 1, Name = "Ngành Công Nghệ Thông Tin", DepartmentId = 1, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 2, Name = "Ngành Tự Động Hóa", DepartmentId = 2, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 3, Name = "Ngành Điện - Điện Tử", DepartmentId = 2, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 4, Name = "Ngành Công nghệ kỹ thuật cơ khí", DepartmentId = 3, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 5, Name = "Ngành Công nghệ kỹ thuật cơ điện tử", DepartmentId = 3, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 6, Name = "Ngành Công nghệ kỹ thuật xây dựng", DepartmentId = 4, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 7, Name = "Ngành Công nghệ kỹ thuật xây dựng cầu đường", DepartmentId = 4, CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<Majors>().HasData(new Majors { Id = 8, Name = "Ngành Kỹ Thuật môi trường", DepartmentId = 5, CreateAt = DateTime.UtcNow });
            //class student
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 1, MajorsId = 1, Name = "19T1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 2, MajorsId = 1, Name = "19T2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 3, MajorsId = 1, Name = "19C1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 4, MajorsId = 1, Name = "19C2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 5, MajorsId = 1, Name = "19CDT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 6, MajorsId = 1, Name = "19CDT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 7, MajorsId = 1, Name = "19DT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 8, MajorsId = 1, Name = "19DT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 9, MajorsId = 1, Name = "19TDH1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 10, MajorsId = 1, Name = "19TDH2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 11, MajorsId = 1, Name = "19MT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 12, MajorsId = 1, Name = "19MT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 13, MajorsId = 1, Name = "19SK1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 14, MajorsId = 1, Name = "19XD1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 15, MajorsId = 1, Name = "19XD2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 16, MajorsId = 1, Name = "19XC1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 17, MajorsId = 1, Name = "19XC2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 18, MajorsId = 1, Name = "20T1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 19, MajorsId = 1, Name = "20T2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 20, MajorsId = 1, Name = "20C1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 21, MajorsId = 1, Name = "20C2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 22, MajorsId = 1, Name = "20CDT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 23, MajorsId = 1, Name = "20CDT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 24, MajorsId = 1, Name = "20DT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 25, MajorsId = 1, Name = "20DT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 26, MajorsId = 1, Name = "20TDH1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 27, MajorsId = 1, Name = "20TDH2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 28, MajorsId = 1, Name = "20MT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 29, MajorsId = 1, Name = "20MT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 30, MajorsId = 1, Name = "20SK1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 31, MajorsId = 1, Name = "20XD1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 32, MajorsId = 1, Name = "20XD2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 33, MajorsId = 1, Name = "20XC1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 34, MajorsId = 1, Name = "20XC2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 35, MajorsId = 1, Name = "21T1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 36, MajorsId = 1, Name = "21T2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 37, MajorsId = 1, Name = "21C1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 38, MajorsId = 1, Name = "21C2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 39, MajorsId = 1, Name = "21CDT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 40, MajorsId = 1, Name = "21CDT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 41, MajorsId = 1, Name = "21DT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 42, MajorsId = 1, Name = "21DT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 43, MajorsId = 1, Name = "21TDH1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 44, MajorsId = 1, Name = "21TDH2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 45, MajorsId = 1, Name = "21MT1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 46, MajorsId = 1, Name = "21MT2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 47, MajorsId = 1, Name = "21SK1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 48, MajorsId = 1, Name = "21XD1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 49, MajorsId = 1, Name = "21XD2", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 50, MajorsId = 1, Name = "21XC1", CreateAt = DateTime.UtcNow });
            modelBuilder.Entity<ClassStudent>().HasData(new ClassStudent { Id = 51, MajorsId = 1, Name = "21XC2", CreateAt = DateTime.UtcNow });
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
            optionsBuilder.UseMySQL("server=localhost; port=3306; database=CooperationDb; user=root; password=1234");

            return new CooperationDbContext(optionsBuilder.Options);

        }
    }
}
