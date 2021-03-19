///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmFabricante").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            codigo: {
                required: true,
                number:true,
                min: 1,
                max: 600
            },
            pais: {
                required: true
            },
        }
    });
}
