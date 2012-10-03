define(['../../../shared/BaseView'],
    function (BaseView) {

    var HistoryView = BaseView.extend({

        template: function () {
            return '<h1>History</h1><p>Overview information is here</p>';
        }

    });

    return HistoryView;
});