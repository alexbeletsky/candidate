define(function (require) {

    // base view
    var BaseView = require('../../../shared/BaseView');

    var OverviewView = BaseView.extend({

        template: function () {
            return '<h1>Overview</h1><p>Overview information is here</p>';
        }

    });

    return OverviewView;
});