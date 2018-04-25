using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SocialShare
{
    public class UserPageViewModel : ViewModelBase
    {
        public UserPageViewModel()
        {
            SocialItems = new List<SocialListItem>
            {
                new SocialListItem
                {
                    ImageSource = "facebook.png",
                    BackgroundColour = "#3b5998",
                    ForegroundColour = "#FFFFFF"
                },
                new SocialListItem
                {
                    ImageSource = "youtube.png",
                    BackgroundColour = "#dc472e",
                    ForegroundColour = "#FFFFFF"
                },
                new SocialListItem
                {
                    ImageSource = "instagram.png",
                    BackgroundColour = "#c536a4",
                    ForegroundColour = "#FFFFFF"
                },
                new SocialListItem
                {
                    ImageSource = "linkedin.png",
                    BackgroundColour = "#007bb5",
                    ForegroundColour = "#FFFFFF"
                },
                new SocialListItem
                {
                    ImageSource = "snapchat.png",
                    BackgroundColour = "#ffee58",
                    ForegroundColour = "#000000"
                },
                new SocialListItem
                {
                    ImageSource = "tumblr.png",
                    BackgroundColour = "#32506d",
                    ForegroundColour = "#FFFFFF"
                },
                new SocialListItem
                {
                    ImageSource = "twitter.png",
                    BackgroundColour = "#55acee",
                    ForegroundColour = "#FFFFFF"
                },
                new SocialListItem
                {
                    ImageSource = "tinder.png",
                    BackgroundColour = "#ff6647",
                    ForegroundColour = "#FFFFFF"
                }
            };

            MockNames = new List<string>
            {
                "Augusta Mathes",
                "Shakira Auguste",
                "Jacquelin Mccaa",
                "Shanita Nigh",
                "Angie Salter",
                "Yen Chavers",
                "Luella Rowland",
                "Jeanett Meares",
                "Damaris Heister",
                "Perry Heitzman",
                "Leonora Brannock",
                "Arnita Cotter",
                "Marina Chan",
                "Charis Deines",
                "Mitchell Waymire",
                "Dianna Grayson",
                "Ralph Jaimes",
                "Kattie Delorme",
                "Deon Hahn",
                "Tiffiny Strahl",
                "Amina Segraves",
                "Shalonda Vives",
                "Modesta Stetz",
                "Aubrey Hazelwood",
                "Lisbeth Wulf",
                "Jacquie Arambula",
                "Denna Brain",
                "Shu Colegrove",
                "Shavon Brogan",
                "Brittanie Criger",
                "Janessa Thurman",
                "Dennise Welling",
                "Alise Pankey",
                "Antonina Breece",
                "Selina Sojka",
                "Caterina Dipaolo",
                "Jed Genao",
                "Lena Henry",
                "Mauricio Dix",
                "Kurtis Donohoe",
                "Noma Warford",
                "Tish Claycomb",
                "Mason Mcgriff",
                "Sarita Brimer",
                "Misty Palmer",
                "Willodean Eversole",
                "Lavon Speth",
                "Denis Crispin",
                "Rolande Belville",
                "Donald Peets",
                "Daniel Winduss",
                "Maiys Al-Khafaji"
            };

            Names = new ObservableCollection<SearchResultItem>();

            RaisePropertyChanged(() => SocialItems);
        }

        public Command CancelCommand => _cancelCommand ?? (_cancelCommand = new Command(Cancel));

        public List<SocialListItem> SocialItems { get; set; }

        public List<string> MockNames { get; set; }

        public ObservableCollection<SearchResultItem> Names { get; set; }

        public bool IsSearching => SearchTerm?.Length > 0;

        public string SearchTerm {
            get => _searchTerm;
            set
            {
                _searchTerm = value;

                RaisePropertyChanged(() => SearchTerm);
                RaisePropertyChanged(() => IsSearching);

                if (value.Length > 0)
                {
                    var names = MockNames.Where(name => name.ToUpper().Contains(value.ToUpper())).ToList();
                    Names.Clear();

                    foreach (var name in names)
                    {
                        Names.Add(new SearchResultItem
                        {
                            Name = name
                        });
                    }
                }
            }
        }

        private string _searchTerm;
        private Command _cancelCommand;

        private void Cancel()
        {
            SearchTerm = "";
        }
    }
}
