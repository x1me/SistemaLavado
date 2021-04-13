$(function () {
    peticion("/MantenimientoTipoDeVehiculos/listar", crearTabla);
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
    $("#Lista").kendoGrid({
        dataSource: datos,
        height: 500,
        filterable: true,
        pageSize: 20,
        groupable: true,
        sortable: true,
        editable: "inline",
        toolbar: ["search"],
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5,
        },
        columns: [
            {
                field: "id_codigoTV",
                title: " ID Producto"
            },
            {
                field: "codigo",
                title: " Código"
            },
            {
                field: "tipo",
                title: "Tipo"
            },
            { command: "edit", title: "Editar", width: "250px" },
            { command: "destroy", title: "Eliminar", width: "250px" }
        ],
        dataSource: {
            transport: {
                read: {
                    url: "/MantenimientoTipoDeVehiculos/listar",
                },
                update: {
                    url: "/MantenimientoTipoDeVehiculos/ModificarTipoVehiculo",
                    type: "POST",
                },
                destroy: {
                    url: "/MantenimientoTipoDeVehiculos/EliminarTipoVehiculo",

                },
            },
            schema: {
                model: {
                    id: "id_codigoTV",
                    fields: {
                        id_codigoTV: { editable: false, nullable: true },
                        codigo: { type: "number", validation: { required: true, min: 1, max: 1000 } },
                        tipo: { validation: { required: true, minlength: 1, maxlength: 30 } }
                    }
                }
            }
        },

        save: function () {
            this.refresh();
        }
    })
}
