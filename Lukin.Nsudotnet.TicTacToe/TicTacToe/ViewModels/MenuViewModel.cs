using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public enum Difficulty
    {
        Baby,
        Kid,
        FreshMan,
        Pro,
        Insane
    }

    public class MenuViewModel : Screen
    {
        private Difficulty _difficulty;


        public Difficulty Difficulty
        {
            get => _difficulty;
            set
            {
                if (value == _difficulty) return;
                _difficulty = value;
                NotifyOfPropertyChange(() => Difficulty);
                NotifyOfPropertyChange(() => IsBaby);
                NotifyOfPropertyChange(() => IsKid);
                NotifyOfPropertyChange(() => IsFreshMan);
                NotifyOfPropertyChange(() => IsPro);
                NotifyOfPropertyChange(() => IsInsane);
            }
        }

        public bool IsBaby
        {
            get => Difficulty == Difficulty.Baby;
            set
            {
                if (Difficulty == Difficulty.Baby) return;
                Difficulty = Difficulty.Baby;
            }
        }

        public bool IsKid
        {
            get => Difficulty == Difficulty.Kid;
            set
            {
                if (Difficulty == Difficulty.Kid) return;
                Difficulty = Difficulty.Kid;
            }
        }

        public bool IsFreshMan
        {
            get => Difficulty == Difficulty.FreshMan;
            set
            {
                if (Difficulty == Difficulty.FreshMan) return;
                Difficulty = Difficulty.FreshMan;
            }
        }

        public bool IsPro
        {
            get => Difficulty == Difficulty.Pro;
            set
            {
                if (Difficulty == Difficulty.Pro) return;
                Difficulty = Difficulty.Pro;
            }
        }

        public bool IsInsane
        {
            get => Difficulty == Difficulty.Insane;
            set
            {
                if (Difficulty == Difficulty.Insane) return;
                Difficulty = Difficulty.Insane;
            }
        }

        public MenuViewModel()
        {
            IsFreshMan = true;

        }

        public void Start()
        {
            if (!(Parent is IConductor parent)) return;
            switch (Difficulty)
            {
                case Difficulty.Baby:
                    parent.ActivateItem(new GameViewModel(new GameModel(new Cell())));
                    break;
                case Difficulty.Kid:
                    parent.ActivateItem(new GameViewModel(new GameModel(new Field<Cell>())));
                    break;
                case Difficulty.FreshMan:
                    parent.ActivateItem(new GameViewModel(new GameModel(new Field<Field<Cell>>())));
                    break;
                case Difficulty.Pro:
                    parent.ActivateItem(new GameViewModel(new GameModel(new Field<Field<Field<Cell>>>())));
                    break;
                case Difficulty.Insane:
                    parent.ActivateItem(new GameViewModel(new GameModel(new Field<Field<Field<Field<Cell>>>>())));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}