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
        pageSize: 20,
        groupable: true,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5,
        },
        columns: [
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
            }
        ]
    });
}
