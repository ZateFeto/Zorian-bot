const Discord = require('discord.js');

const express = require('express');
const basicAuth = require('express-basic-auth');

const app = express();

app.use(basicAuth({
    users: { 'admin': 'supersecret' }
}));

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

//TODO: move to different file
class Lobby {
    constructor(code) {
        this.Code = code;
    }
}

const client = new Discord.Client();
const { PREFIX: prefix, BOT_TOKEN: token } = process.env
const fs = require('fs');
client.commands = new Discord.Collection();
const commandFiles = fs.readdirSync('./commands/').filter(file => file.endsWith('.js'));

for (const file of commandFiles) {
	const command = require(`./commands/${file}`);
	client.commands.set(command.name, command);
}

client.once('ready', () => {
 console.log(`Logged in as ${client.user.tag}!`);
});

client.on('message', message => {
	if (!message.content.startsWith(prefix) || message.author.bot) return;
	const args = message.content.slice(prefix.length).split(/ +/);
	const commandName = args.shift().toLowerCase();

	if (!client.commands.has(commandName)) return;
	const command = client.commands.get(commandName);

	try {
		command.execute(message, args);
	}
	catch (error) {
		console.error(error);
		message.reply('there was an error trying to execute that command!');
	}
});

client.login(token);

var lobbies = {};

app.post('/newLobby', (req, res) => {
    console.log(req.body);
    if (req.body.Token !== undefined && req.body.Token !== null && req.body.Token.length > 0) {
        if (lobbies[req.body.Token] === undefined) {
            lobbies[req.body.Token] = new Lobby(req.body.Token);
            return res.send('OK');
        }
        else
        {
            res.send('EXISTS');
        }
    } 
    else
    {
        res.status(400).send('BADREQUEST');
    }
});


app.post('/closeLobby', (req, res) => {
    if (lobbies[req.body.Token] !== undefined) {
        delete codes[req.body.Token];
    }
    return res.send('OK');
});

app.post('/lobby', (req, res) => {
    console.log(req.body);
    return res.send('OK');
});


app.post('/state', (req, res) => {
    console.log(req.body);
    return res.send('OK');
});


app.post('/player', (req, res) => {
    console.log(req.body);
    return res.send('OK');
});


app.post('/chat', (req, res) => {
    console.log(req.body);
    return res.send('OK');
});

app.listen(8123, () =>
    console.log('Example app listening on port 8123!')
);


const http = require('http');
const server = http.createServer((req, res) => {
  res.writeHead(200);
  res.end('ok');
});
server.listen(3000);
