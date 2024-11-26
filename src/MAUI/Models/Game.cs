using CommunityToolkit.Mvvm.ComponentModel;

namespace C_MobileProject.Models
{
    public partial class Game : ObservableObject
    {
        [ObservableProperty]
        private Guid id;
        [ObservableProperty]
        private string? name;
        [ObservableProperty]
        private string? description;
        [ObservableProperty]
        private double? price;
        [ObservableProperty]
        private string? imageUrl;
        [ObservableProperty]
        private bool inStock;
    }
}
