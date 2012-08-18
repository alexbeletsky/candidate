var argv = process.argv;
var dirname = argv[2];

if (!dirname) {
	console.log('usage: server.js dirname');
	return;
}

var livereload = require('livereload');
var server = livereload.createServer({
	debug: true,
	ext: 'tmpl'
});

server.watch(dirname);