$(function () {

    // envia los datos al controlador y dependiendo de la respuesta toma accion
    $('#form').submit(function (e) {
        const data = {

            email: $('#email').val(),

            password: $('#password').val()
        }
        e.preventDefault();

        $.post("Login", data, function (data) {
            debugger;
            var Json = JSON.parse(data);
            if (Json[0] == null) {
                alert("Usuario o contraseña incorreccta");
            }
            else if (Json[0].Id >= 1) {

                window.location.replace("https://localhost:44329/Product/listingProducts")
            }
        });


    });

});

