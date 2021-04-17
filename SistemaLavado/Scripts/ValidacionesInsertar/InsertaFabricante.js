//document on ready
$(function () {
    creaValidaciones();
});

function creaValidaciones() {
    $("#frmInserta").validate({
        rules: {
            codigo: {
                required: true,
                number: true
            },
            pais: {
                required: true,
                minlength: 3,
                maxlength: 60
            }
        }
    });
}