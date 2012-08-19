define(function (require) {

    var BaseView = require('../../shared/BaseView');

    var _template = require('text!/scripts/templates/dashboard/addNewSiteModalView.html');

    var AddNewSiteModalView = BaseView.extend({

        initialize: function (options) {
            if (!(options && options.collection)) {
                throw 'AddNewSiteModalView: collection is required';
            }

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

            var name = this.$('#name').val();
            var description = this.$('#description').val();

            this.model.set({ name: name, description: description});
            this.model.save(null, { success: function (saved) {
                me.collection.add(saved);
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