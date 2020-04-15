function init() {
    var product = window.product.Data;
    var category = window.product.Category;
    if (product === null) {
        product = {
            ProductId: "",
            ProductName: "",
            ProductPrice: "",
            ProductCategory: "",
            ProductImageRes: ""
        }       
        addProductCategory(category);
        $("#submitButton").text("Добавить");
        $("#submitButton").attr('disabled', 'disabled');
        AddOrEdit("AddProduct", product);
    }
    else {
        getImg(product.ProductImageRes);
        addProductCategory(category);
        $("#submitButton").text("Изменить");
        $("#inputId").val(product.ProductId);
        $("#inputName").val(product.ProductName);
        $("#inputPrice").val((product.ProductPrice).replace(/,/g, "."));
        $("#ProductCategory").val(product.ProductType).change();
        AddOrEdit("EditProduct", product);
    }
}

function addProductCategory(category) {
    for (var i = 1; i < category.ProductCategory.length; i++) {
        $("#ProductCategory").append("<option value='" + (i + 1) + "'>" + category.ProductCategory[i] + "</option>");
    }
}

function AddOrEdit(controllerName, product) {
    $("#submitButton").click(function () {
        product.ProductName = $("#inputName").val();
        product.ProductPrice = Number.parseFloat($("#inputPrice").val()).toFixed(2);
        product.ProductCategory = $("select option:selected").text();
        product.ProductImageRes = $(".addEditProductImg").attr("src").replace('GetImg?id=','');
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
                        $("#submitButton").toggleClass("btnFuncDisable");
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

$('#uploadSubmit').on('click', function (e) {
    e.preventDefault();
    var files = document.getElementById('uploadFile').files;
    if (files.length > 0) {
        if (window.FormData !== undefined) {
            var data = new FormData();
            for (var x = 0; x < files.length; x++) {
                data.append("file" + x, files[x]);
            }
            $.ajax({
                type: "POST",
                url: "UploadImg",
                contentType: false,
                processData: false,
                data: data,
                success: successUploadImg,
                error: function (xhr, status, p3) {
                    alert(xhr.responseText);
                }
            });
        } else {
            alert("Браузер не поддерживает загрузку файлов HTML5!");
        }
    }
});

function successUploadImg(RequstResult) {
    if (RequstResult.IsSuccess) {       
        getImg(RequstResult.Data);
    }
    else {
        $("#errorMessage").show();
        $("#errorMessage").text(RequstResult.Error);
    }
}

function getImg(imgRes) {
    $(".addEditProductImg").attr("src", `GetImg?id=${imgRes}`);    
}

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
            $("#statusMessage").text("Некорректный ввод названия продукта! Название не может быть пустым.");
            break;
        case "failPrice":
            setErrorColorMessage();
            $("#statusMessage").text("Некорректный ввод цены продукта! Цена не может быть меньше или равна нулю.");
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

