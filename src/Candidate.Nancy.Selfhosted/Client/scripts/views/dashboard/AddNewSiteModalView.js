define(function (require) {

    var BaseView = require('../../shared/BaseView');

    var _template = require('text!/scripts/templates/dashboard/addNewSiteModalView.html');

    var AddNewSiteModalView = BaseView.extend({

        template: function () {
            return _template;
        },

        onRender: function () {
            this.$el.modal({ backdrop: 'static' });
        }

    });

    return AddNewSiteModalView;

});