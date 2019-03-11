var net = require('net');

var client = new net.Socket();
client.connect(8080, '127.0.0.1', function() {
	console.log('Connected');
	setInterval(()=>{
		const no = Math.floor(Math.random() * 100)+100
		client.write(`[C0${no}]1707539000017034`);
		console.log("发送"+no+"小车条码")
	},500)
});

client.on('data', function(data) {
		console.log('Received: ' + data);
		setTimeout(() => {
			client.write("[O"+data+"]")
		}, 3000);
	// client.destroy(); // kill client after server's response
});

client.on('close', function() {
	console.log('Connection closed');
});