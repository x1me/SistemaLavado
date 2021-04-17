//document on ready
$(function () {
    creaValidaciones();
});

function creaValidaciones() {
    $("#frmTipoInserta").validate({
        rules: {
            codigo: {
                required: true,
                number: true
            },
            tipo: {
                required: true,
                minlength: 3,
                maxlength: 60
            }
        }
    });
}