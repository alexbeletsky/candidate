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
        Underscore: 'libs/underscore'
    }
});

require(['routing'], function (routing) {
    routing.start();
});
