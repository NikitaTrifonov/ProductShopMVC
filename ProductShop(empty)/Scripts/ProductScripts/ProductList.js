$(document).ready(function () {
    $.getJSON("GetAllProducts", addContentInTable);
})

$('#getProductByName').click(function () {
    $.getJSON("GetProductByName", { Name: $('#requiredProductName').val() }, addContentInTable)
})

$('#reloadProductsList').click(function () {
    $.getJSON("GetAllProducts", addContentInTable);
})


function addContentInTable(RequestResaults) {
    if (RequestResaults.IsSuccess) {
        $("#errorMessage").hide();
        $("#productsTable").show();
        $('tr.trContent').remove();
        for (var i = 0; i < RequestResaults.Data.length; i++) {
            tr = $('<tr class ="trContent">');
            tr.append("<td>" + (i + 1) + "</td>");
            tr.append("<td>" + RequestResaults.Data[i].ProductName + "</td>");
            tr.append("<td>" + RequestResaults.Data[i].ProductPrice + "</td>");
            tr.append("<td><a href ='EditProductView?id=" + RequestResaults.Data[i].ProductId + "'>Редактировать</a >" + "</td > ");
            $('#productsTable').append(tr);
        }
    }
    else {
        $("#productsTable").hide();
        $("#errorMessage").show();        
        $("#errorMessage").text(RequestResaults.Error);
    }
}