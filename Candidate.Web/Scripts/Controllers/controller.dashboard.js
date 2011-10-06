/// <reference path="../jquery-1.4.4-vsdoc.js" />

$(function () {

    var Dashboard = function () {

        $('.loader').hide();

        (function addNewJobFunction() {
            $('#add-job-button').live('click', function () {
                $('html, body').css('cursor', 'progress');
                $('.loader').show();

                var method = $(this).data('method');
                $('#action-content').slideUp().load(method, function () {
                    $(this).slideDown(function () {
                        $('html, body').animate({ scrollTop: $('#action-content').offset().top }, 700);
                        $(this).find('#Name').focus();
                        $('html, body').css('cursor', 'auto');
                        $('.loader').hide();
                    });
                });

                return false;
            });

            $('#close-button').live('click', function () {
                $('#action-content').slideUp(function () {
                    $(this).empty();
                });

                return false;
            });

            $('#add-job input').live('keyup', function (e) {
                if (e.keyCode == 13) {
                    $('#add-job button[type=submit]').click();
                    e.preventDefault();
                }
            });

        })();

        (function temporaryPasswordReminderTooltip() {
            var temporaryPassword = $('#temporaryPassword').val();
            if (temporaryPassword === "True") {
                $('li#account').after('<div class="tooltip"><strong>Please create own user</strong>. You are now using account with temporary password, consider to change it as soon as possible.</div>');
                setTimeout(function () {
                    $('.tooltip').fadeOut(2000, function () {
                        $(this).empty();
                    });
                }, 7000);
            }
        })();


        (function sitesButtons() {
            $('#buttons button').live('click', function () {
                window.location = $(this).data('target');
            });
        })();

    } ();
});