using System.Collections.Generic;
using Caliburn.Micro;

namespace TicTacToe.Models
{
    public abstract class FieldBase : PropertyChangedBase, IField
    {
        private int _col;
        private int _row;
        private IField _parent;
        private State _state;
        private List<IField> _cells;
        private bool _current;

        public bool Current
        {
            get => _current;
            set
            {
                _current = value;
                NotifyOfPropertyChange(() => Current);
            }
        }

        public int Col
        {
            get => _col;
            set
            {
                if (value == _col) return;
                _col = value;
                NotifyOfPropertyChange(() => Col);
            }
        }

        public int Row
        {
            get => _row;
            set
            {
                if (value == _row) return;
                _row = value;
                NotifyOfPropertyChange(() => Row);
            }
        }

        public IField Parent
        {
            get => _parent;
            set
            {
                if (Equals(value, _parent)) return;
                _parent = value;
                NotifyOfPropertyChange(() => Parent);
            }
        }

        public List<IField> Cells
        {
            get => _cells;
            protected set
            {
                if (Equals(value, _cells)) return;
                _cells = value;
                NotifyOfPropertyChange(() => Cells);
            }
        }

        public State State
        {
            get => _state;
            set
            {
                _state = value;
                NotifyOfPropertyChange(() => State);
            }
        }

        public abstract void recalcWinner(Player player);
    }

}