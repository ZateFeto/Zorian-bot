using AmongUsCapture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorianAmongUs
{
    class LobbyMessage
    {
        public LobbyEventArgs GameEvent { get; private set; }
        public string Token { get; private set; }
        public LobbyMessage(string token, LobbyEventArgs e)
        {
            this.Token = token;
            this.GameEvent = e;
        }
    }

    class ChatMessage
    {
        public ChatMessageEventArgs GameEvent { get; private set; }
        public string Token { get; private set; }
        public ChatMessage(string token, ChatMessageEventArgs e)
        {
            this.Token = token;
            this.GameEvent = e;
        }
    }

    class PlayerMessage
    {
        public PlayerChangedEventArgs GameEvent { get; private set; }
        public string Token { get; private set; }
        public PlayerMessage(string token, PlayerChangedEventArgs e)
        {
            this.Token = token;
            this.GameEvent = e;
        }
    }

    class GameStateMessage
    {
        public GameStateChangedEventArgs GameEvent { get; private set; }
        public string Token { get; private set; }
        public GameStateMessage(string token, GameStateChangedEventArgs e)
        {
            this.Token = token;
            this.GameEvent = e;
        }
    }

    class CodeMessage
    {
        public string Token { get; private set; }
        public CodeMessage(string token)
        {
            this.Token = token;
        }
    }
}
