$(function () {
    //metodo que es enviado al controlador para actualizar usuario
    
    $('#formEdit').submit(function (e) {
        const data = {
            email: $('#email').val(),
            password: $('#password').val(),
            name: $('#name').val(),
            lastName: $('#lastName').val(),
            phone: $('#phone').val()
        };

        e.preventDefault();
        $.ajax({
            url:'/Access/UpdateUser',

            data: data ,

            type: 'POST',

            success: function (response) {

                if (response <= 0) {

                    alert("Hubo un error !");
                }
                else if (response == 1) {
                    alert("Actualizado correctamente");
                    

                }
            }


        });

    });



});