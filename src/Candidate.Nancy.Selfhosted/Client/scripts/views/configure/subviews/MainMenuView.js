define(['Hogan', '../../../shared/BaseView', 'text!/scripts/templates/configure/mainMenu.html'],
    function (Hogan, BaseView, template) {

    var MainMenuView = BaseView.extend({
        className: 'span3',

        initialize: function (options) {
            if (!(options && options.id)) {
                throw 'Configure.MainMenu: id is required';
            }

            this.id = options.id;
        },

        template: function (context) {
            return Hogan.compile(template).render(context);
        },

        templateContext: function () {
            return { id: this.id };
        }

    });

    return MainMenuView;
});