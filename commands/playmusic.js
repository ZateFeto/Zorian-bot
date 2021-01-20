
// // ReadableStreams, in this example YouTube audio
// const ytdl = require('ytdl-core');
// connection.play(ytdl('https://www.youtube.com/watch?v=ZlAU_w7-Xp8', { filter: 'audioonly' }));

// // Files on the internet
// connection.play('http://www.sample-videos.com/audio/mp3/wave.mp3');

// // Local files
// connection.play('/home/discord/audio.mp3');


module.exports = {
	name: 'playtest',
	description: 'youtube music play test',
	async execute(message, args) {
        const connection = await message.member.voice.channel.join();
        const ytdl = require('ytdl-core');
        connection.play(ytdl('https://www.youtube.com/watch?v=ZlAU_w7-Xp8', { filter: 'audioonly' }));
	},
};
