define(['ViewManager', './apps/DashboardApp', './apps/ConfigureApp'],
    function (ViewManager, DashboardApp, ConfigureApp) {

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
            DashboardApp.run(this.viewManager);
        },

        configure: function (id) {
            ConfigureApp.run({ id: id}, this.viewManager);
        },

        configureSection: function (id, section) {
            ConfigureApp.run({ id: id, section: section }, section, this.viewManager);
        }

    });

    return ApplicationRouter;
});