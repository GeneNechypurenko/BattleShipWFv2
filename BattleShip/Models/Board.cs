using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Models
{
    public class Board : INotifyPropertyChanged
    {
        public int Cells { get; } = 10;
        public int CellSize { get; } = 30;

        private ObservableCollection<Ship> _ships;
        public ObservableCollection<Ship> Ships
        {
            get => _ships ?? (_ships = new ObservableCollection<Ship>());
            set
            {
                _ships = value;
                OnPropertyChanged(nameof(Ship));
            }
        }

        private int[,] _board2d;
        public int[,] Board2d
        {
            get => _board2d;
            set
            {
                _board2d = value;
                OnPropertyChanged(nameof(Board2d));
            }
        }
        private bool[,] _isOccupiedCell;
        public bool[,] IsOccupiedCell
        {
            get => _isOccupiedCell;
            set
            {
                _isOccupiedCell = value;
                OnPropertyChanged(nameof(IsOccupiedCell));
            }
        }
        public Board()
        {
            Ships = new ObservableCollection<Ship>();

            Board2d = new int[Cells, Cells];
            IsOccupiedCell = new bool[Cells, Cells];

            for (int i = 0; i < Board2d.GetLength(0); i++)
            {
                for (int j = 0; j < Board2d.GetLength(1); j++)
                {
                    Board2d[i, j] = 0;
                    IsOccupiedCell[i, j] = false;
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
