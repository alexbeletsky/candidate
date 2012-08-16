define(function (require) {
    var Backbone = require('Backbone');
    var Hogan = require('Hogan');
    var _ = require('Underscore');

    var template = require('text!/views/home/home.html');

    var HomeView = Backbone.View.extend({
        template: Hogan.compile(template),

        render: function () {
            var content = this.template.render({ sites: this.model.toJSON() });
            this.$el.html(content);

            return this;
        }
    });

    return HomeView;
});