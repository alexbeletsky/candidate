define(function (require) {
    var Backbone = require('Backbone');
    var Site = require('./Site');

    var SitesCollection = Backbone.Collection.extend({
        url: '/api/sites',

        model: Site
    });

    return SitesCollection;
});