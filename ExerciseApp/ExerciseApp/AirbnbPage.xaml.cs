using ExerciseApp.Models;
using ExerciseApp.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AirbnbPage : ContentPage
	{
        private readonly SearchService _searchService;

        private List<SearchGroup> _searchGroups;

		public AirbnbPage ()
		{
            _searchService = new SearchService();

			InitializeComponent();

            PopulateListView(_searchService.GetSearches());
		}

        private void PopulateListView(IEnumerable<Search> searches)
        {
            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateListView(_searchService.GetSearches(e.NewTextValue));
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            var filter = searchBar.Text;
            PopulateListView(_searchService.GetSearches(filter));

            listView.EndRefresh();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var search = menuItem.CommandParameter as Search;

            // Locally remove the search from the search group, which is an observable collection,
            // so the UI will be updated immediately
            var recentSearches =_searchGroups[0];
            recentSearches.Remove(search);

            // Also update the backend
            _searchService.DeleteSearch(search.Id);
        }
    }
}