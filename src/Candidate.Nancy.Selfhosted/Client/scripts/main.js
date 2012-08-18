require.config({
    shim: {
        'Underscore': {
            exports: '_'
        },

        'Backbone': {
            deps: ['Underscore', 'jQuery'],
            exports: 'Backbone'
        },

        'BootstrapModal': {
            deps: ['jQuery']
        }
    },

    paths: {
        text: 'libs/text',
        Backbone: 'libs/backbone',
        jQuery: 'libs/jquery-1.7.2',
        Underscore: 'libs/underscore',
        Mustache: 'libs/mustache',
        Hogan: 'libs/hogan-1.0.5.amd',
        BootstrapModal: 'libs/bootsrap-modal'
    }
});

require(['jQuery', 'Routing', 'Underscore', 'Backbone', 'BootstrapModal'], function ($, routing) {
    routing.start();
});
