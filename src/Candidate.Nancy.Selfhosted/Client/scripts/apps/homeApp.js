define(function (require) {
    
    var HomeView = require('../views/homeView');

    var HomeApp = {
        run: function (viewManager) {
            viewManager.show(new HomeView());
        }
    }

    return HomeApp;

});