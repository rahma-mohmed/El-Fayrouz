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