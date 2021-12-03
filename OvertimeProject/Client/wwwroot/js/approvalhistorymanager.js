$(document).ready(function () {
    /*var stringnip = $("#nips").val();*/
    var urlPost = "";
    if ($("#role").val() == "Manager") {
        urlPost = "https://localhost:44314/API/Requests/GetAllRequestByStatusAndManagerId?status=1&managerId=" + $("#managerId").val();
    }
    console.log(urlPost);
    $("#requestTable").DataTable({
        /*filter: true,*/
        /*dom:Bfrtip,*/
        columnDefs: [
            {
                className: 'text-center',
                targets: '_all'
            }
        ],
        buttons: [
            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Overtime Request History By Manager',
                sheetName: 'Overtime Request History By Manager',
                text: '',
                className: 'buttonHide fa fa-download btn-default',
                fileName: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6]
                }
            },
            {
                extend: 'pdfHtml5',
                name: 'pdf',
                title: 'Overtime Request History By Manager',
                sheetName: 'Overtime Request History By Manager',
                text: '',
                className: 'buttonHide fa fa-download btn-default',
                fileName: 'Data',
                autoFilter: true,
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6]
                }
            }
        ],
        ajax: {
            "url": urlPost,
            "datatype": "json",
            "dataSrc": ""
        },
        columns: [
            {
                "data": null,
                "render": function (data, type, full, meta) {
                    return meta.row + 1;
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['requestDate'].substr(0, 10)
                }
            },
            {
                "data": "nik"
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return row['firstName'] + " " + row['lastName'];
                }
            },
            {
                "data": "overtimeName"
            },
            /*{
                "data": "task"
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    var startTH = row['startTime'].substr(11, 2);
                    var startTM = row['startTime'].substr(14, 2);
                    var endTH = row['endTime'].substr(11, 2);
                    var endTM = row['endTime'].substr(14, 2);
                    var totalSecStart = (startTH * 3600) + (startTM * 60);
                    var totalSecEnd = (endTH * 3600) + (endTM * 60);
                    var diffHours = (totalSecEnd - totalSecStart) / 3600;
                    *//*var timeDiff = (row['endTime']['totalSeconds'] - row['startTime']['totalSeconds'])/3600;*//*
                    return (diffHours) + ' Hours';
                }
            },*/
            {
                "data": "status",
                "render": function (data, type, row, meta) {
                    status = '<span class="badge badge-secondary badge-pill">' + 'Waiting Finance Controller Approval' + '</span>';
                    /*switch (data) {
                        case 0:
                            status = '<span class="badge badge-warning badge-pill">' + 'Pending' + '</span>';
                            break;
                        case 1:
                            status = '<span class="badge badge-primary badge-pill">' + 'Approved by Manager' + '</span>';
                            break;
                        case 2:
                            status = '<span class="badge badge-success badge-pill">' + 'Approved by Finance Controller' + '</span>';
                            break;
                        case 3:
                            status = '<span class="badge badge-danger badge-pill">' + 'Rejected' + '</span>';
                    }*/
                    return status;
                }
            },
            {
                "data": "",
                "orderable": false,
                "render": function (data, type, row, meta) {
                    return `<td scope="row"><a class="btn btn-info btn-sm text-light" data-url="" onclick="getdatabyID('${row.requestDate}, ${row.nik}')" data-toggle="modal" data-target="#detailModal" title="Detail"><i class="fa fa-info-circle"></i></a></td>`
                }
            }
        ]
    });
})

