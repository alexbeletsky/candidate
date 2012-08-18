define(function (require) {

    var ViewManager = require('ViewManager');
    
    // applications
    var Applications = {
        'dashboard': require('./apps/DashboardApp')
    };

    var ApplicationRouter = Backbone.Router.extend({

        initialize: function () {
            this.viewManager = new ViewManager();
            this.currentApplication = null;
        },

        routes: {
            '': 'dashboard',
            'account': 'account'
        },

        dashboard: function () {
            this.currentApplication = Applications['dashboard'].run(this.viewManager);
        },

        account: function () {
            alert('account');
        }

    });

    return {
        start: function () {
            new ApplicationRouter();
            Backbone.history.start({ pushState: true });
        }
    };
});