using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CellSelectDemo;
/// <summary>
/// This ViewModel generates a certain number of indexed cells. They can be selected (and then be colored white)
/// The SelectedCells value can then be accessed via calling BindingContext.
/// </summary>
public class CellSelectorViewModel : INotifyPropertyChanged
{
    readonly Random random;
    private List<int> selectedCells;
    int cells = 30;

    public PlotCell[] PlotCells { get; private set; }
    public List<int> SelectedCells
    {
        get
        {
            return PlotCells.Where(x => x.IsSelected).Select(x => x.Index).ToList();
            //I left this in here as my next goal is to do this with a grid and x,y coords instead of indexes being selected.
            //return PlotCells.Where(x => x.IsSelected).Select(x => x.Coordinate).ToList();
        }
        private set {}
    }

    public ICommand SelectCell => new Command<int>(async (int arg) => await SelectPlotCellAsync(arg));

    public ICommand SubmitSelections => new Command(async () => await DoSubmitSelections());

    public CellSelectorViewModel()
    {
        random = new Random();
        PlotCells = new PlotCell[cells];
        CreatePlotCells();
    }

    void CreatePlotCells()
    {
        for (int i = 0; i < cells; i++)
        {
            PlotCells[i] = new PlotCell
            {
                Index = i,
                //Coordinate = new int[] { 0, i },//update to x,y
                Color = Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)),
                Name = $"PlotCell {i}"
            };

        }
    }

    async Task SelectPlotCellAsync(int i)
    {
        PlotCells[i].IsSelected = !PlotCells[i].IsSelected;
    }

    async Task DoSubmitSelections()
    {
        List<int> selected = PlotCells.Where(x=> x.IsSelected).Select(x=>x.Index).ToList();
        int a = 1;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
