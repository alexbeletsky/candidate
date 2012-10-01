define(function (require) {

    // base view
    var BaseView = require('../../../shared/BaseView');

    // subviews
    var OverviewView = require('./OverviewView');
    var ConfigurationView = require('./ConfigurationView');
    var DeploymentsView = require('./DeploymentsView');
    var HistoryView = require('./HistoryView');

    var Views = {
        'overview': OverviewView,
        'configuration': ConfigurationView,
        'deployments': DeploymentsView,
        'history': HistoryView
    };

    var ContentView = BaseView.extend({
        className: 'span9',

        initialize: function (options) {
            if (!(options && options.section)) {
                throw 'Configuration.ContentView: section is required';
            }

            _.bindAll(this);

            this.section = options.section;
        },

        onRender: function () {
            var view = new Views[this.section]();
            this.appendSubview(view.render());
        }

    });

    return ContentView;
});