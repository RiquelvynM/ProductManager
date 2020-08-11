$(function () {

    $('#formEdit').submit(function (e) {
      
        const data = {
            id: $('#id').val(),
            name: $('#name').val(),
            price: $('#price').val(),
            detail: $('#detail').val(),
            categoryId: $('#categoryId').val()
        };
       

        $.ajax({

            url: '/Product/EditProduct',
            data: data ,
            type: 'POST',

            success: function (response) {
                if (response <= 0) {
                    alert("Hubo un error");
                }
                else {
                    window.location.href = '/Product/ListingProducts';
                 }
            },

            error: function (xhr, status) {
                alert('Disculpe, existió un problema');
            }
        });

    });

});

