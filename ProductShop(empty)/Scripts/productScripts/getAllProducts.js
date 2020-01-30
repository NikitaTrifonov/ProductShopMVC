$('#getAllProducts').click(function () {
    $.getJSON("GetAllProducts",
        function (data) {
            $('tr.trContent').remove();
            var tr;
            for (var i = 0; i < data.length; i++) {
                tr = $('<tr class ="trContent">');
                tr.append("<td>" + data[i].ProductId + "</td>");
                tr.append("<td>" + data[i].ProductName + "</td>");
                tr.append("<td>" + data[i].ProductPrice + "</td>");
                $('#productsTable').append(tr);
            }
        });
});