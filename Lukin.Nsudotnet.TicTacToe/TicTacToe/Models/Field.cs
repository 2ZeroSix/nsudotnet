using System.Collections.Generic;
using System.Windows;

namespace TicTacToe.Models
{
    public class Field<TField> : FieldBase where TField : FieldBase, new()
    {
        public Field(FieldBase parent = null)
        {
            Parent = parent;
            Cells = new List<IField>(9);
            for (var i = 0; i < 3; ++i)
            for (var j = 0; j < 3; ++j)
            {
                var field = new TField {Parent = this, Col = j, Row = i};
                Cells.Add(field);
                PropertyChanged += (o, e) =>
                {
                    if (e.PropertyName == "Current") field.Current = Current;
                };
            }
        }

        public Field() : this(null)
        {
        }

        public override void recalcWinner(Player player)
        {
            if (State != 0) return;
            for (var x = 0; x < 3; x++)
            for (var y = 0; y < 3; y++)
            {
                if ((int) Cells[x * 3 + y].State != (int) player)
                    break;
                if (y != 2) continue;
                State = (State) player;
                return;
            }

            for (var y = 0; y < 3; y++)
            for (var x = 0; x < 3; x++)
            {
                if ((int) Cells[x * 3 + y].State != (int) player)
                    break;
                if (x != 2) continue;
                    State = (State) player;
                return;
            }

            for (var i = 0; i < 3; i++)
            {
                if ((int) Cells[i * 4].State != (int) player)
                    break;
                if (i != 2) continue;
                State = (State) player;
                return;
            }

            for (var i = 0; i < 3; i++)
            {
                if ((int) Cells[i * 2 + 2].State != (int) player)
                    break;
                if (i != 2) continue;
                State = (State) player;
                return;
            }
            
            var free = 0;
            for (var i = 0; i < 9; ++i)
            {
                if (Cells[i].State == State.Empty) ++free;
            }

            if (free == 0)
                State = State.Draw;
        }
    }
}