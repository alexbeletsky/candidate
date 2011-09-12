/// <reference path="../jquery-1.4.4-vsdoc.js" />
/// <reference path="../jquery.blockUI.js" />
/// <reference path="../jquery-ui.js" />
/// <reference path="../jquery.form.js" />
/// <reference path="../jquery.fancybox-1.3.4.js" />

function Dialog(url) {
    this.url = url;
}

Dialog.prototype = (function () {

    return {
        show: function () {
            var me = this;

            $.fancybox({
                modal: true,
                href: this.url,
                onComplete: function () {
                    $('.dialog input:first').focus();
                    $('.dialog form').ajaxForm(function () {
                        me.close();
                    });
                    $('.dialog button[id="close"]').click(function () {
                        me.close();
                    });
                    $('.dialog').bind('keyup', function (e) {
                        if (e.keyCode == 27) {
                            me.close();
                        }
                    });
                }
            });
        },

        close: function () {
            $.fancybox.close();
        }
    };
})();