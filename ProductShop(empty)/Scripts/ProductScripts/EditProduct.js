function init() {
    var product = window.product;
    $("#editId").val(product.ProductId);
    $("#editName").val(product.ProductName);
    $("#editPrice").val(product.ProductPrice);
}
$(function () {
    init()
});