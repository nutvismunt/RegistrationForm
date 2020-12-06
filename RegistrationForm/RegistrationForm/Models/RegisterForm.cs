using System;

namespace RegistrationForm.Models
{
    public class RegisterForm 
    {
        public long Id { get; set; }

        // Данные участника

        public string Name { get; set; }

        public string SurName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        // Дата создания участника
        public DateTime WhenAdded { get; set; }

        public bool Agreement { get; set; }

    }
}
