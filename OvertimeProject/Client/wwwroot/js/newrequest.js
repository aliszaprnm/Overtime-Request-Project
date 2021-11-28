// Request Date Picker
$(function () {
    $('#date').datepicker({
        startDate: '-3d',
        endDate: '0d',
        todayHighlight: 'TRUE',
        format: 'yyyy/mm/dd'
    });
});

var table = null;
var listOvertime = [];
var totalOvertime = 0;
var table = null;
var rowIndex = 0;
var nik = $("#nik").val();
var email = $("#email").val();

function NewRequest() {
    //sum duration time
    var duration = moment($("#endtime").val(), 'hh:mm:ss').diff(moment($("#starttime").val(), 'hh:mm:ss'), 'hours');
    totalOvertime = totalOvertime + duration;
    if (totalOvertime > 3) {
        document.getElementById("overtimeLimit").style.display = "block";
    } else {
        document.getElementById("overtimeLimit").style.display = "none";
        var addList = {
            NIP: nik,
            Email: email,
            RequestDate: $("#date").val(),
            OvertimeName: $("#overtimeTitle").val(),
            StartTime: concatDateWithHoursMinute($("#date").val(), $("#starttime").val()),
            EndTime: concatDateWithHoursMinute($("#date").val(), $("#endtime").val()),
            Task: $("#task").val()
        }

        listOvertime.push(addList);
        var tableBody = document.querySelector("table > tbody");
        const row = tableBody.insertRow(rowIndex);
        const cell1 = row.insertCell(0);
        const cell2 = row.insertCell(1);
        const cell3 = row.insertCell(2);
        const cell4 = row.insertCell(3);
        const cell5 = row.insertCell(4);
        const cell6 = row.insertCell(5);
        const cell7 = row.insertCell(6);

        cell1.textContent = rowIndex + 1;
        cell2.innerHTML = `<input style="border:none;" name="nik" value="${document.getElementById("nik").value}" readonly></input>`;
        cell3.innerHTML = `<input style="border:none;" name="date" value="${document.getElementById("date").value}" readonly></input>`;
        cell4.innerHTML = `<input style="border:none;" name="starttime" value="${document.getElementById("starttime").value}" readonly></input>`;
        cell5.innerHTML = `<input style="border:none;" name="endtime" value="${document.getElementById("endtime").value}" readonly></input>`;
        cell6.innerHTML = `<input style="border:none;"  name="task" value="${document.getElementById("task").value}" readonly></input>`;
        cell7.innerHTML = `<button type="button" class="btn btn-danger" onclick="deleteItem(this)"><i class="fa fa-trash" aria-hidden="true" data-placement="top" title="Delete"></i></button>`
        rowIndex = rowIndex + 1;
    }
}
function deleteItem(e) {
    var index = e.parentNode.parentNode.rowIndex - 1;
    document.getElementById("bodyTableRequest").deleteRow(index);
    totalOvertime = totalOvertime - listOvertime[index];
    rowIndex--;
    listOvertime.splice(index, 1);
}

function concatDateWithHoursMinute(date, hoursMinute) {
    return date + ' ' + hoursMinute + ":00";
}

function OvertimeForm() {
    console.log(JSON.stringify(listOvertime));
    $.ajax({
        url: 'https://localhost:44314/API/Requests/AddListOvertime',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(listOvertime)
    }).done((result) => {
        Swal.fire({
            title: 'Success!',
            text: 'Your Request Has Been Added, Waiting For Approved',
            icon: 'success',
            confirmButtonText: 'Ok'
        }).then(function () {
            window.location.reload();
        });
    }).fail((error) => {
        Swal.fire({
            position: 'center',
            title: 'Error!',
            text: 'Please Check Your Data!!',
            icon: 'error',
            confirmButtonText: 'Back'
        })
        console.log(error);
    });
}