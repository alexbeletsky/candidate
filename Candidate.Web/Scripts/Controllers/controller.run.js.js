/// <reference path="../jquery-1.4.4-vsdoc.js" />

$(function () {

    var Run = function () {

        var runBuild = $('#run-batch');
        var runBuildMethod = runBuild.data('run-build');

        $.ajax({
            url: runBuildMethod,
            type: 'POST',
            processData: false,
            cache: false,
            contentType: 'application/json; charset=utf-8',
            success: function (r) {
                if (r.success) {
                    jobStarted(r.log)
                }
            }
        });

        function jobStarted(logId) {

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
