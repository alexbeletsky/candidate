define(['../../shared/BaseView', './subviews/TopButtonsView', './subviews/SitesListView'],
    function (BaseView, TopButtonsView, SitesListView) {

    var MainView = BaseView.extend({
        className: 'row',

        initialize: function (options) {
            if ((!options && options.collection)) {
                throw 'MainView: collection is required';
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

    return MainView;
});