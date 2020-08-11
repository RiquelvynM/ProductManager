$(function () {

    //Este metodo inmediatamente carga la pagina se ejecuta con los datos
    CargarDatos();

    $('#search').keyup(function (e) {
        let search = $('#search').val();

        //Este metodo busca y agrega en la vista los datos obtenidos de la consulta
        $.ajax({
            url: 'Access/Search_ByNameProduct',

            type: 'POST',

            dataType: 'Json',

            data: { search: search },

            success: function (data) {
                
                let filas;
                $(data.Table).each(function (index, value) {

                    filas += '<tr><td>' + value.Id + '</td>'
                    filas += '<td>' + value.Name + '</td>'
                    filas += '<td>' + value.Price + '</td>'
                    filas += '<td>' + value.Detail + '</td>'
                    filas += '<td>' + value.NameCategory + '</td>'
                    filas += '</tr>'
                });

                $('#listProducts').html(filas);
            }
        })
    })

    function CargarDatos() {

        $.ajax({

            url: 'Access/GetProducts',

            type: 'GET',

            dataType: 'json',

            success: function (data) {

                let filas;


                $(data.Table).each(function (index, value) {

                    filas += '<tr><td>' + value.Id + '</td>'
                    filas += '<td>' + value.Name + '</td>'
                    filas += '<td>' + value.Price + '</td>'
                    filas += '<td>' + value.Detail + '</td>'
                    filas += '<td>' + value.NameCategory + '</td>'
                    filas += '</tr>'
                });

                $('#listProducts').html(filas);

            },

            error: function (xhr, status) {
                alert('Disculpe, existió un problema');
            }
        });
    }


});
