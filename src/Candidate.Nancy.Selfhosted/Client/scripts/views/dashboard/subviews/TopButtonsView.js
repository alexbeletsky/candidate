define(function (require) {

    // views
    var BaseView = require('../../../shared/BaseView');
    var AddNewSiteModalView = require('./AddNewSiteModalView');

    // models
    var Site = require('../../../models/Site');

    // templates
    var _template = require('text!/scripts/templates/dashboard/topButtons.html');

    var TopButtonsView = BaseView.extend({
        initialize: function (options) {
            if (!(options && options.collection)) {
                throw 'TopButtonsView: collection is required';
            }

            this.collection = options.collection;
        },

        template: function () {
            return _template;
        },

        events: {
            'click a.addSite': 'onAddSiteClick'
        },

        onAddSiteClick: function (e) {
            var model = new Site();
            var addNewSiteModalView = new AddNewSiteModalView( { model: model, collection: this.collection });
            addNewSiteModalView.render();

            e.preventDefault();
        }
    });

    return TopButtonsView;

});