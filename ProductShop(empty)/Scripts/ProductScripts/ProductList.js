$(document).ready(function () {
    $.getJSON("GetAllProducts", addContentInTable);
})

$('#getProductByName').click(function () {
    $.getJSON("GetProductByName", { Name: $('#requiredProductName').val() }, addContentInTable)
})

$('#reloadProductsList').click(function () {
    $.getJSON("GetAllProducts", addContentInTable);
})

$(document).ready(function () {
    $.getJSON("GetProductsCategory", addProductCategory)
})


$("#ProductCategory").change(function () {
    $("select option:selected").each(function () {
        $.getJSON("GetProductsByCategory", { Filter: $("select option:selected").text() }, addContentInTable)
    });    
})


function addProductCategory(RequestResult) {
    if (RequestResult.IsSuccess) {
        for (var i = 0; i < RequestResult.Data.length; i++) {
            $("#ProductCategory").append("<option value='" + (i) + "'>" + RequestResult.Data[i] + "</option>");
        }
    }
    else {
        $("#errorMessage").show();
        ("#errorMessage").text("Ошибка загрузки категорий товаров!");
    }
}

function addContentInTable(RequestResult) {
    if (RequestResult.IsSuccess) {
        $("#errorMessage").hide();
        $("#productsTable").show();
        $('tr.trContent').remove();
        for (var i = 0; i < RequestResult.Data.length; i++) {
            tr = $('<tr class ="trContent">');
            tr.append("<td>" + (i + 1) + "</td>");
            tr.append("<td>" + RequestResult.Data[i].ProductName + "</td>");
            tr.append("<td>" + RequestResult.Data[i].CategoryString + "</td>")
            tr.append("<td>" + RequestResult.Data[i].ProductPrice + "</td>");            
            tr.append("<td><a href ='EditProductView?id=" + RequestResult.Data[i].ProductId + "'>Редактировать</a >" + "</td > ");
            $('#productsTable').append(tr);
        }
    }
    else {
        $("#productsTable").hide();
        $("#errorMessage").show();
        $("#errorMessage").text(RequestResult.Error);
    }
}