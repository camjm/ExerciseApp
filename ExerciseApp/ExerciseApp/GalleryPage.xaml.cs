using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GalleryPage : ContentPage
	{
        private int _currentImageId = 1;

		public GalleryPage ()
		{
			InitializeComponent ();

            LoadImage();
		}

        private void LoadImage()
        {
            image.Source = new UriImageSource
            {
                CachingEnabled = false,
                Uri = new Uri($"http://lorempixel.com/1920/1080/city{_currentImageId}")
            };
        }

        void Previous_Clicked(object sender, System.EventArgs e)
        {
            _currentImageId--;
            if (_currentImageId == 0)
                _currentImageId = 10;

            LoadImage();
        }

        void Next_Clicked(object sender, System.EventArgs e)
        {
            _currentImageId++;
            if (_currentImageId == 11)
                _currentImageId = 1;

            LoadImage();
        }
    }
}