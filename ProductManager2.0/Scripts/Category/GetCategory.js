$(function () {
    LoadData();

    //Metdo que trae lista de categorias
    function LoadData() {

        $.ajax({

            url: 'Categories',

            type: 'GET',

            dataType: 'json',

            success: function (data) {


                let filas;
                $(data).each(function (index, value) {

                    filas += '<tr idproduct=' + value.Id + '> <td>' + value.Id + '</td>'
                    filas += '<td>' + value.Name + '</td>'
                    filas += '<td>' + value.Details + '</td>'
                    filas += '<td> <input type="button" value="Editar" class="Id-edit btn btn-default">'
                    filas += '<input type="button" value="Eliminar" class="Id-delete btn btn-danger">  </td> </tr>'

                });

                //os agrega en la vista
                $('#categories').html(filas);
                ;
            },


            error: function (xhr, status) {
                alert('Disculpe, existió un problema');
            }
        });
    }


    // Hace consulta a la db y los devuelve en la vista
    $('#search').keyup(function (e) {
        let search = $('#search').val();

        $.ajax({
            url: 'SearchByNameCategory',

            type: 'POST',

            dataType: 'Json',

            data: { search: search },

            success: function (data) {

                let filas;
                $(data).each(function (index, value) {

                    filas += '<tr idproduct=' + value.Id + ' > <td>' + value.Id + '</td>'
                    filas += '<td>' + value.Name + '</td>'
                    filas += '<td>' + value.Details + '</td>'
                    filas += '<td> <input type="button" value="Editar" class="Id-edit btn btn-default">'
                    filas += '<input type="button" value="Eliminar" class="Id-delete btn btn-danger">  </td> </tr>'
                });



                $('#categories').html(filas);
            }
        })
    });

    $(document).on('click', '.Id-edit', function () {
        debugger;
        let element = $(this)[0].parentElement.parentElement;
        let id = $(element).attr('idproduct');

        window.location.href = "EditCategory/" + id;

    });

    $(document).on('click', '.Id-delete', function () {

        if (confirm("Seguro que desea eliminar el producto?")) {
            let element = $(this)[0].parentElement.parentElement;
            let id = $(element).attr('idproduct');

            $.post('DeleteCategory', { id: id }, function (response) {
                LoadData();

            })
        }

    });

});
