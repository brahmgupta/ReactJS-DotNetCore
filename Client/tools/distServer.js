import express from 'express';
import path from 'path';
import open from 'open';
import compression from 'compression';

/* eslint-disable no-console */
// This file will configure web server that serves file in source directory

const distPort = 4000;
const app = express();

app.use(compression());
app.use(express.static('dist'));

app.get('*', function(req, res) {
  res.sendFile(path.join( __dirname, '../dist/index.html'));
});

app.listen(distPort, function(err) {
  if (err) {
    console.log(err);
  } else {
    open(`http://localhost:${distPort}`);
  }
});
