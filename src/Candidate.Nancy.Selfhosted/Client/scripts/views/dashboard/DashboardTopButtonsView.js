define(function (require) {

    var BaseView = require('../../shared/BaseView');
    var AddNewSiteModalView = require('./AddNewSiteModalView');
    var _template = require('text!/scripts/templates/dashboard/topButtons.html');

    var DashboardTopButtonsView = BaseView.extend({
        template: function () {
            return _template;
        },

        events: {
            'click a.addSite': 'onAddSiteClick'
        },

        onAddSiteClick: function () {
            var addNewSiteModalView = new AddNewSiteModalView();
            addNewSiteModalView.render();
        }
    });

    return DashboardTopButtonsView;

});