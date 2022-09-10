using System;

namespace StudentAdminPortalAPI.DomainModels
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public string ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; }

        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }
}
