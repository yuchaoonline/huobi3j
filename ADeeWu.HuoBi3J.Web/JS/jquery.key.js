(function ($) {
    $.fn.enter = $.fn.enter || function (obj, callback) {
        $(this).keydown(function (e) {
            if (13 == e.which) {
                callback();
                return false;
            }
        })
    }
})(jQuery);