$(document).ready(function () {
    getShopMenuItemsList();
    getProductsCategories();
})

function getProductsCategories() {
    $.getJSON("GetProductsCategories", renderCheckBoxCategories)
}
function getShopMenuItemsList() {
    $.getJSON("GetShopMenu", renderShopMenuItems)
}

function renderCheckBoxCategories(RequstResult) {
    if (RequstResult.IsSuccess) {
        for (let i = 0; i < RequstResult.Data.length; i++) {
            if (i === 0)
                $(".checkList").append(`<li><input type='checkbox' class='allCategories' value='${i}' onchange='checkSelect(this)' checked /><b>${RequstResult.Data[i]}</b></li>`);
            else
                $(".checkList").append(`<li><input type='checkbox' class='otherCategory' value='${i}' onchange='checkSelect(this)' />${RequstResult.Data[i]}</li>`);
        }
    }
    else {
        $("#errorMessage").show();
        $("#errorMessage").text("Ошибка загрузки категорий товаров!");
        return
    }
}

function checkSelect(checkBox) {
    if (checkBox.checked === true) {
        switch (checkBox.className) {
            case "allCategories":
                disableCheckBoxes("otherCategory");
                break;
            case "otherCategory":
                disableCheckBoxes("allCategories");
                break;
        }
    }
}

function disableCheckBoxes(checkBoxName) {
    let otherCheckBoxes = document.getElementsByClassName(checkBoxName);
    for (let i = 0; i < otherCheckBoxes.length; i++) {
        otherCheckBoxes[i].checked = false;
    }
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
    img.setAttribute("src", `../Images/GetImg?id=${Data.Product.ProductImageRes}`);

    let name = newMenuItem.querySelector("#menuItemName");
    name.textContent = Data.Product.ProductName;

    let category = newMenuItem.querySelector("#category");
    category.textContent = Data.Product.CategoryString;

    let averageWeight = newMenuItem.querySelector("#averageWeight");
    averageWeight.textContent = Data.Product.ProductWeight;

    let country = newMenuItem.querySelector("#country");
    country.textContent = "В разработке";

    let priceRub = newMenuItem.querySelector("#rub");
    priceRub.textContent = rub;

    let priceCop = newMenuItem.querySelector("#cop");
    priceCop.textContent = cop;

    return newMenuItem;
}