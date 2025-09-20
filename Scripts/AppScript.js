$(document).ready(function () {
    var max = 90;
    $(".readMore").each(function () {
        var str = $(this).text();
        if ($.trim(str).length > max) {
            debugger;
            var subStr = str.substring(0, max);
            //var hiddenStr = str.substring(max, $.trim(str).length);
            var hiddenStr = str.substring(max, str.length);
            $(this).empty().html(subStr);
            $(this).append('<a href="javascript:void(0);" class="link">...more</a>');
            $(this).append('<span class="addText d-none">' + hiddenStr + '</span>');
            //console.log(hiddenStr);
            //console.log(str);
        }
    });
    $(".link").click(function () {
        $(this).siblings(".addText").contents().unwrap();
        $(this).remove();
    });
});


//$('.comments p').text(function (_, txt) {
//  if(txt.length > 36){
//    txt = txt.substr(0, 36) + "...";
//    $(this).parent().append("<a href='#'>Read More</a>");
//  }
//  $(this).html(txt)
//});