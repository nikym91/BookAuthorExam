using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public class Author
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }

        public Author(string firstname, string lastname, DateTime birth, string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Birth = birth;
            Email = email;
        }

        public Author(int id, string firstname, string lastname, DateTime birth, string email)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Birth = birth;
            Email = email;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Firstname}, Surname: {Lastname}, Birth: {Birth}, Email: {Email}";
        }

    }
}
