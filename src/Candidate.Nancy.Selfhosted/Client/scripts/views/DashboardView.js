define(function (require) {

    var BaseView = require('../shared/BaseView');

    // sub-views
    var TopButtonsView = require('../views/dashboard/TopButtonsView');
    var SitesListView = require('../views/dashboard/SitesListView');

    var DashboardView = BaseView.extend({
        onRender: function () {

            var addSiteButtonView = new TopButtonsView();
            this.appendSubview(addSiteButtonView.render());

            var sitesListView = new SitesListView();
            this.appendSubview(sitesListView.render());
        }
    });

    return DashboardView;
});