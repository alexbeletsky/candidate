define(function (require) {

    var Backbone = require('Backbone');
    var ViewManager = require('viewManager');
    var Applications = {
        'home': require('./apps/homeApp')
    };

    var ApplicationRouter = Backbone.Router.extend({

        initialize: function () {
            this.viewManager = new ViewManager();
            this.currentApplication = null;
        },

        routes: {
            '': 'home',
            'account': 'account'
        },

        home: function () {
            this.currentApplication = Applications['home'].run(this.viewManager);
        },

        account: function () {
            alert('account');
        }

    });

    return {
        start: function () {
            new ApplicationRouter();
            Backbone.history.start({ pushState: true });
        }
    };
});