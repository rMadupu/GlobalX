﻿namespace GlobalX.Library.Model
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{ this.FirstName } { this.LastName}";
    }
}