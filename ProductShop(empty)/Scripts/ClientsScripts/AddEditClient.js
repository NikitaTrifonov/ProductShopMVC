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
        AddOrEditClient("AddClient",client);
    }
}

$(function () {
    init()
});

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
        $.post(controllerName, client)

    })
}