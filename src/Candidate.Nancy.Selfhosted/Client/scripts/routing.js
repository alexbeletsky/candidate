define(function (require) {

    var ViewManager = require('ViewManager');
    
    // router
    var ApplicationRouter = Backbone.Router.extend({

        initialize: function () {
            this.viewManager = new ViewManager();
        },

        routes: {
            '': 'dashboard',
            'configure/sites/:id': 'configure',
            'configure/sites/:id/:section': 'configureSection'
        },

        dashboard: function () {
            var app = require('./apps/DashboardApp');
            app.run(this.viewManager);
        },

        configure: function (id) {
            var app = require('./apps/ConfigureApp');
            app.run({ id: id}, this.viewManager);
        },

        configureSection: function (id, section) {
            var app = require('./apps/ConfigureApp');
            app.run({ id: id, section: section }, section, this.viewManager);
        }

    });

    return ApplicationRouter;
});