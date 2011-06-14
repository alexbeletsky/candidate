/// <reference path="../jquery-1.4.4-vsdoc.js" />

$(function () {

    var Dashboard = function () {

        $('.loader').hide();

        $('#add-job').live('click', function () {
            $('html, body').css('cursor', 'progress');
            $('.loader').show();

            var method = $(this).attr('method');
            $('#action-content').slideUp().load(method, function () {
                $(this).slideDown(function () {
                    $('html, body').animate({ scrollTop: $('#action-content').offset().top }, 700);
                    $(this).find('#FirstName').focus();
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
    } ();
});