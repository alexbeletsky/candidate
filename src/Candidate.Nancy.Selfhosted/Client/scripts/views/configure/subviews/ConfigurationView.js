define(['../../../shared/BaseView'],
    function (BaseView) {

    var ConfigurationView = BaseView.extend({

        template: function () {
            return '<h1>Configuration</h1><p>Overview information is here</p>';
        }

    });

    return ConfigurationView;

});