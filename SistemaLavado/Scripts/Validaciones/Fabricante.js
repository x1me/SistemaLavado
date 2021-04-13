$(function () {
    peticion("/MantenimientoFabricante/listar", crearTabla);
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
    $("#ListaFabricante").kendoGrid({
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
                field: "id_codfabricante",
                title: " Fabricante ID"
            },
            {
                field: "codigo",
                title: " Código"
            },
            {
                field: "pais",
                title: " País"
            },
            { command: "edit", title: "Editar", width: "250px" },
            { command: "destroy", title: "Eliminar", width: "250px" }
        ],
        dataSource: {
            transport: {
                read: {
                    url: "/MantenimientoFabricante/listar",
                },
                update: {
                    url: "/MantenimientoFabricante/agregaroeditar",
                    type: "POST",
                },
                destroy: {
                    url: "/MantenimientoFabricante/EliminaFabricante",
                    
                },
            },
            schema: {
                model: {
                    id: "id_codfabricante",
                    fields: {
                        id_codfabricante: { editable: false, nullable: true },
                        codigo: { type: "number", validation: { required: true, min: 1, max: 1000 } },
                        pais: { validation: { required: true, minlength: 1, maxlength: 30 } }
                    }
                }
            }
        },

        save: function () {
            this.refresh();
        }
    })
}
