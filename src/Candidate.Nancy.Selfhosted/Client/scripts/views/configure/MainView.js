define(function (require) {

    // base view
    var BaseView = require('../../shared/BaseView');

    // sub-views
    var MainMenuView = require('./subviews/MainMenuView');
    var ContentView = require('./subviews/ContentView');

    var ConfigureView = BaseView.extend({
        className: 'row',

        initialize: function (options) {
            if (!options && !options.section) {
                throw 'Configure.MainView: section name is requred';
            }

            this.section = options.section;
        },

        onRender: function () {
            var leftSideMainMenu = new MainMenuView({ section: this.section });
            this.appendSubview(leftSideMainMenu.render());

            var sideContent = new ContentView({ section: this.section });
            this.appendSubview(sideContent.render());
        }
    });

    return ConfigureView;
});