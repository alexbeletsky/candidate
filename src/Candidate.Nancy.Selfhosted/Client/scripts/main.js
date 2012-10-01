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
        },

        'Routing': {
            deps: ['jQuery', 'Underscore', 'Backbone', 'BootstrapModal']
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

require(['Routing'], function (ApplicationRouter) {
    var app = {
        root: '/'
    };

    Router = new ApplicationRouter();
    Backbone.history.start({ pushState: true });

    // All navigation that is relative should be passed through the navigate
    // method, to be processed by the router. If the link has a `data-bypass`
    // attribute, bypass the delegation completely.
    $(document).on("click", "a[href]:not([data-bypass])", function(evt) {
        // Get the absolute anchor href.
        var href = { prop: $(this).prop("href"), attr: $(this).attr("href") };
        // Get the absolute root.
        var root = location.protocol + "//" + location.host + app.root;

        // Ensure the root is part of the anchor href, meaning it's relative.
        if (href.prop.slice(0, root.length) === root) {
          // Stop the default event to ensure the link will not cause a page
          // refresh.
          evt.preventDefault();

          // `Backbone.history.navigate` is sufficient for all Routers and will
          // trigger the correct events. The Router's internal `navigate` method
          // calls this anyways.  The fragment is sliced from the root.
          Backbone.history.navigate(href.attr, true);
        }
    });
});
