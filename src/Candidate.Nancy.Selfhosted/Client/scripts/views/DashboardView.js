define(function (require) {

    var BaseView = require('../shared/BaseView');

    // sub-views
    var TopButtonsView = require('../views/dashboard/TopButtonsView');
    var SitesListView = require('../views/dashboard/SitesListView');

    var DashboardView = BaseView.extend({
        initialize: function (options) {
            if ((!options && options.collection)) {
                throw 'DashboardView: collection is required';
            }

            this.collection = options.collection;
        },

        onRender: function () {

            var addSiteButtonView = new TopButtonsView({ collection: this.collection });
            this.appendSubview(addSiteButtonView.render());

            var sitesListView = new SitesListView({ collection: this.collection });
            this.appendSubview(sitesListView.render());
        }
    });

    return DashboardView;
});