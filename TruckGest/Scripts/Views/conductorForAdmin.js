$(document).on("click", ".btnEditModal", function () {
    $('#modalEditConductor').modal('show')
    $('#modalContentUpdateCon').load("/Administrador/EditModalConductor?id=" + $(this).find("input")[0].value)
});