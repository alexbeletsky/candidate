define(function (require) {

    var Hogan = require('Hogan');
    var BaseView = require('../../shared/BaseView');

    var _template = require('text!/scripts/templates/dashboard/sitesList.html');
    var _compiled = Hogan.compile(_template);

    var DashboardSitesListView = BaseView.extend({
        template: function (context) {
            return _compiled.render(context);
        }
    });

    return DashboardSitesListView;
});