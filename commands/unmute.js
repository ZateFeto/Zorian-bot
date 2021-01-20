module.exports = {
	name: 'unmute',
	description: 'unmute all memmbers in a channel',
	execute(message, args) {
        let admin = message.member.roles.cache.find(r => r.name === "Admin");
        let crown = message.member.roles.cache.get("735079355990147133");
        if (admin || crown) {
            if (message.member.voice.channel) {
                let channel = message.guild.channels.cache.get(message.member.voice.channel.id);
                for (const [memberID, member] of channel.members) {
                    if (member != message.member) member.voice.setMute(false);
                }
                message.channel.send('Everybody has been unshushed');
            } else message.reply('You need to join a voice channel first!');
        }
	},
};
