/// <reference path="../jquery-1.4.4-vsdoc.js" />

$(function () {

    var Run = function () {

        var setup = $('#setup');
        var startSetupMethod = setup.data('start-setup');

        $.ajax({
            url: startSetupMethod,
            type: 'GET',
            processData: false,
            cache: false,
            contentType: 'application/json; charset=utf-8',
            success: function (r) {
                if (r.success) {
                    setupStarted(r.setupInitInfo)
                }
            }
        });

        function setupStarted(setupInitInfo) {
            if (!setupInitInfo.isRepoCloned) {
                updateConsole('Cloning repository...');
            }
        }

        function updateConsole(line) {
            var currentConsoleContent = $('#run-console-log').html();
            currentConsoleContent += line;
            $('#run-console-log').html(currentConsoleContent);
        }


    } ();

});