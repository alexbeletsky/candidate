define(function (require) {

    var Hogan = require('Hogan');

    // views
    var BaseView = require('../../shared/BaseView');
    var SiteRowView = require('./SiteRowView');

    var _template = require('text!/scripts/templates/dashboard/sitesList.html');
    var _compiled = Hogan.compile(_template);

    var SitesListView = BaseView.extend({
        initialize: function (options) {
            _.bindAll(this);

            if (!(options && options.collection)) {
                throw 'SitesListView: collection is required';
            }

            this.collection = options.collection;

            this.bindTo(this.collection, 'add', this.onSiteAdded);
        },

        template: function (context) {
            return _compiled.render(context);
        },

        onRender: function () {
            this.collection.each (function (site) {
                var siteRowView = new SiteRowView ({ model: site });
                this.appendSubview(siteRowView.render(), this.$('.candidate-sites'));
            }, this);
        },

        onSiteAdded: function (site) {
            var siteRowView = new SiteRowView ({ model: site });
            this.appendSubview(siteRowView.render(), this.$('.candidate-sites'));
        }
    });
    
    return SitesListView;
});