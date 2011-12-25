/// <reference path="../jquery-1.4.4-vsdoc.js" />

$(function () {

    var Run = function () {
        // Global config
        $.blockUI.defaults.message = null;

        var setup = $('#setup');
        var startSetupMethod = setup.data('start-setup');
        var showLogMethod = setup.data('show-log');

        start();

        function start() {
            $.blockUI();

            $('#current-step').html('Application deployment, please wait...');
            startSetup();
        }

        function startSetup() {
            $.ajax({
                url: startSetupMethod,
                type: 'POST',
                processData: false,
                cache: false,
                contentType: 'application/json; charset=utf-8',
                success: function (r) {
                    if (r.success) {
                        finish(r.result);
                    }
                },
                error: function (r) {
                    onError($.parseJSON(r.responseText));
                }
            });

        }

        function finish(result) {
            $('#current-step').html('<span class="success">Application successfully launched!</span>');
            $('#current-step').append('<p><span class="small">Visit your site: <a target="_blank" href="' + result.Url + '">' + result.Url + '</a> Build logs available <a target="_blank" href="' + showLogMethod + '/' + result.Log + '">here</a></span></p>');

            $('.preloader').hide();
            $.unblockUI();
        }

        function onError(r) {
            $('#current-step').html('<span class="error">' + r.message + '</span>');

            $('.preloader').hide();
            $.unblockUI();
        }

    } ();
});