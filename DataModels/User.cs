using System;

namespace BenefitsManagementAPI.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}