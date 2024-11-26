using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_MobileProject.Models
{
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        private Guid userId;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;

        [ObservableProperty]
        private string? confirmPassword;

        [ObservableProperty]
        private string? country;

        [ObservableProperty]
        private string? city;

        [ObservableProperty]
        private string? address;
    }
}
