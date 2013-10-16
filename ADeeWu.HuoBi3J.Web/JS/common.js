(function ($) {
    $.fn.extend($.fn,{
        ReduceImage: function (setting) {
            var ps = $.extend({
                window: 'attentionDialog'
            }, setting);
                
            $(this).each(function (index) {
                var src = $(this).attr('src');
                var $this = $(this);
                $this.css('height', '16px').wrap(function () {
                    return '<a href="' + $this.attr('src') + '">' + $this.html() + '</a>';
                });

                $this.parent().fancybox();
            })
        }
    })
})(jQuery);
$(function () {
    $('.button').button();
    $('.IsLogin').click(function () {
        var postKey = $('.PostKey');
        if (postKey.css('display') == 'none') {
            if ($.IsLogin()) {
                postKey.dialog({ title: '添加商圈', modal: true });
            } else {
                location.href = '/Login.aspx?url='+document.location.href;
            }
        } else {
            postKey.hide();
        }
        return false;
    })

        var inform = $('input[name=inform]:hidden');
        if (inform.length > 0) {
            var uid = inform.val();
            var kid = inform.attr('kid');

            if (uid == '' || kid == '') {
                $('.inform').hide();
            }

            $.getJSON('/ajax/center.ashx', { method: "ismykey", kid: kid, uid: uid }, function (data) {
                if (data != '' && data.statue) {
                    $('.inform').show();
                } else {
                    $('.inform').hide();
                }
            });
        } else {
            $('.inform').hide();
        }

    //举报
    $('.inform').click(function () {
        var $this = $(this);
        var id = $this.attr('contentid');
        var typeid = $this.attr('typeid');

        if (id == undefined || typeid == undefined) {
            alert('参数有误!');
        }

        $.getJSON('/ajax/center.ashx', { method: "addinform", id: id, typeid: typeid }, function (data) {
            if (data != '' && data.statue) {
                alert('举报成功！');
                return false;
            } else {
                if (data.msg == undefined)
                    alert('提交出现错误！');
                else
                    alert(data.msg);
                return false;
            }
        });
        return false;
    })
})


/**
 * 页面初始化
 */

$(function () {
    /*左边栏*/
    $('.title_short .btn_close').click(function () {
        if ($(this).hasClass('btn_open')) {
            $(this).removeClass('btn_open');
            $(this).parent().next().slideDown();
        } else {
            $(this).addClass('btn_open');
            $(this).parent().next().slideUp();
        }
    });

    /*悬浮窗*/
    $('#horizon_menu > div').hover(
		function () {
		    $(this).find('.module_first').show().find('ul > li').hover(
				function () {
				    $(this).find('.module_second').show().find('dl dd > ul > li').hover(
						function (e) {
						    var position = $(this).find('a:first-child').offset();
						    var _position = $(this).parent().parent().parent().parent().offset();
						    var third = $(this).find('.module_third');
						    third.css('top', position.top - _position.top + $(this).find('a:first-child').height());
						    third.css('left', position.left - _position.left);
						    third.show();
						    $(this).css('zIndex', '20');
						},
						function () {
						    $(this).find('.module_third').hide();
						    $(this).css('zIndex', '10');
						}
					);
				    $('.search select').hide();
				},
				function () {
				    $(this).find('.module_second').hide();
				    $('.search select').show();
				}
			);
		},
		function () {
		    $(this).find('.module_first').hide();
		}
	);

    $('.side_menu2 > li').hover(
		function () {
		    $(this).find('.module_third').show();
		},
		function () {
		    $(this).find('.module_third').hide();
		}
	);

});