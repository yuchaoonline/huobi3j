$(function () {
    $('body').everyTime('120s', 'attentionCount', function () {
        if($.IsLogin())
    })
})