using System.Collections.Generic;

namespace TicTacToe.Models
{
    public interface IField
    {
        IField Parent { get; set; }
        List<IField> Cells { get; }
        IPlayer Winner { get; set; }
    }

}