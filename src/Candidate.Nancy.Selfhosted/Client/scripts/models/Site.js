define(function (require) {
    var Backbone = require('Backbone');

    var Site = Backbone.Model.extend({
        urlRoot: '/api/site',

        defaults: {
            'name': null,
            'status': null
        }
    });

    return Site;
});