var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnConfirm').off('click').on('click', function () {
            window.location.href = "/Cart/Confirm";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listSoLuong = $('.txtQuantity');
            var listGhiChu = $('.txtGhiChu');
            var cartList1 = [];
            $.each(listSoLuong, function (i, item) {
                cartList1.push({
                    SOLUONG: $(item).val(),
                    MAMON: $(item).data('id')
                });
            });
            var cartList2 = [];
            $.each(listGhiChu, function (i, item) {
                cartList2.push({
                    GHICHU: $(item).val(),
                    MAMON: $(item).data('id')
                });
            });
        $.ajax({
            url: '/Cart/Update',
            data: {
                cartModel1: JSON.stringify(cartList1),
                cartModel2: JSON.stringify(cartList2)
                },
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status == true) {
                    window.location.href = "/Cart";
                }
                else {

                }
            }
        })
        });
        $('#btnDeleteAll').off('click').on('click', function () {
            
            $.ajax({
                url: '/Cart/DeleteAll',
                
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                    else {

                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function () {

            $.ajax({
                url: '/Cart/Delete',
                data: {
                    id: $(this).data('id')
                },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                    else {

                    }
                }
            })
        });
    }
}
cart.init();