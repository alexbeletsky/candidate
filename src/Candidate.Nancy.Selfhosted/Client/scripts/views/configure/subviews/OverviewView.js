define(['../../../shared/BaseView'],
    function (BaseView) {

    var OverviewView = BaseView.extend({

        template: function () {
            return '<h1>Overview</h1><p>Overview information is here</p>';
        }

    });

    return OverviewView;
});