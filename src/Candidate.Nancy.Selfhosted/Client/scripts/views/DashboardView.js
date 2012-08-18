define(function (require) {

    var BaseView = require('../shared/BaseView');

    // sub-views
    var DashboardTopButtonsView = require('../views/dashboard/DashboardTopButtonsView');
    var DashboardSitesListView = require('../views/dashboard/DashboardSitesListView');

    var DashboardView = BaseView.extend({
        onRender: function () {

            var addSiteButtonView = new DashboardTopButtonsView();
            this.appendSubview(addSiteButtonView.render());

            var sitesListView = new DashboardSitesListView();
            this.appendSubview(sitesListView.render());
        }
    });

    return DashboardView;
});