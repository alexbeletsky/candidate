define(function (require) {

    var Hogan = require('Hogan');

    // views
    var BaseView = require('../../shared/BaseView');

    // templates
    var _template = require('text!/scripts/templates/dashboard/site.html');
    var _compiled = Hogan.compile(_template);

    var SiteRowView = BaseView.extend({
        template: function (context) {
            return _compiled.render(context);
        },

        templateContext: function () {
            return this.model.toJSON();
        }
    });

    return SiteRowView;

});