define(['../../shared/BaseView', './subviews/MainMenuView', './subviews/ContentView'],
    function (BaseView, MainMenuView, ContentView) {

    var ConfigureView = BaseView.extend({
        className: 'row',

        initialize: function (options) {
            if (!(options && options.section && options.id)) {
                throw 'Configure.MainView: section name and id requred';
            }

            this.id = options.id;
            this.section = options.section;
        },

        onRender: function () {
            var leftSideMainMenu = new MainMenuView({ id: this.id, section: this.section });
            this.appendSubview(leftSideMainMenu.render());

            var sideContent = new ContentView({ section: this.section });
            this.appendSubview(sideContent.render());
        }
    });

    return ConfigureView;
});