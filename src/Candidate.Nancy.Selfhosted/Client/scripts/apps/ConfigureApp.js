define(function (require) {

    // views
    var MainView = require('../views/configure/MainView');

    // models
    var Site = require('../models/Site');

    // bootsrapper
    var bootsrapper = function (id, callback) {
        var site = new Site({ id: id});
        site.fetch({
            success: function() {
                callback(site);
            }
        });
    };

    var ConfigureApp = {
        run: function (context, viewManager) {
            bootsrapper(context.id, function (site) {
                var view = new MainView({ model: site, section: context.section || 'overview' });
                viewManager.show(view);
            });
        }
    };

    return ConfigureApp;

});