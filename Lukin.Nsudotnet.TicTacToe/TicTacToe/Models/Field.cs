using System.Collections.Generic;
using System.Windows;

namespace TicTacToe.Models
{
    public class Field<TField> : Cell where TField : BaseField, new()
    {
        public Field(BaseField parent = null) : base(parent)
        {
            Cells = new List<IField>(9);
            for (var i = 0; i < 3; ++i)
            for (var j = 0; j < 3; ++j)
            {
                var field = new TField {Parent = this, Col = j, Row = i};
                Cells.Add(field);
                PropertyChanged += (o, e) =>
                {
                    switch (e.PropertyName)
                    {
                        case "Current":
                            field.Current = Current;
                            break;
                    }
                };
//                field.PropertyChanged += (o, e) =>
//                {
//                    switch (e.PropertyName)
//                    {
//                        case "Current":
//                            Current = field.Current;
//                            break;
//                    }
//                };

            }
        }

        public Field() : this(null)
        {
        }

        public override void recalcWinner(int player)
        {
            if (Winner != 0) return;
            for (var x = 0; x < 3; x++)
            for (var y = 0; y < 3; y++)
            {
                if (Cells[x * 3 + y].Winner != player)
                    break;
                if (y != 2) continue;
                Winner = player;
                return;
            }

            for (var y = 0; y < 3; y++)
            for (var x = 0; x < 3; x++)
            {
                if (Cells[x * 3 + y].Winner != player)
                    break;
                if (x != 2) continue;
                    Winner = player;
                return;
            }

            for (var i = 0; i < 3; i++)
            {
                if (Cells[i * 4].Winner != player)
                    break;
                if (i != 2) continue;
                Winner = player;
                return;
            }

            for (var i = 0; i < 3; i++)
            {
                if (Cells[i * 2 + 2].Winner != player)
                    break;
                if (i != 2) continue;
                Winner = player;
                return;
            }
        }
    }
}