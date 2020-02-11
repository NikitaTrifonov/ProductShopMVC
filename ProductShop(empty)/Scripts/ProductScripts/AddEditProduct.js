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
            product.ProductPrice = $("#inputPrice").val();
            if (!$.trim(product.ProductName)) {               
                getStatusMessage('failName');
            }
            else
                if ($("#inputPrice").val() <= 0 || !$("#inputPrice").val()) {                    
                    getStatusMessage("failPrice");
                }
                else {
                    $.post("EditProduct", product,  getStatusMessage('success'));
                }
        });
    }
}

$(function () {
    init()
});


function setErrorColorMessage() {
    $("#succsesMessage").removeAttr('class');
    $("#succsesMessage").attr('class', 'errorMessage');
}

function getStatusMessage(status) {
    switch (status) {
        case "success":
            $("#succsesMessage").removeAttr('class');
            $("#succsesMessage").attr('class', 'successMessage');
            $("#succsesMessage").text("Успешно! Изменения сохранены!");
            break;
        case "failName":
            setErrorColorMessage()
            $("#succsesMessage").text("Некорректный ввод названия продукта! Название не может быть пустым. Изменения не сохранены!");
            break;
        case "failPrice":
            setErrorColorMessage();
            $("#succsesMessage").text("Некорректный ввод цены продукта! Цена не может быть меньше или равна нулю. Изменения не сохранены!");
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