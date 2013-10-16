(function ($) {
    $.extend({
        IsLogin: function (setting) {
            var ps = $.extend({
                url: '/ajax/user.ashx',
                method: 'islogin'
            }, setting);

            $.ajaxSettings.async = false;
            var result = false;
            $.getJSON(ps.url, { method: ps.method }, function (data) {
                if (data != '' && data.Statue) result = true;
            })
            $.ajaxSettings.async = true;
            return result;
        },
        IsSaleMan: function (setting) {
            var ps = $.extend({
                url: '/ajax/user.ashx',
                method: 'issaleman'
            }, setting);

            $.ajaxSettings.async = false;
            var result = false;
            $.getJSON(ps.url, { method: ps.method }, function (data) {
                if (data != '' && data.statue) result = true;
            })
            $.ajaxSettings.async = true;
            return result;
        },
        GetSaleMan: function (setting) {
            var ps = $.extend({
                url: '/ajax/user.ashx',
                method: 'getsaleman',
                uid: -1
            }, setting);

            var result = '';
            $.ajaxSettings.async = false;
            $.getJSON(ps.url, { method: ps.method, uid: ps.uid }, function (data) {
                $.ajaxSettings.async = true;
                if (data != '' && data.statue) {
                    result = data;
                }
            })
            $.ajaxSettings.async = true;

            return result;
        },
        IsQualifiedAgent: function (setting) {
            var ps = $.extend({
                url: '/ajax/user.ashx',
                method: 'isqualifiedagent'
            }, setting);

            $.ajaxSettings.async = false;
            var result = false;
            $.getJSON(ps.url, { method: ps.method }, function (data) {
                if (data != '' && data.statue) result = true;
            })
            $.ajaxSettings.async = true;
            return result;
        },
        GetKeyManageByKID: function (setting) {
            var ps = $.extend({
                url: '/ajax/center.ashx',
                method: 'getkeymanagebykid',
                kid: 0
            }, setting);

            $.ajaxSettings.async = false;
            var result = false;
            $.getJSON(ps.url, { method: ps.method,kid: ps.kid }, function (data) {
                if (data != '' && data.statue) result = data;
            })
            $.ajaxSettings.async = true;
            return result;
        }
    });
})(jQuery);

(function ($) {
    $.fn.extend($.fn,{
        btnLogin: function (setting) {
            var ps = $.extend({
                target: '.PostKey',
                title: 'add',
                returnUrl: '/Login.aspx?url='+document.location.href
            }, setting);

            $(this).click(function(){
                var postKey = $(ps.target);
                if (postKey.css('display') == 'none') {
                    if ($.IsLogin()) {
                        postKey.dialog({ title: ps.title, modal: true });
                    } else {
                        location.href = ps.returnUrl;
                    }
                } else {
                    postKey.hide();
                }
                return false;
            })
        }
    });
})(jQuery);