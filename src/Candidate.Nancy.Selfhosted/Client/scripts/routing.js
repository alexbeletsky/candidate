define(function (require) {

    var ViewManager = require('ViewManager');
    
    // router
    var ApplicationRouter = Backbone.Router.extend({

        initialize: function () {
            this.viewManager = new ViewManager();
        },

        routes: {
            '': 'dashboard',
            'configure/sites/:id': 'configure'
        },

        dashboard: function () {
            var app = require('./apps/DashboardApp');
            app.run(this.viewManager);
        },

        configure: function (id) {
            var app = require('./apps/ConfigureApp');
            app.run(id, this.viewManager);
        }

    });

    return {
        start: function () {
            new ApplicationRouter();
            Backbone.history.start();
        }
    };
});