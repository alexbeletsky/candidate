define(['../../../shared/BaseView'],
    function (BaseView) {

    var DeploymentsView = BaseView.extend({

        template: function () {
            return '<h1>Deployments</h1><p>Overview information is here</p>';
        }

    });

    return DeploymentsView;
});