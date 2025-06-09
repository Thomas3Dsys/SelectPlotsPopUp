namespace CellSelectDemo;

/// <summary>
/// This Page displays all the data generated in the ViewModel.
/// When the submit button is clicked it will close this Modal.
/// See the Xaml for more content.
/// </summary>
public partial class SelectionPopUp : ContentPage
{
	public SelectionPopUp()
	{
		InitializeComponent();
	}

    private async void GetSelections(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}