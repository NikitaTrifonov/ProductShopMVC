$(document).ready(function () {
    $.getJSON("GetAllProducts", addContentInTable);
})


$('#getProductByName').click(function () {
    $.getJSON("GetProductByName", { Name: $('#requiredProductName').val() }, addContentInTable)
})

$('#reloadProductsList').click(function () {
    $.getJSON("GetAllProducts", addContentInTable);
})

function addContentInTable(data) {
    $('tr.trContent').remove();
    for (var i = 0; i < data.length; i++) {
        tr = $('<tr class ="trContent">');
        tr.append("<td>" + data[i].ProductId + "</td>");
        tr.append("<td>" + data[i].ProductName + "</td>");
        tr.append("<td>" + data[i].ProductPrice + "</td>");
        $('#productsTable').append(tr);
    }
}


