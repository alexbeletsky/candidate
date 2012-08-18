define(function (require) {

    var HomeView = require('../views/HomeView');
    var Sites = require('../models/Sites');

    var HomeApp = {
        run: function (viewManager) {
            var sites = new Sites();
            sites.fetch({
                success: function () {
                    viewManager.show(new HomeView({ model: sites }));
                }
            });
        }
    }

    return HomeApp;
});