using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Models
{
    public class Player : INotifyPropertyChanged
    {
        public bool IsTurn { get; set; }
        //private bool _isTurn;
        //public bool IsTurn
        //{
        //    get => _isTurn;
        //    set
        //    {
        //        _isTurn = value;
        //        OnPropertyChanged(nameof(IsTurn));
        //    }
        //}
        public int ShipCount { get; } = 10;
        private int _lincoreSet = 1;
        public int LincoreSet
        {
            get => _lincoreSet;
            set
            {
                _lincoreSet = value;
                OnPropertyChanged(nameof(LincoreSet));
            }
        }
        private int _fregateSet = 2;
        public int FregateSet
        {
            get => _fregateSet;
            set
            {
                _fregateSet = value;
                OnPropertyChanged(nameof(FregateSet));
            }
        }
        private int _corvetteSet = 3;
        public int CorvetteSet
        {
            get => _corvetteSet;
            set
            {
                _corvetteSet = value;
                OnPropertyChanged(nameof(CorvetteSet));
            }
        }
        private int _briggSet = 4;
        public int BriggSet
        {
            get => _briggSet;
            set
            {
                _briggSet = value;
                OnPropertyChanged(nameof(BriggSet));
            }
        }
        private Board _board;
        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged(nameof(Board));
            }
        }
        public Player(Board board) => Board = board;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
