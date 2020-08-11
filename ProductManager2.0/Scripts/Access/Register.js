$(function () {

    //Formulario enviado para crear usuario, todo se obtiene memdiante los id
    $('#form').submit(function (e) {

        const data = {
            email: $('#email').val(),
            password: $('#password').val(),
            name: $('#name').val(),
            lastName: $('#lastName').val(),
            phone: $('#phone').val()
        };
        e.preventDefault();
        $.post('RegistrerUser', data, function (response) {

            if (response == 1) {
                window.location.href = "Login";
            }

        });

    });

});