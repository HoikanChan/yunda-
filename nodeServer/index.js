var net = require('net');

var client = new net.Socket();
function padding(num, length) {
  return (Array(length).join('0') + num).slice(-length);
}
const getRandom = (max, length) =>
  padding(Math.floor(Math.random() * max), length);

client.connect(8080, '127.0.0.1', function() {
  console.log('Connected');
  let i = 0;
  setInterval(() => {
    // if(i++>5)return;
    let carId = getRandom(100, 4);
    let msg = `[P${getRandom(16, 2)}][${carId}]0.${getRandom(
      100,
      2
    )}`;
    const sorterNo = client.write(msg);
    console.log(msg)
    setTimeout(() => {
      let msg = `[C${carId}]170753900001${getRandom(1000, 4)}`
      client.write(msg);
      console.log(msg);
    }, 1000);
  }, 500);
});

client.on('data', function(data) {
  console.log('[O' + data + ']');
  setTimeout(() => {
    client.write('[O' + data + ']');
  }, 3000);
  // client.destroy(); // kill client after server's response
});

client.on('close', function() {
  console.log('Connection closed');
});
