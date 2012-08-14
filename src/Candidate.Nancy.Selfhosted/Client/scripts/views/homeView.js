define(function (require) {
    var Backbone = require('Backbone');
    var _ = require('Underscore');

    var template = require('text!/views/home/home.html');

    var HomeView = Backbone.View.extend({
        template: _.template(template),

        render: function () {
            var content = this.template();
            this.$el.html(content);

            return this;
        }
    });

    return HomeView;
});