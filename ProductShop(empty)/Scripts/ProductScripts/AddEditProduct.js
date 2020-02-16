function init() {
    var product = window.product;
    if (product === null) {
        $("#inputId").val("Автозаполнение");
        $("#submitButton").val("Добавить");

    }
    else {
        $("#inputId").val(product.ProductId);
        $("#inputName").val(product.ProductName);
        $("#inputPrice").val(product.ProductPrice);

        $("#submitButton").click(function () {
            product.ProductName = $("#inputName").val();
            product.ProductPrice = Number.parseFloat($("#inputPrice").val()).toFixed(2);
            if (!$.trim(product.ProductName)) {
                getStatusMessage('failName');
            }
            else
                if ($("#inputPrice").val() <= 0 || !$("#inputPrice").val()) {
                    getStatusMessage("failPrice");
                }
                else {
                    $.post("EditProduct", product, IsSuccess);
                }
        });
    }
}

$(function () {
    init()
});

function IsSuccess(RequestResault) {
    if (RequestResault.IsSuccess) {
        getStatusMessage('success')
    }
    else {
        setErrorColorMessage();
        $("#statusMessage").text(RequestResault.Error)
    }
}

function setErrorColorMessage() {
    $("#statusMessage").removeAttr('class');
    $("#statusMessage").attr('class', 'errorMessage');
}

function getStatusMessage(status) {
    switch (status) {
        case "success":
            $("#statusMessage").removeAttr('class');
            $("#statusMessage").attr('class', 'successMessage');
            $("#statusMessage").text("Успешно! Изменения сохранены!");
            break;
        case "failName":
            setErrorColorMessage()
            $("#statusMessage").text("Некорректный ввод названия продукта! Название не может быть пустым. Изменения не сохранены!");
            break;
        case "failPrice":
            setErrorColorMessage();
            $("#statusMessage").text("Некорректный ввод цены продукта! Цена не может быть меньше или равна нулю. Изменения не сохранены!");
            break;
    }
}

function checkParams() {
    if ($("#inputName").val().length != 0 && $("#inputPrice").val().length != 0) {
        $("#submitButton").removeAttr('disabled');
    }
    else {
        $("#submitButton").attr('disabled', 'disabled');
    }
}
function limitDecimal(e) {
    if (e.value.indexOf(".") != '-1') {
        e.value = e.value.substring(0, e.value.indexOf(".") + 3);
    }
}