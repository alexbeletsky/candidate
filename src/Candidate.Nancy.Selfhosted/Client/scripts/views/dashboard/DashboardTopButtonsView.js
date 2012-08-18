define(function (require) {

    var BaseView = require('../../shared/BaseView');
    var _template = require('text!/scripts/templates/dashboard/topButtons.html');

    var DashboardTopButtonsView = BaseView.extend({
        template: function () {
            return _template;
        }
    });

    return DashboardTopButtonsView;

});