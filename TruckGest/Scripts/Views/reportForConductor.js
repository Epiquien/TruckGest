$(document).on("click", ".btnEditModal", function () {
    $('#modalEditReport').modal('show')
    $('#modalContentReport').load("/Conductor/EditModalReport?id=" + $(this).find("input")[0].value)
});