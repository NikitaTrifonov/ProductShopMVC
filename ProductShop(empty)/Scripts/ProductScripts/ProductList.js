$(document).ready(function () {
    $.getJSON("GetAllProducts", addContentInTable);
})

$('#getProductByName').click(function () {
    $.getJSON("GetProductByName", { Name: $('#requiredProductName').val() }, addContentInTable)
})

$('#reloadProductsList').click(function () {
    $.getJSON("GetAllProducts", addContentInTable);
})

//function addContentInTable(data) {
//    $('tr.trContent').remove();
//    for (var i = 0; i < data.length; i++) {
//        tr = $('<tr class ="trContent">');
//        tr.append("<td>" + (i + 1) + "</td>");
//        tr.append("<td>" + data[i].ProductName + "</td>");
//        tr.append("<td>" + data[i].ProductPrice + "</td>");
//        tr.append("<td><a href ='EditProductView?id=" + data[i].ProductId + "'>Редактировать</a >" + "</td > ");
//        $('#productsTable').append(tr);
//    }
//}


function addContentInTable(Resaults) {
    if (Resaults.IsSuccess) {
        $("#errorMessage").hide();
        $("#productsTable").show();
        $('tr.trContent').remove();
        for (var i = 0; i < Resaults.Data.length; i++) {
            tr = $('<tr class ="trContent">');
            tr.append("<td>" + (i + 1) + "</td>");
            tr.append("<td>" + Resaults.Data[i].ProductName + "</td>");
            tr.append("<td>" + Resaults.Data[i].ProductPrice + "</td>");
            tr.append("<td><a href ='EditProductView?id=" + Resaults.Data[i].ProductId + "'>Редактировать</a >" + "</td > ");
            $('#productsTable').append(tr);
        }
    }
    else {
        $("#productsTable").hide();
        $("#errorMessage").show();        
        $("#errorMessage").text(Resaults.Error);
    }
}