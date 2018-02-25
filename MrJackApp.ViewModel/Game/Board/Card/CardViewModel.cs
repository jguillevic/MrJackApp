using MrJackApp.DTO.Game.Board.Card;
using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Common.Command;
using System;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Game.Board.Card
{
    public sealed class CardViewModel : BindableBase
    {
        public string Name { get; set; }
        public int CharacterId { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        public ICommand SelectionCommand { get; private set; }

        public CardViewModel(CardDTO card) : base()
        {
            Map(card);
            SetCommands();
        }

        private void Map(CardDTO card)
        {
            Name = card.Name;
            CharacterId = card.CharacterId;
        }

        private void SetCommands()
        {
            SelectionCommand = new DelegateCommand(SelectionCommandExecute);
        }

        public delegate void SelectedEventHandler(object sender, EventArgs e);
        public event SelectedEventHandler Selected;

        private void SelectionCommandExecute()
        {
            IsSelected = !IsSelected;
            RaiseSelected();
        }

        private void RaiseSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }
    }
}
