$(function () {

    var Dashboard = function () {

        $('.loader').hide();

        $('#add-job').live('click', function () {
            $('html, body').css('cursor', 'progress');
            $('.loader').show();

            $('#action-content').slideUp().load('/dashboard/add', function () {
                $(this).slideDown(function () {
                    $('html, body').animate({ scrollTop: $('#action-content').offset().top }, 700);
                    $(this).find('#FirstName').focus();
                    $('html, body').css('cursor', 'auto');
                    $('.loader').hide();
                });
            });
        });



    } ();

});