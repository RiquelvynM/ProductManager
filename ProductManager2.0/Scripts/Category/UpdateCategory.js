$(function () {

    $('#formEdit').submit(function (e) {
        debugger;
        const data = {
            id: $('#id').val(),
            name: $('#name').val(),
            details: $('#details').val(),
        };

        e.preventDefault();

        $.ajax({
            url: '/Category/UpdateCategory',
            data: data,
            type: 'POST',
            success: function (response) {
                if (response <= 0) {
                    alert("Hubo un error");
                }
                else if (response == 1) {

                    window.location.href = "/Category/ListingCategory";

                }

            }
        });
    });

});