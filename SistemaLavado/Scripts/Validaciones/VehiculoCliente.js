$(function () {
    crearTabla();
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
                field: "codigoCliente",
                title: " Cliente"
            },
            {
                field: "codigoVehiculo",
                title: " Placa"
            },
            {
                command: ["edit", "destroy"]
            },
        ],
        dataSource: {
            transport: {
                read: {
                    url: "/ClienteVE/listar",
                },
                update: {
                    url: "/ClienteVE/agregaroeditar",
                    type: "post",
                    dataType: "json",
                },
                destroy: {
                    url: "/ClienteVE/Elimina",

                },
            },
            requestEnd: function (e) {
                if ((e.type == "update" || e.type == "destroy") && e.response) {
                    $("#Lista").data("kendoGrid").dataSource.read();
                    $("#Lista").data("kendoGrid").refresh();
                    alert(e.response);
                }
            },
            schema: {
                model: {
                    id: "codigoCliente",
                    ud: "codigoVehiculo",
                    fields: {
                        codigoCliente: { editable: false, nullable: true },
                        codigoVehiculo: { validation: { required: true, min: 1, max: 1000 } },
                    }
                }
            }
        },
    })
}
