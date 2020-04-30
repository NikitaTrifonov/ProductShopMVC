function init() {
    var product = window.product.Data;
    var category = window.product.Category;
    if (product === null) {
        product = {
            ProductId: "",
            ProductName: "",
            ProductWeight: "",
            ProductCategory: "",
            ProductImageRes: "defaultImg.png"
        }
        hideDelImgBtn();
        getImg(product.ProductImageRes);
        addProductCategory(category);
        $("#submitButton").attr('disabled', 'disabled');
        AddOrEdit("AddProduct", product);
    }
    else {
        showDelImglBtn();
        getImg(product.ProductImageRes);
        addProductCategory(category);
        $("#File-upload-button").text("Изменить");
        $("#inputId").val(product.ProductId);
        $("#inputName").val(product.ProductName);
        $("#inputWeight").val((product.ProductWeight).replace(/,/g, "."));
        $("#ProductCategory").val(product.ProductType).change();
        AddOrEdit("EditProduct", product);
    }
}

$(function () {
    init()
});

function addProductCategory(category) {
    for (var i = 1; i < category.ProductCategory.length; i++) {
        $("#ProductCategory").append("<option value='" + (i + 1) + "'>" + category.ProductCategory[i] + "</option>");
    }
}

document.querySelector("#uploadFile").addEventListener("change", function () {
    if (this.files[0]) {
        let fr = new FileReader();
        fr.addEventListener("load", function () {
            $(".addEditProductImg").attr("src", `${fr.result}`);
        }, false);
        fr.readAsDataURL(this.files[0]);
        showDelImglBtn();
    }
});

$("#delImgBtn").click(function () {
    $("#uploadFile").val("");
    let defaultRes = "defaultImg.png";
    getImg(defaultRes);
    hideDelImgBtn();
})

function checkParams() {
    if ($("#inputName").val().length != 0 && $("#inputWeight").val().length != 0) {
        $("#submitButton").removeAttr('disabled');
    }
    else {
        $("#submitButton").attr('disabled', 'disabled');
    }
}

function showDelImglBtn() {
    $("#delImgBtn").show();
}

function hideDelImgBtn() {
    $("#delImgBtn").hide();
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
        case "failWeight":
            setErrorColorMessage();
            $("#statusMessage").text("Некорректный ввод веса продукта!");
            break;
    }
}


function uploadImg(controllerName, product) {
    var files = document.getElementById('uploadFile').files;
    if (files.length > 0) {
        if (window.FormData) {
            var data = new FormData();
            for (var x = 0; x < files.length; x++) {
                data.append("file" + x, files[x]);
            }
            $.ajax({
                type: "POST",
                url: "../Images/UploadImg",
                contentType: false,
                processData: false,
                data: data,
                success: successUploadImg.bind(null, controllerName, product),
                error: function (xhr, status, p3) {
                    alert(xhr.responseText);
                }
            });
        } else {
            alert("Браузер не поддерживает загрузку файлов HTML5!");
        }
    }
}

function AddOrEdit(controllerName, product) {
    $("#submitButton").click(function () {
        if (!checkFields())
            return;
        if (needUploadImg(controllerName)) {
            uploadImg(controllerName, product);
            return;
        }
        setProductData(product);
        if (!checkProductData(product))
            return;
        sendData(controllerName, product);
    });
}

function checkFields() {
    let name = $("#inputName").val();
    if (!$.trim(name)) {
        getStatusMessage('failName');
        return false;
    }
    if ($("#inputWeight").val() <= 0 || !$("#inputWeight").val()) {
        getStatusMessage("failWeight");
        return false;
    }
    return true;
}
function needUploadImg(controllerName) {
    let imgSrc = document.querySelector(".addEditProductImg").getAttribute("src").replace('../Images/GetImg?id=', '');
    let defaultRes = "defaultImg.png";

    switch (controllerName) {
        case "AddProduct":
            if (imgSrc === defaultRes)
                return false;
            break;
        case "EditProduct":
            let productImgRes = window.product.Data.ProductImageRes;
            if ((productImgRes === imgSrc) || (imgSrc === defaultRes))
                return false;
            break;
    }
    return true;
}

function getImg(imgRes) {
    $(".addEditProductImg").attr("src", `../Images/GetImg?id=${imgRes}`);
}

function successUploadImg(controllerName, product, RequstResult) {
    if (RequstResult.IsSuccess) {
        getImg(RequstResult.Data);
        setProductData(product);
        if (!checkProductData(product))
            return;
        else
            sendData(controllerName, product);
    }
    else {
        $("#errorMessage").show();
        $("#errorMessage").text(RequstResult.Error);
    }
}

function checkProductData(product) {
    if (!$.trim(product.ProductName)) {
        getStatusMessage('failName');
        return false;
    }
    if ($("#inputWeight").val() <= 0 || !$("#inputWeight").val()) {
        getStatusMessage("failPrice");
        return false;
    }
    return true;
}

function setProductData(product) {
    product.ProductName = $("#inputName").val();
    product.ProductWeight = Number.parseFloat($("#inputWeight").val()).toFixed(2);
    product.ProductCategory = $("select option:selected").text();
    product.ProductImageRes = $(".addEditProductImg").attr("src").replace('../Images/GetImg?id=', '');
}

function sendData(controllerName, product) {
    $.post(controllerName, product, function (RequestResult) {
        if (RequestResult.IsSuccess) {
            switch (controllerName) {
                case "AddProduct":
                    getStatusMessage("successAdd");
                    $("#submitButton").toggleClass("btnFuncDisable");
                    break;
                case "EditProduct":
                    getStatusMessage("successEdit");
                    $("#submitButton").toggleClass("btnFuncDisable");
                    break;
            }
        }
        else {
            setErrorColorMessage();
            $("#statusMessage").text(RequestResult.Error);
        }
    });
}


function limitDecimal(e) {
    if (e.value.indexOf(".") != '-1') {
        e.value = e.value.substring(0, e.value.indexOf(".") + 3);
    }
}