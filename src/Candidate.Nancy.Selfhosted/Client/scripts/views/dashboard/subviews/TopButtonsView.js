define(['../../../shared/BaseView', './AddNewSiteModalView', '../../../models/Site', 'text!/scripts/templates/dashboard/topButtons.html'],
    function (BaseView, AddNewSiteModalView, Site, template) {

    var TopButtonsView = BaseView.extend({
        initialize: function (options) {
            if (!(options && options.collection)) {
                throw 'TopButtonsView: collection is required';
            }

            this.collection = options.collection;
        },

        template: function () {
            return template;
        },

        events: {
            'click a.addSite': 'onAddSiteClick'
        },

        onAddSiteClick: function (e) {
            e.preventDefault();

            var model = new Site();
            var addNewSiteModalView = new AddNewSiteModalView( { model: model, collection: this.collection });
            addNewSiteModalView.render();
        }
    });

    return TopButtonsView;

});