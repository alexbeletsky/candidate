define(function (require) {

    // views
    var BaseView = require('../../../shared/BaseView');

    var MainMenuView = BaseView.extend({
        className: 'span3',

        template: function () {
            var _template = require('text!/scripts/templates/configure/mainMenu.html');
            return _template;
        }

    });

    return MainMenuView;
});