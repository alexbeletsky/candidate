define(function (require) {

    var Site = Backbone.Model.extend({
        urlRoot: '/api/site',

        defaults: {
            'name': null,
            'status': null,
            'description': null
        },

        validate: function (attributes) {
            attributes = attributes || this.attributes;

            var name = attributes.name;
            if (!_.isString(name) || name.length <= 0) {
                return { field: 'name', message: 'Site name is required field' };
            }
        }

    });

    return Site;
});