$(document).on("click", ".checkboxswitch", function () {
    if (!($('.checkboxswitch')[0].checked)) {
        $('.checkboxswitch')[0].value = false;
    } else {
        $('.checkboxswitch')[0].value = true;

    }
});