/*function getdatabyID(requestId) {
    console.log(requestId)
    $.ajax({
        url: "https://localhost:44314/API/Requests/GetRequestById/" + requestId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result[0]);
            console.log(result[0].requestId);
            var reqDate = result[0].requestDate.substr(0, 10);
            var sHours = result[0].startTime.substr(11, 2);
            var sMinutes = result[0].startTime.substr(14, 2);
            *//*var sTime = sHours + ":" + sMinutes + sMinutes;*//*
            var sTime = result[0].startTime.substr(11, 5);
            var eHours = result[0].endTime.substr(11, 2);
            var eMinutes = result[0].endTime.substr(14, 2);
            *//*var eTime = eHours + ":" + eMinutes + eMinutes;*//*
            var eTime = result[0].endTime.substr(11, 5);
            var tSecStart = (sHours * 3600) + (sMinutes * 60);
            var tSecEnd = (eHours * 3600) + (eMinutes * 60);
            var tHours = (tSecEnd - tSecStart) / 3600 + " Hours";
            $('#dataNIK').val(result[0].nik);
            $('#dataName').val(result[0].firstName + " " + result[0].lastName);
            $('#dataRequestId').val(result[0].requestId);
            $('#dataRequestDate').val(reqDate);
            $('#dataStartTime').val(sTime);
            $('#dataEndTime').val(eTime);
            $('#dataTask').val(result[0].task);
            $('#dataTotal').val(tHours);
            *//*$('#dataStatus').val(result[0].approvalStatus);*//*
            if (result[0].status === 0) {
                $('#dataStatus').val("Pending");
            } else if (result[0].status === 1) {
                $('#dataStatus').val("Approved by Manager");
            } else if (result[0].status === 2) {
                $('#dataStatus').val("Approved");
            } else if (result[0].status === 3) {
                $('#dataStatus').val("Rejected");
            }
            $('#dataCommission').val("Rp" + (new Intl.NumberFormat(['ban', 'id']).format(result[0].commission)));
            $('#detailModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
            swal({
                title: "FAILED",
                text: "Data tidak ditemukan!",
                icon: "error"
            }).then(function () {
                window.location.reload();
            });
        }
    });
    return false;
}*/

function getdatabyID(x) {
    var reqDate = x.substr(0, 10);
    var userId = x.substr(21, 5);
    console.log(x)
    console.log(reqDate)
    console.log(userId)
    $.ajax({
        url: `https://localhost:44314/API/Requests/GetRequestByStatusAndNIKAndDate?status=1&nik=${userId}&requestdate=${reqDate}`,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            var rows = '';
            var res
            $.each(result, function (i, item) {
                var sHour = item.startTime.substr(11, 2);
                var eHour = item.endTime.substr(11, 2);
                var sMinute = item.startTime.substr(14, 2);
                var eMinute = item.endTime.substr(14, 2);
                var tSecStart = (sHour * 3600) + (sMinute * 60);
                var tSecEnd = (eHour * 3600) + (eMinute * 60);
                var diffTime = (tSecEnd - tSecStart) / 3600;
                var stat = item.status;
                if (stat === 0) {
                    stat = "Pending"
                } else if (stat === 1) {
                    stat = "Approved by Manager"
                } else if (stat === 2) {
                    stat = "Approved"
                } else if (stat === 3) {
                    stat = "Rejected"
                }
                rows += `<div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="dataNIK">NIK</label>
                            <input type="text" class="form-control" id="dataNIK" name="dataNIK" value="${item.nik}" readonly>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="dataName">Name</label>
                            <input type="text" class="form-control" id="dataName" name="dataName" placeholder="Name" value="${item.firstName} ${item.lastName}" readonly>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="dataRequestId">Request ID</label>
                            <input type="text" class="form-control" id="dataRequestId" name="dataRequestId" placeholder="Request ID" value="${item.requestId}" readonly>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="dataRequestDate">Request Date</label>
                            <input type="date" class="form-control" id="dataRequestDate" name="dataRequestDate" value="${item.requestDate.substr(0, 10)}" readonly>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="dataStartTime">Start Time</label>
                            <input type="text" class="form-control" id="dataStartTime" name="dataStartTime" value="${item.startTime.substr(11, 5)}" readonly>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="dataEndTime">End Time</label>
                            <input type="text" class="form-control" id="dataEndTime" name="dataEndTime" value="${item.endTime.substr(11, 5)}" readonly>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="dataTask">Task</label>
                            <input type="text" class="form-control" id="dataTask" name="dataTask" placeholder="Task" value="${item.task}" readonly>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="dataTotal">Total Hours</label>
                            <input type="text" class="form-control" id="dataTotal" name="dataTotal" placeholder="Total Hours" value="${diffTime} Hours" readonly>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="dataStatus">Status</label>
                            <input type="text" class="form-control" id="dataStatus" name="dataStatus" placeholder="Approval Status" value="${stat}" readonly>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="dataCommission">Commission</label>
                            <input type="text" class="form-control" id="dataCommission" name="dataCommission" placeholder="Commission" value="Rp${item.commission}" readonly>
                        </div>
                    </div>
                    <div>
                        <hr style="border:0.5px solid;color:#333;background-color:#333;" />
                    </div>`;
            });
            $('#formDetail').append(rows);
        }
    });
}

function exportToExcel() {
    var table = $('#requestTable').DataTable();
    table.buttons('excel:name').trigger();
}

function exportToPdf() {
    var table = $('#requestTable').DataTable();
    table.buttons('pdf:name').trigger();
}