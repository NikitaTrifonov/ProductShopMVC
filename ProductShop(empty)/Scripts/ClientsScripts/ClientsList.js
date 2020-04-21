$(document).ready(function () {
    getAllClients();
})

$(".clientsTableBox").click(function (e) {
    if (e.target.classList.contains('btnDeleteImg')) {
        var clientId = e.target.dataset.clientId;
        showDelWindow();
        $("#mask").click(hideDelWindow);
        $("#delDialogBtnNo").click(hideDelWindow);
        $("#delDialogBtnYes").click(function () {
            $.post("DelClient", { Id: clientId }, delSuccess);
        })       
    }   
})

function getAllClients() {
    $.getJSON("GetAllClients", addClientsInTable)
}

function addClientsInTable(RequstResault) {
    if (RequstResault.IsSuccess) {
        $("#errorMessage").hide();
        $("#clientsTable").show();
        $('tr.trClients').remove();
        for (var i = 0; i < RequstResault.Data.length; i++) {
            tr = $('<tr class ="trClients">');
            tr.append(`<td>${(i + 1)}</td>`);
            tr.append(`<td>${RequstResault.Data[i].ClientLastName}</td>`);
            tr.append(`<td>${RequstResault.Data[i].ClientFirstName}</td>`);
            tr.append(`<td>${RequstResault.Data[i].ClientMiddleName}</td>`);
            tr.append(`<td>${RequstResault.Data[i].ClientBirthdayString}</td>`);
            tr.append(`<td>${RequstResault.Data[i].ClientPhoneNumber}</td>`);
            tr.append(`<td>${RequstResault.Data[i].ClientEmail}</td>`);
            tr.append(`<td><a href ='EditClientView?id=${RequstResault.Data[i].ClientId}'><img class ='btnEditImg' src='../Content/Images/btnEdit.png'/></a></td> `);
            tr.append(`<td><a><img class ='btnDeleteImg' src='../Content/Images/btnDelete.png' data-client-id = '${RequstResault.Data[i].ClientId}'/></a></td >`);
            $('#clientsTable').append(tr);
        }
    }
    else {
        $("#clientsTable").hide();
        $("#errorMessage").show();
        $("#errorMessage").text(RequstResault.Error);
    }
}

function delSuccess(RequstResault) {
    hideDelWindow();
    $("#statusMessage").show();
    if (RequstResault.IsSuccess) {
        getAllClients();
        $("#statusMessage").text("Клиент удален!");
    }
    else
        $("#statusMessage").text(RequstResault.Error);
}

function showDelWindow() {
    $("#delDialog").css("display", "initial");
    var maskHeight = $(window).height();
    var maskWidth = $(window).width();
    $("#mask").css({ 'width': maskWidth, 'height': maskHeight });
    $("#mask").css("display", "initial");
}

function hideDelWindow() {
    $("#delDialog, #mask").hide(); 
}

$("#searchClientBtn").click(function () {
    switch ($("select option:selected").val()) {
        case "AllClients":
            $.getJSON("GetAllClients", addClientsInTable);
            break;
        case "LastName":
            $.getJSON("SearchClientsByLastName", { LastName: $("#requiredClientData").val() }, addClientsInTable);
            break;
        case "E-mail":
            $.getJSON("SearchClientsByEmail", { Email: $("#requiredClientData").val() }, addClientsInTable);
            break;
    }
})
