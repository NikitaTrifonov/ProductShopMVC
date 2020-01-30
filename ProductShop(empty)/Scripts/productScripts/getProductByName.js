$('#getProductByName').click(function () {
    $.post("GetProductByName", { Name: $('#requiredProductName').val() },
        function (data) {
            $('tr.trContent').remove();
            var tr;
            tr = $('<tr class ="trContent">');
            tr.append("<td>" + data.ProductId + "</td>");
            tr.append("<td>" + data.ProductName + "</td>");
            tr.append("<td>" + data.ProductPrice + "</td>");
            $('#productsTable').append(tr);
        });
});