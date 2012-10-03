define(['../views/dashboard/MainView', '../models/Sites'],
    function (MainView, Sites) {

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
                var view = new MainView({ collection: sites });
                viewManager.show(view);
            });
        }
    };

    return DashboardApp;

});