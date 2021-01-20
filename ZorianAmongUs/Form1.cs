using AmongUsCapture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZorianAmongUs
{
    public partial class Form1 : Form
    {
        private string destination = "http://localhost:8123/";

        private string username = "admin";

        private string password = "supersecret";

        private HttpClient httpClient = new HttpClient();

        private LobbyEventArgs LobbyInfo = null;

        private ConnectionStatus Status = ConnectionStatus.Offline;

        public Form1()
        {
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            InitializeComponent();
            GameMemReader.getInstance().GameStateChanged += GameStateChangedHandlerAsync;
            GameMemReader.getInstance().PlayerChanged += UserForm_PlayerChangedAsync;
            GameMemReader.getInstance().ChatMessageAdded += OnChatMessageAdded;
            GameMemReader.getInstance().JoinedLobby += OnJoinedLobbyAsync;
        }

        private async void OnJoinedLobbyAsync(object sender, LobbyEventArgs e)
        {
            this.LobbyInfo = e;
            if (this.Status == ConnectionStatus.Online)
            {
                LobbyMessage msg = new LobbyMessage(codeText.Text, this.LobbyInfo);
                try
                {
                    await httpClient.PostAsync(destination + "lobby", new StringContent(JsonSerializer.Serialize(msg), null, "application/json"));
                }
                catch
                {

                }
            }
        }

        private async void OnChatMessageAdded(object sender, ChatMessageEventArgs e)
        {
            ChatMessage msg = new ChatMessage(codeText.Text, e);
            try
            {
                await httpClient.PostAsync(destination + "chat", new StringContent(JsonSerializer.Serialize(msg), null, "application/json"));
            }
            catch
            {

            }
        }

        private async void UserForm_PlayerChangedAsync(object sender, PlayerChangedEventArgs e)
        {
            PlayerMessage msg = new PlayerMessage(codeText.Text, e);
            try
            {
                await httpClient.PostAsync(destination + "player", new StringContent(JsonSerializer.Serialize(msg), null, "application/json"));
            }
            catch
            {

            }
        }

        private async void GameStateChangedHandlerAsync(object sender, GameStateChangedEventArgs e)
        {
            GameStateMessage msg = new GameStateMessage(codeText.Text, e);
            try
            {
                await httpClient.PostAsync(destination + "state", new StringContent(JsonSerializer.Serialize(msg), null, "application/json"));
            }
            catch
            {

            }
        }

        private async void sendCode_Click(object sender, EventArgs e)
        {
            CodeMessage msg = new CodeMessage(codeText.Text);
            try
            {
                var response = await httpClient.PostAsync(destination + "newLobby", new StringContent(JsonSerializer.Serialize(msg), null, "application/json"));
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (content == "OK")
                    {
                        statusText.Text = "Online";
                        statusText.BackColor = Color.Green;
                        this.Status = ConnectionStatus.Online;
                        if (this.LobbyInfo != null)
                        {
                            this.OnJoinedLobbyAsync(this, this.LobbyInfo);
                        }
                    }
                    else
                    {
                        statusText.Text = "Lobby exists";
                        statusText.BackColor = Color.Yellow;
                        this.Status = ConnectionStatus.Offline;
                    }
                }
                else
                {
                    statusText.Text = "Bad code";
                    statusText.BackColor = Color.Red;
                    this.Status = ConnectionStatus.Offline;
                }
            }
            catch
            {
                MessageBox.Show("Can't connect", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CodeMessage msg = new CodeMessage(codeText.Text);
            try
            {
                await httpClient.PostAsync(destination + "closeLobby", new StringContent(JsonSerializer.Serialize(msg), null, "application/json"));
            }
            catch
            {

            }
        }
    }
}
