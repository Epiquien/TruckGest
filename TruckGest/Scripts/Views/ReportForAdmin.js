$(document).on("click", ".btnDeleted", function () {
    $('#confirmDelete').modal('show');
    $('#inputId')[0].value = $(this).find("input")[0].value;
    $('#idReport')[0].innerText = 'Reporte ' + $(this).find("input")[0].value;
});