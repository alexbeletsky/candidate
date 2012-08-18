define(function (require) {

    var Site = Backbone.Model.extend({
        urlRoot: '/api/site',

        defaults: {
            'name': null,
            'status': null,
            'description': null
        }
    });

    return Site;
});