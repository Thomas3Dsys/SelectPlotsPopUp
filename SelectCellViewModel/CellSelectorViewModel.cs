using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CellSelectDemo;

public class CellSelectorViewModel :  INotifyPropertyChanged
{
    readonly Random random;


    public PlotCell[] PlotCells { get; private set; }

    public ICommand SelectCell => new Command<int>(async (int arg) => await SelectPlotCellAsync(arg));

    public ICommand SubmitSelections => new Command(async () => await DoSubmitSelections());

    public CellSelectorViewModel()
    {
        random = new Random();
        PlotCells = new PlotCell[5];
        CreatePlotCells();
    }

    void CreatePlotCells()
    {
        for (int i = 0; i < 5; i++)
        {
            PlotCells[i] = new PlotCell
            {
                Index = i,
                Color = Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)),
                Name = $"PlotCell {i}"
            };

        }
    }


    async Task SelectPlotCellAsync(int i)
    {
        PlotCells[i].IsSelected = !PlotCells[i].IsSelected;
    }

    /*
    public static readonly BindableProperty SelectionMessageProperty = BindableProperty.Create(nameof(SelectionMessage), typeof(string), typeof(CellSelectorViewModel), string.Empty);

    public string SelectionMessage
    {
        get => (string)GetValue(CellSelectorViewModel.SelectionMessageProperty);
        set => SetValue(CellSelectorViewModel.SelectionMessageProperty, value);
    }
    */
    async Task DoSubmitSelections()
    {
        List<int> selected = PlotCells.Where(x=> x.IsSelected).Select(x=>x.Index).ToList();
        int a = 1;
    }

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

 
    #endregion
}
