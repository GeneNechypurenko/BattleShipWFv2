﻿using System.ComponentModel;

namespace BattleShip.Models
{
    public class Ship : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public int Size { get; set; }

        private bool _isVertical;
        public bool IsVertical
        {
            get => _isVertical;
            set
            {
                _isVertical = value;
                OnPropertyChanged(nameof(IsVertical));
            }
        }
        private bool[] _isHit;
        public bool[] IsHit
        {
            get => _isHit;
            set
            {
                _isHit = value;
                OnPropertyChanged(nameof(IsHit));
            }
        }
        private bool _isSunk;
        public bool IsSunk
        {
            get => _isSunk;
            set
            {
                _isSunk = value;
                OnPropertyChanged(nameof(IsSunk));
            }
        }
        private int[] _posX;
        public int[] PosX
        {
            get => _posX;
            set
            {
                _posX = value;
                OnPropertyChanged(nameof(PosX));
            }
        }
        private int[] _posY;
        public int[] PosY
        {
            get => _posY;
            set
            {
                _posY = value;
                OnPropertyChanged(nameof(PosY));
            }
        }
        public Ship(int size)
        {
            Size = size;
            PosX = new int[size];
            PosY = new int[size];
            IsHit = new bool[size];
        }
    }
}
