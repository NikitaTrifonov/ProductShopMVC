$(document).ready(function () {
    getAllProducts();
    getAllCategories();
})

$('#getProductByName').click(function () {
    $.getJSON("GetProductByName", { Name: $('#requiredProductName').val() }, addContentInTable)
})

$("#ProductCategory").change(function () {
    $("select option:selected").each(function () {
        $.getJSON("GetProductsByCategory", { Filter: $("select option:selected").text() }, addContentInTable)
    });
})

$("#productsTable").click(function (e) {
    if (e.target.classList.contains("btnDeleteImg")) {
        var productId = e.target.dataset.productId;
        showDelWindow();
        $("#delDialogBtnNo").click(hideDelWindow);
        $("#mask").click(hideDelWindow);
        $("#delDialogBtnYes").click(function () {
            $.post("DelProduct", { Id: productId }, delSuccess);
        })
    }
})

function getAllProducts() {
    $.getJSON("GetAllProducts", addContentInTable);
}

function getAllCategories() {
    $.getJSON("GetProductsCategory", addProductCategory)
}

function addProductCategory(RequestResult) {
    if (RequestResult.IsSuccess) {
        for (var i = 0; i < RequestResult.Data.length; i++) {
            $("#ProductCategory").append("<option value='" + (i) + "'>" + RequestResult.Data[i] + "</option>");
        }
    }
    else {
        $("#errorMessage").show();
        $("#errorMessage").text("Ошибка загрузки категорий товаров!");
    }
}

function addContentInTable(RequestResult) {
    if (RequestResult.IsSuccess) {
        showDataTable();
        for (var i = 0; i < RequestResult.Data.length; i++) {
            tr = $('<tr class ="trContent">');
            tr.append(`<td>${(i + 1)}</td>`);
            tr.append(`<td><img class ='productImg' src='GetImg?id=${RequestResult.Data[i].ProductImageRes}'></td>`);
            tr.append(`<td>${RequestResult.Data[i].ProductName}</td>`);
            tr.append(`<td>${RequestResult.Data[i].CategoryString}</td>`)
            tr.append(`<td><p>${RequestResult.Data[i].ProductPrice} ₽</p></td>`);
            tr.append(`<td><a href ='EditProductView?id=${RequestResult.Data[i].ProductId}'><img class ='btnEditImg' src='../Content/Images/btnEdit.png'/></a></td >`);
            tr.append(`<td><a id='btnDelete'><img class ='btnDeleteImg'  src='../Content/Images/btnDelete.png'/ data-product-id='${RequestResult.Data[i].ProductId}'></a ></td > `);
            $('#productsTable').append(tr);
        }
    }
    else 
        hideDataTable(RequestResult);    
}

function delSuccess(RequstResult) {
    hideDelWindow()
    $("#statusMessage").show();
    if (RequstResult.IsSuccess) {
        $("#statusMessage").text("Продукт удалён!");
        getAllProducts();
    }
    else
        $("#statusMessage").text(RequstResult.Error);
}

function showDataTable() {
    $("#errorMessage").hide();
    $("#productsTable").show();
    $("tr.trContent").remove();
}

function hideDataTable(RequestResult) {
    $("#productsTable").hide();
    $("#errorMessage").show();
    $("#errorMessage").text(RequestResult.Error);
}

function showDelWindow() {
    $(".delDialogWindow").css("display", "initial");
    var maskHeight = $(window).height();
    var maskWidth = $(window).width();
    $('#mask').css({ 'width': maskWidth, 'height': maskHeight });
    $('#mask').css("display", "initial");
}

function hideDelWindow() {
    $(".delDialogWindow, #mask").hide();
}
