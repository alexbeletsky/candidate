define(function (require) {

    // views
    var ConfigureView = require('../views/configure/MainView');

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
        run: function (id, viewManager) {
            bootsrapper(id, function (site) {
                var view = new ConfigureView({ model: site });
                viewManager.show(view);
            });
        }
    };

    return ConfigureApp;

});