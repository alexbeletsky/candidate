define(function (require) {

    // views
    var BaseView = require('../../../shared/BaseView');

    var MainMenuView = BaseView.extend({
        className: 'span3',

        initialize: function (options) {
            if (!(options && options.mediator)) {
                throw 'MainMenuView: mediator is required';
            }

            _.bindAll(this);

            this.mediator = options.mediator;

            this.bindTo(this.mediator, 'configure:content:ready', this.onReady);
        },

        template: function () {
            var _template = require('text!/scripts/templates/configure/mainMenu.html');
            return _template;
        },

        onReady: function () {
            this.onOverview();
        },

        events: {
            'click .overview': 'onOverview',
            'click .configuration': 'onConfiguration',
            'click .deployments': 'onDeployments',
            'click .history': 'onHistory'
        },

        onOverview: function (e) {
            e && e.preventDefault();
            this.mediator.trigger('configure:switchView:overview');
        },

        onConfiguration: function (e) {
            e && e.preventDefault();
            this.mediator.trigger('configure:switchView:configuration');
        },

        onDeployments: function (e) {
            e && e.preventDefault();
            this.mediator.trigger('configure:switchView:deployments');
        },

        onHistory: function (e) {
            e && e.preventDefault();
            this.mediator.trigger('configure:switchView:history');
        }

    });

    return MainMenuView;
});