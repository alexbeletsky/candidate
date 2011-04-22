/// <reference path="../jquery-1.4.4-vsdoc.js" />

$(function () {

    var Run = function () {

        var method = $('#run-batch').attr('method');
        var callback = function (r) {
            alert(r.success);
        };

        var data = { jobName: $('#job-name').val() };
        $.ajax({
            url: method,
            type: 'POST',
            processData: false,
            cache: false,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            dataType: 'json',
            success: function (result) {
                callback(result);
            }
        });

    } ();

});
