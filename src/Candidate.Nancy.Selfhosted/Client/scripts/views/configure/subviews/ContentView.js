define(function (require) {

    // base view
    var BaseView = require('../../../shared/BaseView');

    // subviews
    var OverviewView = require('./OverviewView');
    var ConfigurationView = require('./ConfigurationView');
    var DeploymentsView = require('./DeploymentsView');
    var HistoryView = require('./HistoryView');

    var ContentView = BaseView.extend({
        className: 'span9',

        initialize: function (options) {
            if (!(options && options.mediator)) {
                throw 'ContentView: mediator is required';
            }

            _.bindAll(this);

            this.mediator = options.mediator;

            // events
            this.bindTo(this.mediator, 'configure:switchView:overview', this.switchToOverview);
            this.bindTo(this.mediator, 'configure:switchView:configuration', this.switchToConfiguration);
            this.bindTo(this.mediator, 'configure:switchView:deployments', this.switchToDeployments);
            this.bindTo(this.mediator, 'configure:switchView:history', this.switchToHistory);
        },

        switchToOverview: function () {
            this.closeSubviews();
            var view = new OverviewView();
            this.appendSubview(view.render());
        },

        switchToConfiguration: function() {
            this.closeSubviews();
            var view = new ConfigurationView();
            this.appendSubview(view.render());
        },

        switchToDeployments: function () {
            this.closeSubviews();
            var view = new DeploymentsView();
            this.appendSubview(view.render());
        },

        switchToHistory: function () {
            this.closeSubviews();
            var view = new HistoryView();
            this.appendSubview(view.render());
        },

        onRender: function () {
            this.mediator.trigger('configure:content:ready');
        }

    });

    return ContentView;
});