define(function (require) {
    var Backbone = require('Backbone');

    // https://gist.github.com/2637323
    var BaseView = Backbone.View.extend({

        close: function () {
            this.closeSubviews();
            this.unbindFromAll();
            this.off();
            this.remove();

            if (this.onClose) this.onClose();
        },

        // Events

        bindTo: function (object, e, callback, context) {
            context || (context = this);

            object.on(e, callback, context);

            this.bindings || (this.bindings = []);
            this.bindings.push({ object: object, event: e, callback: callback });
        },

        unbindFromAll: function () {
            var self = this;

            _.each(this.bindings, function (binding) {
                binding.object.off(binding.event, binding.callback, self);
            });
        },

        // Subviews

        eachSubview: function (iterator) {
            _.each(this.subviews, iterator);
        },

        appendSubview: function (view, el) {
            el || (el = this.$el);
            this.subviews || (this.subviews = {});
            this.subviews[view.cid] = view;
            el.append(view.el);
        },

        closeSubviews: function () {
            this.eachSubview(function (subview) {
                subview.close();
            });

            this.subviews = {};
        },

        detachSubview: function (view) {
            if (this.subviews) {
                delete this.subviews[view.cid];
            }

            view.$el.detach();
        },

        // Templates

        templateContext: function () {
            return {};
        },

        layout: function (context, template) {
            this.closeSubviews();
            this.$el.empty();

            template || (template = this.template);

            if (template) {
                context || (context = this.templateContext());
                this.$el.append(template(context));
            }
        },

        render: function () {
            this.layout();
            if (this.onRender) this.onRender();
            return this;
        }

    });

    return BaseView;
});