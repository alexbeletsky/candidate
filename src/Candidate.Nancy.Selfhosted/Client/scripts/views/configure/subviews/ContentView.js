define(['../../../shared/BaseView', './OverviewView', './ConfigurationView', './DeploymentsView', './HistoryView' ],
    function (BaseView, OverviewView, ConfigurationView, DeploymentsView, HistoryView) {

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