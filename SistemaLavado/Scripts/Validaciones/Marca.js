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

    $("#Lista").kendoGrid({
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
                field: "id_codigoMarcaV",
                title: " ID Producto"
            },
            {
                field: "codigo",
                title: " Código"
            },
            {
                field: "tipo",
                title: "tipo",  
                editor: tipos, 
                template: "#=tipo#"
            },
            {
                field: "fabricante",
                title: "Fabricante"
            },
            {
                field: "nombre_marca",
                title: "Nombre marca"
            },
            {
                command: ["edit", "destroy"]
            },
        ],
        dataSource: {
            transport: {
                read: {
                    url: "/MarcasDeVehiculo/listar",
                },
                update: {
                    url: "/MarcasDeVehiculo/agregaroeditar",
                    type: "post",
                    dataType: "json",
                },
                destroy: {
                    url: "/MarcasDeVehiculo/Elimina",

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
                    id: "id_codigoMarcaV",
                    fields: {
                        id_codigoMarcaV: { editable: false, nullable: true },
                        codigo: { type: "number", validation: { required: true, min: 1, max: 1000 } },
                        fabricante: { validation: { required: true, minlength: 1, maxlength: 30 } }
                    }
                }
            },
        }
    })
}

function tipos(container, op) {
    console.table(op);
    $(`<input required name='${op.field}' />`)
        .appendTo(container)
        .kendoDropDownList({
            dataTextField: "tipo",
            dataValueField: "id_codigoTV",
            dataSource: {
                type: "json",
                transport: {
                    read: "/MarcasDeVehiculo/RetornaTipos",
                }
            }
        });
}