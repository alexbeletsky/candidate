define(function (require) {

    var BaseView = require('../../shared/BaseView');

    // sub-views
    var TopButtonsView = require('./subviews/TopButtonsView');
    var SitesListView = require('./subviews/SitesListView');

    var DashboardView = BaseView.extend({
        className: 'row',

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