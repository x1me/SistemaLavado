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
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5,
        },
        columns: [
            {
                field: "codigo",
                title: "Codigo "
                   
            },
            {
                field: "pais",
                title: " País"
            },
            {
                field:"Editar",
                title: "Editar",
                template: "<button class='btn btn- lg btn - primary' <button onclick='modificar(codigo)'>Editar</button>"
            },
            {
                field: "Eliminar",
                title: "Eliminar", 
                template: "<button class='btn btn- lg btn - primary' <button onclick='eliminar()'>Eliminar</button>"
            },
        ]
        
    });
}
function modificar(codigo) {
    var codigo = $(this).data('codigo');
    if (codigo != undefined && codigo != null) {
        window.location.href = "/MantenimientoFabricante/agregaroeditar?id=" + codigo;
    }    
    var grid = $("#ListaFabricante").data(datos);
    var selectedItem = grid.dataItem(grid.select());
    $("#codigo").val(selectedItem.codigo);
    $("#pais").val(selectedItem.pais);
}