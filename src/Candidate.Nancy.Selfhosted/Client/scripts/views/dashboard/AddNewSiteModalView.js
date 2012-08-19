define(function (require) {

    var BaseView = require('../../shared/BaseView');

    var _template = require('text!/scripts/templates/dashboard/addNewSiteModalView.html');

    var AddNewSiteModalView = BaseView.extend({

        initialize: function (options) {
            if (!(options && options.collection)) {
                throw 'AddNewSiteModalView: collection is required';
            }

            _.bindAll(this);

            this.bindTo(this.model, 'error', this.onModelError);
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

        onSave: function (e) {
            var me = this;

            var name = this.$('#name').val();
            var description = this.$('#description').val();

            this.model.save({ name: name, description: description}, {
                success: function (saved) {
                    me.collection.add(saved);
                    me.onClose();
                }
            });

            e.preventDefault();
        },

        onClose: function () {
            this.$el.modal('hide');
        },

        onModelError: function(model, error) {
            this.$('#' + error.field).closest('.control-group').addClass('error');
            this.$('#' + error.field).closest('.help-block').text(error.message);
        }

    });

    return AddNewSiteModalView;

});