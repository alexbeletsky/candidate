define(function (require) {

    // base view
    var BaseView = require('../../../shared/BaseView');

    var DeploymentsView = BaseView.extend({

        template: function () {
            return '<h1>Deployments</h1><p>Overview information is here</p>';
        }

    });

    return DeploymentsView;
});