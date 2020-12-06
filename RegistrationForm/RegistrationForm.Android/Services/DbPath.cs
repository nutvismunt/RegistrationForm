using System.IO;
using Xamarin.Forms;
using RegistrationForm.Interfaces;
using RegistrationForm.Droid.Services;
using System;

[assembly: Dependency(typeof(DbPath))]
namespace RegistrationForm.Droid.Services
{
    public class DbPath : IPath
    {
        public string GetDbPath (string dbname)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbname);
        }
    }
}