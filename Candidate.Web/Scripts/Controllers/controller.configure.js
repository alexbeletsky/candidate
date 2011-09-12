/// <reference path="../jquery-1.4.4-vsdoc.js" />
/// <reference path="../jquery.blockUI.js" />
/// <reference path="../jquery-ui.js" />
/// <reference path="../jquery.form.js" />
/// <reference path="../Controls/dialog.js" />

$(function () {

    var Configure = function () {
        $('.configuration-box').live('click', function () {
            var dialog = new Dialog($(this).data('source'));
            dialog.show();

        });
    } ();
});