using RegistrationForm.Models;
using RegistrationForm.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistrationForm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemberData : ContentPage
    {
        RegisterFormViewModel register;
        public MemberData()
        {
            InitializeComponent();
            register = new RegisterFormViewModel();
        }
        private async void DeleteMember(object sender, EventArgs e)
        {
            var member = (RegisterForm)BindingContext;
            if (await DisplayAlert("Удаление участника", "Вы уверены что хотите удалить?", "Да", "Нет"))
                register.Delete(member);
            await Navigation.PopAsync();
        }

        private async void EditMember(object sender, EventArgs e)
        {
            var member = (RegisterForm)BindingContext;
            var edit = new EditMember();
            edit.BindingContext = member;
            await Navigation.PushAsync(edit);
        }
    }
}