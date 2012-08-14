define(function (require) {

    var Backbone = require('Backbone');
    var ApplicationRouter = Backbone.Router.extend({
        initialize: function () {

        },

        routes: {
            '': 'home',
            'account': 'account'
        },

        home: function () {
            alert('home');
        },

        account: function () {
            alert('account');
        }

    });

    return {
        start: function () {
            new ApplicationRouter();
            Backbone.history.start({pushState: true});
        }
    }
});