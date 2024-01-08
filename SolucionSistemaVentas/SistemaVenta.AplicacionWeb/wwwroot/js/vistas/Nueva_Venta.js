const MODELO_BASE = {


}

let tablaData;

let ValorImpuesto = 0;

$(document).ready(function () {

    $("#cboBuscarProducto").select2({
        ajax: {
            url: "/Venta/ObtenerProductos",
            dataType: 'json',
            contentType:"application/json; charset=utf-8",
            delay: 250,
            data: function (params) {
                return {
                    busqueda: params.term
                };
            },
            processResults: function (data, ) {
                // parse the results into the format expected by Select2
                // since we are using custom formatting functions we do not need to
                // alter the remote JSON data, except to indicate that infinite
                // scrolling can be used
               

                return {
                    results: data.map((item) => ({

                        id: item.idProducto,
                        text: item.descripcion,

                        categoria: item.nombreCategoria,
                        urlImagen: item.urlImagen,
                        precio: parseFloat(item.precio)

                    }
                    ))
                    
                };
            }
        },
        language: "es",
        placeholder: 'Buscar Producto...',
        minimumInputLength: 1,
        templateResult: formatoResultados,
        
    });

})

function formatoResultados(data) {

    //esto es por defecto ya que muestre el buscando...
    if (data.loading)
        return data.text;

    var contenedor = $(

        `<table width="100%">
         <tr>
             <td style="width:60px">
                 <img style="height:60px;width:60px;margin-right:10px" src="${data.urlImagen}"/>
             </td>
             <td>
                 <p style="margin:2px">${data.text}</p>
             </td>
        </tr>

        </table>`

    );
    return contenedor;

}

let ProductosParaVenta = [];

$("#cboBuscarProducto").on("select2:select", function (e) {

    const data = e.params.data;

    let producto_encontrado = ProductosParaVenta.filter(p => p.idProducto == data.id)

    if (producto_encontrado.length > 0) {

        $("#cboBuscarProducto").val("").trigger("change")
        toastr.warning("","El producto ya fue agregado")
        return false
    }

    swal({
        title: "VENDIENDO...XD",
        text: data.text,
        imageUrl: data.urlImagen,
        type: "input",
        showCancelButton: true,
        closeOnConfirm: false,
        inputPlaceholder: "Ingrese Cantidad"

    },
        function (valor) {
            
            if (valor === false) return false;

            if (valor === "") {

                toastr.warning("", "Necesita ingresar la cantidad")
                return false;
            }
            if (isNaN(parseInt(valor))) {

                toastr.warning("", "Debe ingresar un valor numerico")
                return false;
            }

            let producto = {
                idProducto: data.id,
                //marcaProducto: data.marca
                //descripcionProducto: data.text
                categoriaProducto: data.categoria,
                cantidad: parseInt(valor),
                precio: data.precio.toString(),
                total: (parseFloat(valor)*data.precio).toString()

            }
           
            ProductosParaVenta.push(producto)
            mostrarProducto_Precios();
            toastr.warning("", "El producto ya fue agregado")

            swal.close()
        }

    )

})

function mostrarProducto_Precios() {

    let total = 0;
    let igv = 0;
    let subtotal = 0;
    let porcentaje = ValorImpuesto / 100;

    $("#tbProducto tbody").html("")

    ProductosParaVenta.forEach((item) => {

        total = total.parseFloat(item.total)

        $("#tbProducto tbody").append(
            $("<tr>").append(
                $("<td>").append(
                    $("<button>").addClass("btn btn-danger btn-eliminar btn-sm").append(
                        $("<i>").addClass("fas fa-trash-alt")

                    ).data("idProducto", item.idProducto)
                ),
                //$("<td>").text(item.descripcionProducto),
                $("<td>").text(item.cantidad),
                $("<td>").text(item.precio),
                $("<td>").text(item.total)  
            )

        )

    })

    subtotal = total / (1 + procentaje);
    igv = total - subtotal;

    $("#txtSubTotal").val(subtotal.toFixed(2))
    $("#txtIGV").val(igv.toFixed(2))
    $("#txtTotal").val(total.toFixed(2))

}


$(document).on("click", "button.btn-eliminar", function (){

    const _idproducto = $(this).data("idProducto")

    ProductosParaVenta = ProductosParaVenta.filter(p => p.idProducto != _idproducto);

    mostrarProducto_Precios();

})

$("#btnTerminarVenta").click(function () {

    if (ProductosParaVenta.length < 1) { //si es menor a 1 no existen productos

        toastr.warning("", "Debe ingresar productos")
        return;
    }

    const vmDetalleVenta = ProductosParaVenta;

    const venta = {

        //idTipoDocumentoVenta: $("#cboTipoDocumentoVenta").val(),
        documentoCliente: $("#txtDocumentoCliente").val(),
        nombreCliente: $("#txtNombreCliente").val(),
        subTotal: $("#txtSubTotal").val(),
        impuestoTotal: $("#txtIGV").val(),
        total: $("#txtTotal").val(),
        DetalleVenta: vmDetalleVenta
    }

    $("#btnTerminarVenta").LoadingOverlay("show");


    fetch("/Venta/RegistrarVenta", {

        method: "POST",
        headers: { "Content-Type": "application/json;charset=utf-8" },
        body: JSON.stringify(venta)


    })
        .then(response => {
            $("#btnTerminarVenta").LoadingOverlay("hide");
            return response.ok ? reponse.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.estado) {
                ProductosParaVenta = [];
                mostrarProducto_Precios();

                $("#txtDocumentoCliente").val("")
                $("#txtNombreCliente").val("")
                //$("#cboTipoDocumentoVenta").val($("#cboTipoDocumentoVenta option:first").val())

                swal("Registrado", `Numero Venta : ${responseJson.objeto.numeroVenta}`, "success")
            } else {
                swal("Lo sentimos", "No se pudo registrar la venta", "error")

            }

        })

})