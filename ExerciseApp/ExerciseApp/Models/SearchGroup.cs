using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExerciseApp.Models
{
    /// <summary>
    /// This is the object that gets bound to the ListView
    /// </summary>
    public class SearchGroup : ObservableCollection<Search>
    {
        public string Title { get; set; }

        public SearchGroup(string title, IEnumerable<Search> searches = null) : base(searches)
        {
            Title = title;
        }
    }
}
