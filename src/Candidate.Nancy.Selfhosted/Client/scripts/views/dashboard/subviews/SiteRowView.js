define(function (require) {

    var Hogan = require('Hogan');

    // views
    var BaseView = require('../../../shared/BaseView');

    var SiteRowView = BaseView.extend({
        initialize: function () {
            _.bindAll(this);
        },

        events: {
            'click span.delete a': 'onDelete'
        },

        template: function (context) {
            var _template = require('text!/scripts/templates/dashboard/site.html');
            var _compiled = Hogan.compile(_template);

            return _compiled.render(context);
        },

        templateContext: function () {
            return this.model.toJSON();
        },

        onDelete: function(e) {
            e.preventDefault();
            
            this.model.destroy();
        }

    });

    return SiteRowView;

});