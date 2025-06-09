using System.Collections.Generic;
using System.Windows.Input;

namespace CellSelectDemo
{
/// <summary>
/// This is the main page.
///   It will open the SelectionPopUp then when that is closed and this page appears again, it 
///   will get the selected values from the ViewModel's binding context.
/// </summary>
    public partial class MainPage : ContentPage
    {

        List<int> SelectedCells = new List<int> { };
        SelectionPopUp makeSelection = new SelectionPopUp();
        bool IsWaitingForSelection = false;

        public MainPage()
        {
            InitializeComponent();
        }
        public ICommand CloseGetSelections => new Command(async () => await DoCloseGetSelections());
        private async void OpenSelectionPopUp(object sender, EventArgs e)
        {
            IsWaitingForSelection = true;
            makeSelection = new SelectionPopUp();
            await Navigation.PushModalAsync(makeSelection);
        }


        async Task DoCloseGetSelections()
        {
            await Navigation.PopModalAsync();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (IsWaitingForSelection)
            {
                CellSelectorViewModel viewModel = (CellSelectorViewModel)makeSelection.BindingContext;
                SelectedCells = viewModel.SelectedCells;
                IsWaitingForSelection = false;
                //   DisplaySelections.Text = string.Join(", ", SelectedCells.Select(x => $"({x[0].ToString()},{x[1].ToString()})").ToArray());
                DisplaySelections.Text = string.Join(", ", SelectedCells.Select(x => $"({x.ToString()})").ToArray());
            }
            
        }
        
    }
}
