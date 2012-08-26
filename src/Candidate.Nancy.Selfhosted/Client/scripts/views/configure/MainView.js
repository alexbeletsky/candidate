define(function (require) {

    // base view
    var BaseView = require('../../shared/BaseView');

    // sub-views
    var MainMenu = require('./subviews/MainMenuView');
    //var SideContent = require('./subviews/Content');

    var ConfigureView = BaseView.extend({
        className: 'row',

        onRender: function () {
            var leftSideMainMenu = new MainMenu();
            this.appendSubview(leftSideMainMenu.render());

            // var sideContent = new SideContent();
            // this.appendSubview(sideContent.render());
        }
    });

    return ConfigureView;
});