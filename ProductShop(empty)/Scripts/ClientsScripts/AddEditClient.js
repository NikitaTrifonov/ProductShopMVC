function init() {
    var client = window.client;

    if (client === null) {
        client = {
            ClientId: "",
            ClientLastName: "",
            ClientFirstName: "",
            ClientMiddleName: "",
            ClientBirthdayString: "",
            ClientPhoneNumber: "",
            ClientEmail: ""
        }
        $("#submitBtnClient").text("Добавить");
        AddOrEditClient("AddClient", client);
    }
    else {
        $("#submitBtnClient").text("Изменить");
        setClientInputs(client);
        AddOrEditClient("EditClient", client);
    }
}

$(function () {
    init()
});

function setClientInputs(client) {
    $("#inputClientLastName").val(client.ClientLastName);
    $("#inputClientFirstName").val(client.ClientFirstName);
    $("#inputClientMiddleName").val(client.ClientMiddleName);   
    $("#inputClientBirthday").val(moment(client.ClientBirthday).format('YYYY-MM-DD'));
    $("#inputClientPhoneNumber").val(client.ClientPhoneNumber);
    $("#inputClientEmail").val(client.ClientEmail);
}

$(function () {
    $("#inputClientPhoneNumber").mask("+7(999)999-99-99");
})

function AddOrEditClient(controllerName, client) {
    $("#submitBtnClient").click(function () {
        client.ClientLastName = $("#inputClientLastName").val();
        client.ClientFirstName = $("#inputClientFirstName").val();
        client.ClientMiddleName = $("#inputClientMiddleName").val();
        client.ClientBirthdayString = $("#inputClientBirthday").val();
        client.ClientPhoneNumber = $("#inputClientPhoneNumber").val();
        client.ClientEmail = $("#inputClientEmail").val();
        if (!checkClientInputData(client)) {
            return;
        }
        $.post(controllerName, client, function(RequestResault) {
            if (RequestResault.IsSuccess) {
                switch (controllerName) {
                    case "AddClient":
                        setStatusMessage("successAdd");
                        $("#submitBtnClient").toggleClass("btnFuncDisable");
                        break;
                    case "EditClient":
                        setStatusMessage("successEdit")

                        break;
                }
            }
            else {
                setErrorColorMessage();
                $("#statusMessage").text(RequestResault.Error);
            }
        });
    });
}

function checkClientInputData(client) {
    if (!$.trim(client.ClientLastName)) {
        setStatusMessage("failLastName");
        return false;
    }
    if (!$.trim(client.ClientFirstName)) {
        setStatusMessage("failFirstName");
        return false;
    }
    if (!$.trim(client.ClientMiddleName)) {
        setStatusMessage("failMiddleName");
        return false;
    }
    if (!$.trim(client.ClientBirthdayString)) {
        setStatusMessage("failDate");
        return false;
    }
    if (!$.trim(client.ClientPhoneNumber)) {
        setStatusMessage("failPhoneNumber");
        return false;
    }
    if (!$.trim(client.ClientEmail)) {
        setStatusMessage("failEmail");
        return false;
    }
    if (validateEmail(client.ClientEmail) == false) {
        setStatusMessage("failEmailValidate");
        return false;
    }
    return true;
}

function validateEmail(email) {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    return reg.test(String(email).toLowerCase());
}

function setErrorColorMessage() {
    $("#statusMessage").removeAttr('class');
    $("#statusMessage").attr('class', 'errorMessage');
}
function setStatusMessage(status) {
    switch (status) {
        case "successEdit":
            $("#statusMessage").removeAttr('class');
            $("#statusMessage").attr('class', 'successMessage');
            $("#statusMessage").text("Успешно! Клиент изменен!");
            break;
        case "successAdd":
            $("#statusMessage").removeAttr('class');
            $("#statusMessage").attr('class', 'successMessage');
            $("#statusMessage").text("Успешно! Новый клиент добавлен!");
            break;
        case "failLastName":
            setErrorColorMessage();
            $("#statusMessage").text("Ошибка ввода данных ФИО! Пустое значение Фамилии.");
            break;
        case "failFirstName":
            setErrorColorMessage();
            $("#statusMessage").text("Ошибка ввода данных ФИО! Пустое значение Имени.");
            break;
        case "failMiddleName":
            setErrorColorMessage();
            $("#statusMessage").text("Ошибка ввода данных ФИО! Пустое значение Отчества.");
            break;
        case "failDate":
            setErrorColorMessage();
            $("#statusMessage").text("Ошибка ввода даты рождения! Пустое значение.");
            break;
        case "failPhoneNumber":
            setErrorColorMessage();
            $("#statusMessage").text("Ошибка ввода номера телефона! Пустое значение.");
            break;
        case "failEmail":
            setErrorColorMessage();
            $("#statusMessage").text("Ошибка ввода E-mail адреса! Пустое значение.");
            break;
        case "failEmailValidate":
            setErrorColorMessage();
            $("#statusMessage").text("Ошибка ввода E-mail адреса! Неправильная форма записи.");
            break;
    }
}