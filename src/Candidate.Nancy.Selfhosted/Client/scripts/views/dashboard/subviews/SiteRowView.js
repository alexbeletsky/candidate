define(['Hogan', '../../../shared/BaseView', 'text!/scripts/templates/dashboard/site.html'],
    function (Hogan, BaseView, template) {

    var SiteRowView = BaseView.extend({
        initialize: function () {
            _.bindAll(this);
        },

        events: {
            'click span.delete a': 'onDelete'
        },

        template: function (context) {
            return Hogan.compile(template).render(context);
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