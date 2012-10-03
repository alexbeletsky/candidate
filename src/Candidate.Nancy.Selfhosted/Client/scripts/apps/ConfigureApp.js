define(['../views/configure/MainView', '../models/Site'],
    function (MainView, Site) {

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
                var view = new MainView({ model: site, id: context.id, section: context.section || 'overview' });
                viewManager.show(view);
            });
        }
    };

    return ConfigureApp;

});