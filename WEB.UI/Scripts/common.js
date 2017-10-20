//全选
var CheckAll = function (checkbtn, root) {
    $(checkbtn).click(function () {
        if ($(this).is(':checked')) {
            $(root + ' :checkbox').prop('checked', true);
        }
        else {
            $(root + ' :checkbox').prop('checked', false);
        }
    })
    console.log('a');
}

