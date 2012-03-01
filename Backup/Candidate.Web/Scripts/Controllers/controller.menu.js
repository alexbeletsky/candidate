/// <reference path="../jquery-1.4.4-vsdoc.js" />
/// <reference path="../Controls/dialog.js" />


$(function () {

    var Menu = function () {

        $('#account').live('click', function (e) {
            var url = $(this).find('a').attr('href');
            var dialog = new Dialog(url);
            dialog.show();

            e.preventDefault();
        });

    } ();

});