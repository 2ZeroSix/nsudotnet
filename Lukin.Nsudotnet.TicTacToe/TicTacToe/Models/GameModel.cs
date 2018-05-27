using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caliburn.Micro;

namespace TicTacToe.Models
{
    public class GameModel<TField> : BaseGameModel where TField : IField, new()
    {
        public GameModel()
        {
            Cells = new List<IField> {new TField{Parent = this}};
        }
    }
}