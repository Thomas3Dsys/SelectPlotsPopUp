namespace CellSelectDemo
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage()
        {
            InitializeComponent();
        }

        private void GetSelections(object sender, EventArgs e)
        {
            var button = (Button)sender;
            CellSelectorViewModel viewModel = (CellSelectorViewModel)button.BindingContext;
            PlotCell[] plotCells = viewModel.PlotCells;
            List<int> selected = plotCells.Where(x => x.IsSelected).Select(x => x.Index).ToList();
        }
        //ToDo: Make a SelectionPage that does the above and then closes that page and returns the values to Main page
        //https://learn.microsoft.com/en-us/answers/questions/1418192/closing-popup-from-view-model-and-return-value
        //
    }
}
