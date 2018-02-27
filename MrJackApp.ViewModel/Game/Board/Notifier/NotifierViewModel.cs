using MrJackApp.ViewModel.Common;
using MrJackApp.ViewModel.Common.Command;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MrJackApp.ViewModel.Game.Board.Notifier
{
    public sealed class NotifierViewModel : BindableBase
    {
        private List<string> _messages = new List<string>();

        private string _currentMessage;
        public string CurrentMessage
        {
            get { return _currentMessage; }
            private set { SetProperty(ref _currentMessage, value); }
        }

        public ICommand NextMessageCommand { get; private set; }

        public NotifierViewModel() : base()
        {
            NextMessageCommand = new DelegateCommand(NextMessageCommandExecute);
        }

        public void Notify(IEnumerable<string> messages)
        {
            _messages.AddRange(messages);

            if (CurrentMessage == null)
                NextMessageCommand.Execute(null);
        }

        public void Notify(string message)
        {
            Notify(new List<string> { message });
        }

        public void NextMessageCommandExecute()
        {
            if (_messages.Count > 0)
            {
                var message = _messages[0];
                _messages.RemoveAt(0);
                CurrentMessage = message;
            }
            else
            {
                _currentMessage = null;
                RaiseAllMessagesDisplayed();
            }
        }

        public delegate void AllMessagesDisplayedEventHandler(object sender, EventArgs e);
        public event AllMessagesDisplayedEventHandler AllMessagesDisplayed;

        private void RaiseAllMessagesDisplayed()
        {
            AllMessagesDisplayed?.Invoke(this, EventArgs.Empty);
        }
    }
}
