using MrJackApp.DTO.Game.Board.Card;
using MrJackApp.ViewModel.Common;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MrJackApp.ViewModel.Game.Board.Card
{
    public abstract class CardsDisplayerViewModel : BindableBase
    {
        private CardViewModel _selectedCard;

        public ObservableCollection<CardViewModel> Cards { get; private set; } = new ObservableCollection<CardViewModel>();

        public CardsDisplayerViewModel() : base()
        {
            Cards.CollectionChanged += CardsCollectionChanged;
        }

        private void CardsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (CardViewModel newItem in e.NewItems)
                    newItem.Selected += CardViewModelSelected;
            }

            if (e.OldItems != null)
            {
                foreach (CardViewModel oldItem in e.OldItems)
                    oldItem.Selected -= CardViewModelSelected;
            }
        }

        private void CardViewModelSelected(object sender, EventArgs e)
        {
            var oldSelectedCard = _selectedCard;
            var newSelectedCard = (CardViewModel)sender;

            if (oldSelectedCard != null && oldSelectedCard != newSelectedCard && oldSelectedCard.IsSelected)
            {
                oldSelectedCard.Selected -= CardViewModelSelected;
                oldSelectedCard.IsSelected = false;
                oldSelectedCard.Selected += CardViewModelSelected;
            }

            _selectedCard = newSelectedCard;
            RaiseCardSelected(newSelectedCard);
        }

        public void AddCards(CardDTO[] cards)
        {
            foreach (var card in cards)
            {
                var cardViewModel = new CardViewModel(card);
                Cards.Add(cardViewModel);
            }
        }

        public void Clear()
        {
            Cards.Clear();
        }

        public delegate void SelectedEventHandler(object sender, CardSelectedEventArgs e);
        public event SelectedEventHandler CardSelected;

        private void RaiseCardSelected(CardViewModel card)
        {
            CardSelected?.Invoke(this, new CardSelectedEventArgs { Card = card });
        }
    }
}
