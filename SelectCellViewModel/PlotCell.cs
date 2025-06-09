using System.ComponentModel;

namespace CellSelectDemo;

/// <summary>
/// This object has the data for each cell that can be selected in the CellSelectorViewModel.
/// </summary>
public class PlotCell : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public int Index{ get; set; }
    //public int[] Coordinate { get; set; }
    public string Name { get; set; }

    private bool isSelected = false;
    public bool IsSelected {
        get {
            return isSelected;
        }
        set 
        {
            isSelected = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
        } }

    private Color baseColor = Colors.Grey;
    

    public Color Color
    {
        get
        {
            if (IsSelected)
                return Colors.White;
            else
                return baseColor;
        }
        set
        {
            if (baseColor != value)
            {
                baseColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
            }
        }
    }
}
    