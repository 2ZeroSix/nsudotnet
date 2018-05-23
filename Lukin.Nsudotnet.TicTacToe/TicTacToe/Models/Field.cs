using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class Field<TField> : Cell where TField : IField, new()
    {
        public Field(IField parent=null) : base(parent)
        {
            Cells = new List<IField>(9);
            for (var i = 0; i < 9; ++i)
            {
                var field = new TField {Parent = this};
                Cells.Add(field);
            }
        }

        public Field()
        {
            Cells = new List<IField>(9);
            for (var i = 0; i < 9; ++i)
            {
                var field = new TField {Parent = this};
                Cells.Add(field);
            }
        }
    }

    public class Cell : IField
    {
        public Cell(IField parent=null)
        {
            Parent = parent;
        }

        public Cell()
        {
        }

        public IField Parent { get; set; }
        public List<IField> Cells { get; protected set; }
        public IPlayer Winner { get; set; }
    }

}