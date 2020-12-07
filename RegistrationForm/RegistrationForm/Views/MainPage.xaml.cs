using RegistrationForm.Models;
using RegistrationForm.ViewModels;
using RegistrationForm.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Views.RegistrationForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        RegisterFormViewModel register;

        public MainPage()
        {
            InitializeComponent();
            register =new RegisterFormViewModel();
            
        }

        protected override void OnAppearing()
        {
            members.ItemsSource = register.GetMembers().Result;
            base.OnAppearing();
        }

        private async void CreateMember(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            CreateMember createMember = new CreateMember();
            createMember.BindingContext = register;
            await Navigation.PushAsync(createMember);
        }

        private void members_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            RegisterForm selectedMember = (RegisterForm)e.Item;
            MemberData memberData = new MemberData();
            memberData.BindingContext = selectedMember;
            Navigation.PushAsync(memberData);
        }
    }
}
