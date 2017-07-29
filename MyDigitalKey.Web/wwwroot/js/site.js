$(function() {
    $('.js-user-item').click(function(e) {
        $(this).parent().find('.details').slideToggle();
    });
});