define(function (require) {

    var BaseView = require('../../shared/BaseView');

    var _template = require('text!/scripts/templates/dashboard/addNewSiteModalView.html');

    var AddNewSiteModalView = BaseView.extend({

        initialize: function () {
            _.bindAll(this);
        },

        events: {
            'click .save': 'onSave'
        },

        template: function () {
            return _template;
        },

        onRender: function () {
            this.$el.modal({ backdrop: 'static' });
        },

        onSave: function () {
            var me = this;

            var name = this.$('#site-name').val();
            var description = this.$('#description').val();

            this.model.set({ name: name, description: description});
            this.model.save({ success: function () {
                me.onClose();
            }});
        },

        onClose: function () {
            this.$el.modal('hide');
            this.close();
        }

    });

    return AddNewSiteModalView;

});