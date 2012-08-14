define(function () {

    var ViewManager = function () {
        return {
            show: _showView
        };
    }

    function _showView(view) {
        if (this.currentView) {
            this.currentView.dispose();
        }

        this.currentView = view;
        this.currentView.render();

        $("#app").html(this.currentView.el);
    }

    return ViewManager;

});