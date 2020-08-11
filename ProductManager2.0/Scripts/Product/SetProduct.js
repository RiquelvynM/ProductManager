$(function () {
    debugger;

    $.ajax({

        url: 'ListingCategories',

        dataType: 'JSON',

        success: function (categories) {
            
            var opcion;
            for (var i = 0; i < categories.length; i++) {

                opcion += '<option value=' + categories[i].Id + '>' + categories[i].Name + '</option>'
            };

            $('#categoryId').html(opcion);

        }
    });

    debugger;
    $('#form').submit(function (e) {
        const data = {
            name: $('#name').val(),
            price: $('#price').val(),
            detail: $('#detail').val(),
            idCategory: $('#categoryId').val()
        };


        e.preventDefault();
        $.post('CreateProduct', data, function (response) {
            if (response == 1) {
                window.location.href = "ListingProducts";
            }

            console.log(response);
        });
    });
});