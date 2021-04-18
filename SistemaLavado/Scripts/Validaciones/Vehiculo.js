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
                field: "id_vehiculo",
                title: " ID Vehículo"
            },
            {
                field: "placa",
                title: "Placa"
            },
            {
                field: "tipo",
                title: "Tipo"
            },
            {
                field: "marca",
                title: "Marca"
            },
            {
                field: "numeroPuertas",
                title: "Cantidad Puertas"
            },
            {
                field: "numeroRuedas",
                title: "Cantidad Ruedas"
            },
            {
                command: ["edit", "destroy"]
            },
        ],
        dataSource: {
            transport: {
                read: {
                    url: "/Vehiculos/listar",
                },
                update: {
                    url: "/Vehiculos/agregaroeditar",
                    type: "post",
                    dataType: "json",
                },
                destroy: {
                    url: "/Vehiculos/Elimina",

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
                    id: "id_vehiculo",
                    fields: {
                        id_vehiculo: { editable: false, nullable: true },
                        placa: { validation: { required: true, minlength: 1, maxlength: 30 } },
                        tipo: { validation: { required: true, minlength: 1, maxlength: 30 } },
                        marca: { validation: { required: true, minlength: 1, maxlength: 30 } },
                        numeroPuertas: { type: "number", validation: { required: true, min: 1, max: 1000 } },
                        numeroRuedas: { type: "number", validation: { required: true, min: 1, max: 1000 } }
                    }
                }
            }
        },
    })
}
