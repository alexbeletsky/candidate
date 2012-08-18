define(function (require) {

    var HomeView = require('../views/homeView');
    var Sites = require('../models/sites');

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