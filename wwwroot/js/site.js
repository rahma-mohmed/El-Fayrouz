function quantity(option) {
    let qty = $('#qty').val();
    let price = parseFloat($('#price').val());
    let totalAmount = 0;
    if (option === 'inc') {
        qty = parseInt(qty) + 1;
    }
    else {
        qty = qty == 1 ? qty : qty - 1;
    }
    totalAmount = price * qty;
    $('#qty').val(qty);
    $('#TotalAmount').val(totalAmount);
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

function GetAddedCart() {
    $.ajax({
        url: '/Cart/GetAddedCart',
        type: 'GET',
        dataType: 'html',
        success: function (res) {
            $('.addToCart').each((indx, Spanitag) => {
                let recipeId = $(Spanitag).attr('data-recipeId');
                for (var i = 0; i < res.length; i++) {
                    if (recipeId == res[i]) {
                        let itag = $(Spanitag).children('i')[0];
                        $(itag).addClass("fas");
                        $(itag).removeClass("far");
                        break;
                    }
                }
            })
        },
        error: function (err) {
            console.log(err);
        }

    });
}