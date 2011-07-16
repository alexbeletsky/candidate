/// <reference path="../jquery-1.4.4-vsdoc.js" />
/// <reference path="../jquery.blockUI.js" />
/// <reference path="../jquery-ui.js" />
/// <reference path="../jquery.form.js" />

$(function () {

    var Configure = function () {

        var dialogShown = false;
        $('.dialog').hide();

        $('.configuration-box').live('click', function () {

            var source = $(this).data('source');
            $('.dialog').load(source, function () {

                showDialog(this);
                $(this).find('form').ajaxForm(function () {
                    closeDialog();
                });
            });

        });

        // helpers
        function showDialog(d) {
            dialogShown = true;
            $.blockUI({ message: $(d), css: { width: '640px', padding: '0 0 8px 0' } });
        }

        function closeDialog() {
            if (dialogShown) {
                $.unblockUI();
            }
        }

        // global key handers
        $(document).keyup(function (e) {

            if (e.keyCode == 27) {
                closeDialog();
            }
        });
    } ();
});