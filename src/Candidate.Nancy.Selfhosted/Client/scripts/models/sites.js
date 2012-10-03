define(['./Site'],
    function (Site) {
    
    var SitesCollection = Backbone.Collection.extend({
        url: '/api/sites',

        model: Site
    });

    return SitesCollection;
});