//全选
var CheckAll = function (checkbtn, root) {
    return $(checkbtn).click(function () {
        if ($(this).is(':checked')) {
            $(root + ' :checkbox').prop('checked', true);
        }
        else {
            $(root + ' :checkbox').prop('checked', false);
        }
    })
    
}
$(function () {
    console.log('a');
})

