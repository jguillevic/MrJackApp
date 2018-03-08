using MrJackApp.DTO.Game.Board.Character;
using MrJackApp.ViewModel.Common;
using System;
using System.Collections.ObjectModel;

namespace MrJackApp.ViewModel.Game.Board.Character
{
    public sealed class CharactersDisplayerViewModel : BindableBase
    {
        public ObservableCollection<CharacterViewModel> Characters { get; } = new ObservableCollection<CharacterViewModel>();

        public CharactersDisplayerViewModel(CharacterDTO[] characters) : base()
        {
            Map(characters);
        }

        private void Map(CharacterDTO[] characters)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                CharacterViewModel charViewModel = null;
                var character = characters[i];

                switch (character.Kind)
                {
                    case CharacterKind.SherlockHolmes:
                        charViewModel = new SherlockHolmesViewModel(character);
                        break;
                    case CharacterKind.JohnHWatson:
                        charViewModel = new JohnHWatsonViewModel(character);
                        break;
                    case CharacterKind.JohnSmith:
                        charViewModel = new JohnSmithViewModel(character);
                        break;
                    case CharacterKind.InspecteurLestrade:
                        charViewModel = new InspecteurLestradeViewModel(character);
                        break;
                    case CharacterKind.MissStealthy:
                        charViewModel = new MissStealthyViewModel(character);
                        break;
                    case CharacterKind.SergentGoodley:
                        charViewModel = new SergentGoodleyViewModel(character);
                        break;
                    case CharacterKind.SirWilliamGull:
                        charViewModel = new SirWilliamGullViewModel(character);
                        break;
                    case CharacterKind.JeremyBert:
                        charViewModel = new JeremyBertViewModel(character);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                Characters.Add(charViewModel);
            }
        }
    }
}
