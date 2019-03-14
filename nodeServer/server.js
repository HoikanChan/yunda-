const express = require('express');
const cors = require('cors');
const morgan = require('morgan');
const bodyParser = require('body-parser');
const app = express();
app.use(morgan());
app.use(cors());
app.use(bodyParser());
app.get('/getCarDestination', (req, res) => {
  const no = Math.floor(Math.random() * 16);
  const arr = [
    '405476679929',
    '405470879435',
    '405476945722',
    '405476232942',
    '405471232942',
    '405476231232',
    '405762329123',
    '405476232562',
    '405476232832',
    '405476240883',
    '405476232812',
    '405432342846',
    '405476232846',
    '405476349546',
    '405472340284',
    '405476223423'
  ];
  console.log('订单号为' + req.query.orderNumber + ',落格号为' + arr[no]);
  res.send(arr[no].toString());
});
app.listen(8000);
console.log('Server started on port 8000');
