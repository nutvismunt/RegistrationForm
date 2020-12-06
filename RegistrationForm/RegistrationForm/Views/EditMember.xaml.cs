using RegistrationForm.Models;
using RegistrationForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistrationForm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMember : ContentPage
    {
        RegisterFormViewModel register;

        public EditMember()
        {
            InitializeComponent();
            register = new RegisterFormViewModel();
            agreement.IsChecked = true;
            birthDate.MaximumDate = DateTime.Now;
            birthDate.MinimumDate = DateTime.Now.AddYears(-100);
        }
        private async void SaveMember(object sender, EventArgs e)
        {
            var form = (RegisterForm)BindingContext;
            form.BirthDate = birthDate.Date;
            form.Agreement = agreement.IsChecked;
            List<string> fields = new List<string>();
            List<string> errors = new List<string>();
            var errorsList = register.IsDataValid(form).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            foreach (var error in errorsList)
            {
                string[] combined = error.Split(new char[] { ';' }, 2);
                if (!string.IsNullOrWhiteSpace(combined.Last()))
                {
                    fields.Add(combined.First());
                    errors.Add(combined.Last());
                }
            }
            if (!errors.Any())
            {
                register.Update(form);
                errors.Clear();
                var member = new MemberData();
                member.BindingContext = form;
                await Navigation.PushAsync(member);
            }
            else
            {
                for (int i = 0; errors.Count - 1 >= i; i++)
                { await DisplayAlert(fields[i], errors[i], "OK"); }
                errors.Clear();
            }
        }
    }
}