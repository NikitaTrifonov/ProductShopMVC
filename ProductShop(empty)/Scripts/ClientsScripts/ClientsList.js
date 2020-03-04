$(document).ready(function () {
    $.getJSON("GetAllClients", addClientsInTable)
})

function addClientsInTable(RequstResault) {
    if (RequstResault.IsSuccess) {
        $("#errorMessage").hide();
        $("#clientsTable").show();
        $('tr.trClients').remove();
        for (var i = 0; i < RequstResault.Data.length; i++) {
            tr = $('<tr class ="trClients">');
            tr.append("<td>" + (i + 1) + "</td>");
            tr.append("<td>" + RequstResault.Data[i].ClientLastName + "</td>");
            tr.append("<td>" + RequstResault.Data[i].ClientFirstName + "</td>");
            tr.append("<td>" + RequstResault.Data[i].ClientMiddleName + "</td>");
            tr.append("<td>" + RequstResault.Data[i].ClientBirthdayString + "</td>");
            tr.append("<td>" + RequstResault.Data[i].ClientPhoneNumber + "</td>");
            tr.append("<td>" + RequstResault.Data[i].ClientEmail + "</td>");
            tr.append("<td><a href ='EditClientView?id=" + RequstResault.Data[i].ClientId + "'>Редактировать</a >" + "</td > ");
            $('#clientsTable').append(tr);
        }

    }
    else {
        $("#clientsTable").hide();
        $("#errorMessage").show();
        $("#errorMessage").text(RequstResault.Error);
    }
}