$(function () {
    //Recibe datos del formulario y los envia a la db

    $('#form').submit(function (e) {
        
        const data = {
            name: $('#name').val(),
            details: $('#details').val(),
        };

        e.preventDefault();
        $.post('CreateCategory', data, function (response) {
            if (response == 1) {
                window.location.href = "ListingCategory";
            }

        });
    });
});
