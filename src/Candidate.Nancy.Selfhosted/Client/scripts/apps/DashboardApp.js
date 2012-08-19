define(function (require) {

    // views
    var DashboardView = require('../views/dashboard/MainView');

    // models
    var Sites = require('../models/Sites');

    // boostsrapper
    var bootstrap = function (callback) {
        var sites = new Sites();
        sites.fetch({ success: function () {
            callback(sites);
        }});
    };

    var DashboardApp = {
        run: function (viewManager) {
            bootstrap(function (sites) {
                var view = new DashboardView({ collection: sites });
                viewManager.show(view);
            });
        }
    };

    return DashboardApp;

});