function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}
function DisplayCart() {
    $.get("/GioHang/LoadGioHang", function (data) {
        $("#count-cart").html(data.soluong);
        $("#total_price").html(numberWithCommas(data.tongtien));
        $("#show-cart").html("");
        $.each(data.giohang, function (i, val) {
            $("#show-cart").append("<tr class='cart_item'>"
                + "<td class='product-remove'>"
                + "<div class='bt_remove_product left' data-product-code='" + val.ID + "'>" + "</div>"
                + "</td>"
                + "<td class='product-name'>"
                + "<b>" + val.Ten + "</b>"
                + "<div class='clr'></div>"
                + "<div class='box_quantity left'>"
                + "<div class='quantity right'>"
                + "<input class='bt_minus' type='button' value='-' data-product-code='" + val.ID + "'>"
                + "<input type='text' disabled='' name='product_cart_qty' value='" + val.SL + "' title='Qty' class='input-text qty text product_qty' size='4'>"
                + "<input class='bt_plus' type='button' value='+' data-product-code='" + val.ID + "'>"
                + "</div>"
                + "</div>"
                + "</td>"
                + "<td class='product-price' valign='top'>"
                + "<span class='amount'>" + numberWithCommas(val.SL * val.Gia) + "</span>"
                + "</td>"
                + "</tr>");
        });
    });
}

function DisplayPageCart() {
    $.get("/GioHang/LoadGioHang", function (data) {
        $("#count-item-cart").html(data.soluong);
        $("#total-item-price").html(numberWithCommas(data.tongtien));
        $("#show-item-cart").html("");
        $.each(data.giohang, function (i, val) {
            $("#show-item-cart").append("<tr>"
                + "<td class='cart_product'>"
                + "<a href='#'><img src='/Content/Images/" + val.Anh + "' alt='Product'></a>"
                + "</td>"
                + "<td class='cart_description'>"
                + "<p class='product-name'><a href='#'>" + val.Ten + "</a></p>"
                + "<small class='cart_ref'>Product Code : " + val.ID + "</small>"
                + "<br>"
                + "</td>"
                //+ "<td class='cart_avail'><span class='label label-success'>In stock</span></td>"
                + "<td class='price'><span style='color: #e84d1c; font-size: 18px; font-weight: bold;'>" + numberWithCommas(val.Gia) + "</span></td>"
                + "<td class='qty'>"
                + "<input class='form-control input-sm' type='text' readonly value='" + val.SL + "'>"
                + "<a class='plus' data-product-code='" + val.ID + "'><i class='fa fa-caret-up'></i></a>"
                + "<a class='minus' data-product-code='" + val.ID + "'><i class='fa fa-caret-down'></i></a>"
                + "</td>"
                + "<td class='price'>"
                + "<span style='color: #e84d1c; font-size: 18px; font-weight: bold;'>" + numberWithCommas(val.SL * val.Gia) + "</span>"
                + "</td>"
                + "<td class='action'>"
                + "<a class='remove_product' data-product-code='" + val.ID + "'>Delete item</a>"
                + "</td>"
                + "</tr>");
        });
    });
}

$(document).ready(function () {
    DisplayCart();
    DisplayPageCart();

    $("#show-cart").on("click", ".bt_plus", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/Tang1SP", { id: productcode }, function (data) {
            if (data.success == true) {
                DisplayCart();
            }
        });
    });

    $("#show-cart").on("click", ".bt_minus", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/Giam1SP", { id: productcode }, function (data) {
            if (data.success == true) {
                DisplayCart();
            }
        });
    });
    $("#show-cart").on("click", ".bt_remove_product", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/Xoa1SP", { id: productcode }, function (data) {
            if (data.success == true) {
                DisplayCart();
            }
        });
    });

    $("#show-item-cart").on("click", ".remove_product", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/Xoa1SP", { id: productcode }, function (data) {
            if (data.success == true) {
                DisplayCart();s
                DisplayPageCart();
            }
        });
    });

    $("#show-item-cart").on("click", ".minus", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/Giam1SP", { id: productcode }, function (data) {
            if (data.success == true) {
                DisplayCart();
                DisplayPageCart();
            }
        });
    });

    $("#show-item-cart").on("click", ".plus", function (event) {
        var productcode = $(this).attr("data-product-code");
        $.get("/GioHang/Tang1SP", { id: productcode }, function (data) {
            if (data.success == true) {
                DisplayCart();
                DisplayPageCart();
            }
        });
    });
});
function muahang(id) {
    $.get("/GioHang/MuaHang", { id: id }, function (data) {
        $("#count-cart").html(data.soluong);
        $("#total_price").html(numberWithCommas(data.tongtien));
        $("#show-cart").html("");
        $.each(data.giohang, function (i, val) {
            $("#show-cart").append("<tr class='cart_item'>"
                + "<td class='product-remove'>"
                + "<div class='bt_remove_product left' data-product-code='" + val.ID + "'>" + "</div>"
                + "</td>"
                + "<td class='product-name'>"
                + "<b>" + val.Ten + "</b>"
                + "<div class='clr'></div>"
                + "<div class='box_quantity left'>"
                + "<div class='quantity right'>"
                + "<input class='bt_minus' type='button' value='-' data-product-code='" + val.ID + "'>"
                + "<input type='text' disabled='' name='product_cart_qty' value='" + val.SL + "' title='Qty' class='input-text qty text product_qty' size='4'>"
                + "<input class='bt_plus' type='button' value='+' data-product-code='" + val.ID + "'>"
                + "</div>"
                + "</div>"
                + "</td>"
                + "<td class='product-price' valign='top'>"
                + "<span class='amount'>" + numberWithCommas(val.SL*val.Gia) + "</span>"
                + "</td>"
                + "</tr>");
        });
    });
}