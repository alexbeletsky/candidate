require.config({
    shim: {
        'Underscore': {
            exports: '_'
        },

        'Backbone': {
            deps: ['Underscore', 'jQuery'],
            exports: 'Backbone'
        }
    },

    paths: {
        text: 'libs/text',
        Backbone: 'libs/backbone',
        jQuery: 'libs/jquery-1.7.2',
        Underscore: 'libs/underscore',
        Mustache: 'libs/mustache',
        Hogan: 'libs/hogan-1.0.5.amd'
    }
});

require(['Routing'], function (routing) {
    routing.start();
});
