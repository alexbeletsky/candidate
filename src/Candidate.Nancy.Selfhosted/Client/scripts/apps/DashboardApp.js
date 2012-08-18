define(function (require) {

    var DashboardView = require('../views/DashboardView');

    var DashboardApp = {
        run: function (viewManager) {
            var view = new DashboardView();
            viewManager.show(view);
        }
    };

    return DashboardApp;

});