using Microsoft.EntityFrameworkCore;
using RegistrationForm.Database;
using RegistrationForm.Models;
using RegistrationForm.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationForm.ViewModels
{
    public class RegisterFormViewModel 
    {
        private RegistrationContext _context;

        public RegisterFormViewModel()
        {
            _context = new RegistrationContext();
        }

        public async void Create(RegisterForm member)
        {
            using (_context)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
            }
        }
        public async void Update(RegisterForm member)
        {
            using (_context)
            {
                _context.Update(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<RegisterForm>> GetMembers()
        {
           return await _context.RegisterForms.ToListAsync();
        }

        public RegisterForm GetMember(RegisterForm member)
        {
            return _context.RegisterForms.FirstOrDefault(m=>m.Id==member.Id);
        }

        public async void Delete(RegisterForm member)
        {
            using (_context)
            {
                _context.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
        public async void DeleteMany(RegisterForm [] forms)
        {
            using (_context)
            {
                _context.RemoveRange(forms);
                await _context.SaveChangesAsync();
            }
        }

        public List<string> IsDataValid(RegisterForm form)
        {
            var errors = new List<string>();
            errors.Add("Имя;"+form.Name.ValidateLength(15,1));
            errors.Add("Фамилия;"+form.SurName.ValidateLength(30,1));
            errors.Add("Дата рождения;"+form.BirthDate.ToString("dd.MM.yyyy").ValidateAge());
            errors.Add("Номер телефона;"+form.PhoneNumber.ValidatePhone());
            errors.Add("Согласие на обработку персональных данных;" + form.Agreement.ToString().ValidateAgreement());
            return errors;
        }
    }
}
