﻿function init() {
    var product = window.product;
    if (product === null) {
        $("#inputId").val("Автозаполнение");
        $("#AddEditBtn").val("Добавить");

    }
    else {
        $("#inputId").val(product.ProductId);
        $("#inputName").val(product.ProductName);
        $("#inputPrice").val(product.ProductPrice);

        $("#AddEditBtn").click(function () {
            product.ProductName = $("#inputName").val();
            product.ProductPrice = $("#inputPrice").val();

            var prod = {
                ProductId: product.ProductId,
                ProductName: $("#inputName").val(),
                ProductPrice: $("#inputPrice").val()
            }

            $.ajax({
                type: "POST",
                url: "/Product/EditProduct",
                data: {prod: prod}
            });
        });
    }
   
}
$(function () {
    init()
});

function succsesFunction() {
    $("#succsesMessage").val("Продукт изменен");
}