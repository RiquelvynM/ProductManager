    $(function () {
    CargarDatos();

        //Envia los datos al controlador encargado de buscar mediante caracteres y los muestra en la vista
    $('#search').keyup(function (e) {
        let search = $('#search').val();

        $.ajax({
            url: 'Search_ByNameProduct',

            type: 'POST',

            dataType: 'Json',

            data: { search: search },

            success: function (data) {

                let filas;
                $(data.Table).each(function (index, value) {

                    filas += '<tr idproduct=' + value.Id + ' > <td>' + value.Id + '</td>'
                    filas += '<td>' + value.Name + '</td>'
                    filas += '<td>' + value.Price + '</td>'
                    filas += '<td>' + value.Detail + '</td>'
                    filas += '<td>' + value.NameCategory + '</td>'
                    filas += '<td> <input type="button" value="Editar" class="Id-edit btn btn-default">'
                    filas += '<input type="button" value="Eliminar" class="Id-delete btn btn-danger">  </td> </tr>'
                });



                $('#products').html(filas);
            }
        })
    });
        //Recoge el id de la categoria y los devuelve a la vista Edit
    $(document).on('click', '.Id-edit', function () {
        debugger;
        let element = $(this)[0].parentElement.parentElement;
        let id = $(element).attr('idproduct');

        window.location.href = "EditProduct/" + id;
                                

    });

    $(document).on('click', '.Id-delete', function () {

        if (confirm("Seguro que desea eliminar el producto?")) {
            let element = $(this)[0].parentElement.parentElement;
            let id = $(element).attr('idproduct');

            $.post('DeleteProduct', { id: id }, function (response) {
               
                CargarDatos();

            })
        }

    });

        //Carga los datos de los productos 
        function CargarDatos() {
            
        $.ajax({

            url: 'GetProducts',

            type: 'GET',

            dataType: 'json',

            success: function (data) {
               
                let filas;
                $(data.Table).each(function (index, value) {
                   

                    filas += '<tr idproduct=' + value.Id + '> <td>' + value.Id + '</td>'
                    filas += '<td>' + value.Name + '</td>'
                    filas += '<td>' + value.Price + '</td>'
                    filas += '<td>' + value.Detail + '</td>'
                    filas += '<td>' + value.NameCategory + '</td>'
                    filas += '<td> <input type="button" value="Editar" class="Id-edit btn btn-default">'
                    filas += '<input type="button" value="Eliminar" class="Id-delete btn btn-danger">  </td> </tr>'

                });

                $('#products').html(filas);
                ;
            },


            error: function (xhr, status) {
                alert('Disculpe, existió un problema');
            }
        });
    };

});
