define(function (require) {

    // base view
    var BaseView = require('../../../shared/BaseView');

    var ConfigurationView = BaseView.extend({

        template: function () {
            return '<h1>Configuration</h1><p>Overview information is here</p>';
        }

    });

    return ConfigurationView;

});