define(function (require) {

    // base view
    var BaseView = require('../../shared/BaseView');

    // sub-views
    var MainMenuView = require('./subviews/MainMenuView');
    var ContentView = require('./subviews/ContentView');

    // mediator
    var Mediator = require('../../components/Mediator');

    var ConfigureView = BaseView.extend({
        className: 'row',

        initialize: function () {
            this.mediator = new Mediator();
        },

        onRender: function () {
            var leftSideMainMenu = new MainMenuView({ mediator: this.mediator });
            this.appendSubview(leftSideMainMenu.render());

            var sideContent = new ContentView({ mediator: this.mediator });
            this.appendSubview(sideContent.render());
        }
    });

    return ConfigureView;
});