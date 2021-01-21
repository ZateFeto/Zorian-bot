//member.voice.kick()
//.kick(reason)
//Kicks the member from the voice channel.

//we need the command to be like you type "vkick @user" in text chat and it then will disconnect him from the voice channel he is connected from.

module.exports = {
	name: 'vkick',
	description: 'voice kick a person from the connected channel',
	execute(message, args) {
        let admin = message.member.roles.cache.find(r => r.name === "Admin");
        let crown = message.member.roles.cache.get("735079355990147133");
        if (admin || crown) {
            // Make sure the bot user has permissions to move members in the guild:
            if (!message.guild.me.hasPermission('MOVE_MEMBERS')) return message.reply('Missing the required `Move Members` permission.');

            // Get the mentioned user/bot and check if they're in a voice channel:
            const member = message.mentions.members.first();
            if (!member) return message.reply('You need to @mention a user/bot to kick from the voice channel.');

            if (!member.voice.channel) return message.reply('That user/bot isn\'t in a voice channel.'); 

            // Now we set the member's voice channel to null, in other words disconnecting them from the voice channel.
            member.voice.setChannel(null);
            
            // Finally, pass some user response to show it all worked out:
            message.react('👌');
            /* or just "message.reply", etc.. up to you! */
        }
  }, 
};

