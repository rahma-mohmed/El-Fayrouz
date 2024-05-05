function quantity(option) {
    let qty = $('#qty').val();
    if (option === 'inc') {
        qty = parseInt(qty) + 1;
    }
    else {
        qty = qty == 1 ? qty : qty - 1;
    }
    $('#qty').val(qty);
}

function cart(addcls, removecls) {
    let I = $(this).children('i')[0];
    let recipeId = $(this).attr('data-recipeId');
    console.log(recipeId)
    if ($(I).hasClass('far')) {
        $.ajax({
            url: '/Cart/SaveCart',
            type: 'POST',
            data: { id: recipeId }
        });
        $(I).removeClass("far")
        $(I).addClass("fas")
    }
    else {
        $.ajax({
            url: '/Cart/RemoveCart',
            type: 'POST',
            data: { id: recipeId },
        });
        $(I).removeClass("fas").addClass("far");
    }
}

function getCartList() {
    $.ajax({
        url: '/Cart/GetCart',
        type: 'GET',
        dataType: 'html',
        success: function (res) {
            $('#showCartList').html(res);
        },
        error: function (err) {
            console.log(err);
        }
    });
}