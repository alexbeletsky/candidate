/// <reference path="../jquery-1.4.4-vsdoc.js" />

$(function () {

    var Run = function () {

        var setup = $('#setup');
        var startSetupMethod = setup.data('start-setup');
        var cloneRepositoryMethod = setup.data('clone-repo');

        startSetup();

        function startSetup() {

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
        }

        function setupStarted(setupInitInfo) {
            if (!setupInitInfo.isRepoCloned) {

                startRepositoryClone();
            }
        }

        function startRepositoryClone() {
            updateConsole('Cloning repository...');

            cloneRepository();
        }

        function cloneRepository() {
            $.ajax({
                url: cloneRepositoryMethod,
                type: 'POST',
                processData: false,
                cache: false,
                contentType: 'application/json; charset=utf-8',
                success: function (r) {
                    if (r.success) {
                        readLogAndUpdateConsole(r.logId)
                    }
                }
            });
        }

        function readLogAndUpdateConsole(logId) {

            var readLogMethod = runBuild.data('read-log');
            var readLog = function (offset) {

                $.ajax({
                    url: readLogMethod,
                    type: 'GET',
                    data: { logId: logId, offset: offset },
                    contentType: 'application/json; charset=utf-8',
                    success: function (r) {
                        if (r.success) {
                            updateConsole(r.line);
                            if (!r.eof) {
                                var updatedOffset = offset + r.count;
                                readLog(updatedOffset);
                            }
                        }
                    }
                });
            }

            readLog(0);
        }


        function updateConsole(line) {
            var currentConsoleContent = $('#run-console-log').html();
            currentConsoleContent += line;
            $('#run-console-log').html(currentConsoleContent);
        }


    } ();

});