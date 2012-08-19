define(function (require) {

    // views
    var BaseView = require('../../shared/BaseView');
    var AddNewSiteModalView = require('./AddNewSiteModalView');

    // models
    var Site = require('../../models/Site');

    // templates
    var _template = require('text!/scripts/templates/dashboard/topButtons.html');

    var TopButtonsView = BaseView.extend({
        template: function () {
            return _template;
        },

        events: {
            'click a.addSite': 'onAddSiteClick'
        },

        onAddSiteClick: function () {
            var model = new Site();
            var addNewSiteModalView = new AddNewSiteModalView( { model: model });
            addNewSiteModalView.render();
        }
    });

    return TopButtonsView;

});