function init() {
    var product = window.product;
    if (product === null) {
        product = {
            ProductId: "",
            ProductName: "",
            ProductPrice: ""
        }
        $("#submitButton").val("Добавить");
        $("#submitButton").attr('disabled', 'disabled');
        AddOrEdit("AddProduct", product);
    }
    else {
        $("#inputId").val(product.ProductId);
        $("#inputName").val(product.ProductName);
        $("#inputPrice").val(product.ProductPrice);
        AddOrEdit("EditProduct", product);
    }
}

function AddOrEdit(controllerName, product) {
    $("#submitButton").click(function () {
        product.ProductName = $("#inputName").val();
        product.ProductPrice = Number.parseFloat($("#inputPrice").val()).toFixed(2);
        if (!$.trim(product.ProductName)) {
            getStatusMessage('failName');
            return;
        }
        if ($("#inputPrice").val() <= 0 || !$("#inputPrice").val()) {
            getStatusMessage("failPrice");
            return;
        }

        $.post(controllerName, product, function (RequestResult) {
            if (RequestResult.IsSuccess) {
                switch (controllerName) {
                    case "AddProduct":
                        getStatusMessage("successAdd");
                        break;
                    case "EditProduct":
                        getStatusMessage("successEdit");
                        break;
                }
            }
            else {
                setErrorColorMessage();
                $("#statusMessage").text(RequestResult.Error);
            }
        });
    });
}

$(function () {
    init()
});

function setErrorColorMessage() {
    $("#statusMessage").removeAttr('class');
    $("#statusMessage").attr('class', 'errorMessage');
}

function getStatusMessage(status) {
    switch (status) {
        case "successEdit":
            $("#statusMessage").removeAttr('class');
            $("#statusMessage").attr('class', 'successMessage');
            $("#statusMessage").text("Успешно! Изменения сохранены!");
            break;
        case "successAdd":
            $("#statusMessage").removeAttr('class');
            $("#statusMessage").attr('class', 'successMessage');
            $("#statusMessage").text("Успешно! Продукт сохранен!");
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