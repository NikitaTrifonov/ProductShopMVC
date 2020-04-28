

$(document).ready(function () {
    getShopMenuItemsList();
})


function getShopMenuItemsList() {
    $.getJSON("GetShopMenu", renderShopMenuItems)
}


function renderShopMenuItems(RequstResult) {

    let shopMenuItemsList = document.querySelector(".shopMenuItems");
    let shopMenuItemTemplate = document.querySelector("#shopMenuItemTemplate").content;
    let newShopMenuItem = shopMenuItemTemplate.querySelector(".shopMenuItemWrapper");

    for (var i = 0; i < RequstResult.Data.length; i++) {

        shopMenuItemsList.appendChild(setShopMenuItem(RequstResult.Data[i], newShopMenuItem));
    }
}

function setShopMenuItem(Data, newShopMenuItem) {
    
    let newMenuItem = newShopMenuItem.cloneNode(true);
    const [rub, cop] = Data.MenuItemPrice.split(",");

    newMenuItem.itemId = Data.Product.ProductId;

    let img = newMenuItem.querySelector(".menuItemImg");
    img.setAttribute("src", "../Content/Images/banan1.jpg");

    let name = newMenuItem.querySelector("#menuItemName");
    name.textContent = Data.Product.ProductName;

    let category = newMenuItem.querySelector("#category");
    category.textContent = Data.Product.CategoryString;

    let averageWeight = newMenuItem.querySelector("#averageWeight");
    averageWeight.textContent = Data.Product.ProductPrice;

    let country = newMenuItem.querySelector("#country");
    country.textContent = "В разработке";

    let priceRub = newMenuItem.querySelector("#rub");
    priceRub.textContent = rub;

    let priceCop = newMenuItem.querySelector("#cop");
    priceCop.textContent = cop;

    return newMenuItem;
}