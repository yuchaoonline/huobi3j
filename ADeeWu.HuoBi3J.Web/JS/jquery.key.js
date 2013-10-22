(function ($) {
    $.fn.enter = $.fn.enter || function (obj) {
        $(this).keyup(function (e) {
            if (13 == e.which) {
                obj.click();
            }
        })
    }
})(jQuery);