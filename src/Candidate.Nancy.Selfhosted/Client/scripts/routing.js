define(function (require) {

    var ViewManager = require('ViewManager');
    
    // applications
    var Applications = {
        'dashboard': require('./apps/DashboardApp'),
        'configure': require('./apps/ConfigureApp')
    };

    // router
    var ApplicationRouter = Backbone.Router.extend({

        initialize: function () {
            this.viewManager = new ViewManager();
            this.currentApplication = null;
        },

        routes: {
            '': 'dashboard',
            'configure/sites/:id': 'configure'
        },

        dashboard: function () {
            Applications['dashboard'].run(this.viewManager);
        },

        configure: function () {
            Applications['configure'].run(this.viewManager);
        }

    });

    return {
        start: function () {
            new ApplicationRouter();
            Backbone.history.start();
        }
    };
});