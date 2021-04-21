$(function () {
    peticion("/Clientes/listar", crearTabla);
})

function peticion(url, callback = null, metodo = "get", dataType = "json", datos = null) {
    ///invocar al método
    $.ajax({
        url: url,///dirección del método
        method: metodo,
        dataType: dataType,
        ///formato en el que se envían y reciben los datos
        data: datos,///parámetros convertidos en formato JSON
        ///función que se ejecuta cuando la respuesta fue satisfactoria
        ///data: contiene el valor retornado por el método del servidor
    }).done(function (response) {
        callback(response);
    }).fail(function (response) {
        console.log("fail");
    });
}


function crearTabla(datos) {
    console.log($("ok"));
    $("#ListaKendo").kendoGrid({
        dataSource: datos,
        height: 500,
        filterable: true,
        pageSize: 10,
        groupable: true,
        sortable: true,
        editable: "inline",
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5,
        },
        columns: [
            {
                field: "id_cliente",
                title: "Cliente ID"
            },
            {
                field: "nombre",
                title: "Nombre "
            },
            {
                field: "apellido1",
                title: "Primer Apellido"
            },
            {
                field: "apellido2",
                title: "Segundo Apellido"
            },
            {
                field: "cedula",
                title: "Cédula",
            },
            {
                field: "fecha_nacimiento",
                title: "Fecha Nacimiento",
            },
            {
                field: "genero",
                title: "Género",
            },
            {
                field: "provincia",
                title: "Provincia",
            }
            ,
            {
                field: "canton",
                title: "Cantón",
            }
            ,
            {
                field: "distrito",
                title: "Distrito",
            },
            {
                field: "estado",
                title: "Estado",
            },

            {
                command: ["edit", "destroy"]
            },

        ],
        dataSource: {
            transport: {
                read: {
                    url: "/Clientes/listar"
                },
                update: {
                    url: "/Clientes/agregar",
                    type: "post",
                    dataType: "json",
                },
                destroy: {
                    url: "/Clientes/eliminar",
                    dataType: "json",
                },
                requestEnd: function (e) {
                    if ((e.type == "update" || e.type == "destroy") && e.response) {
                        $("#ListaKendo").data("kendoGrid").dataSource.read();
                        $("#ListaKendo").data("kendoGrid").refresh();
                        alert(e.response);
                    }
                },
            },
            schema: {
                model: {
                    id: "id_cliente",
                    fields: {
                        id_cliente: { editable: false, nullable: true },
                        cedula: { type: "number", validation: { required: true, min: 1, max: 1000, } },
                        genero: { validation: { required: true } },
                        nombre: { validation: { required: true, minlength: 1, maxlength: 30 } },
                        correo: { email: { requered: true, minlength: 5, maxlength: 50}},
                        provincia: { validation: { required: true } },
                        canton: { validation: { required: true } },
                        distrito: { validation: { required: true } },
                        fecha_nacimiento: { type: "date", validation: { required: true, min: 1, max: 1000, } },
                        apellido1: { validation: { required: true, minlength: 1, maxlength: 30 } },
                        apellido2: { validation: { required: true, minlength: 1, maxlength: 30 } },
                        estado: { validation: { required: true } },

                    }
                }
            }

        }
    });
}
