/*client.on('message', msg => {
  if (msg.content === 'test1') {
    msg.reply('test1 2');
  }
})
*/

module.exports = {
	name: 'test1',
	description: 'this is a ping command',
	execute(message, args) {
		message.channel.send('im still not sleeping 2');
	},
};
