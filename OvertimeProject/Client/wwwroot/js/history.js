$(document).ready(function () {
    var stringnip = $("#nips").val();
    $("#historyTable").DataTable({
        /*filter: true,*/
        /*dom:Bfrtip,*/
        buttons: [
            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Overtime Request History',
                sheetName: 'Overtime Request History',
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
                title: 'Overtime Request History',
                sheetName: 'Overtime Request History',
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
            "url": "https://localhost:44314/API/Requests/GetAllRequestByStatusAndNIK?status=0&nik=" + stringnip,
            "datatype": "json",
            "dataSrc": ""
        },
        columns: [
            {
                "data": "requestId"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['startDate'].substr(0, 10)
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['endDate'].substr(0, 10)
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['startTime']['hours'] + ":" + row['startTime']['minutes'] + row['startTime']['minutes']
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['endTime']['hours'] + ":" + row['endTime']['minutes'] + row['endTime']['minutes']
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    var timeDiff = (row['endTime']['totalSeconds'] - row['startTime']['totalSeconds'])/3600;
                    return (timeDiff) + ' Hours';
                }
            },
            {
                "data":"task"
            },
            {
                "data": "approvalStatus",
                "render": function (data, type, row, meta) {
                    if (row['approvalStatus'] == 0) {
                        return 'Accepted'
                    } else if (row['approvalStatus'] == 1) {
                        return 'Pending'
                    } else if (row['approvalStatus'] == 2) {
                        return 'Decline'
                    }
                }
            },
            {
                "data": "",
                "orderable": false,
                "render": function (data, type, row, meta) {
                    return `<td scope="row"><a class="btn btn-warning btn-sm text-light" data-url="" onclick="getdatabyID('${row.requestId}')" data-toggle="modal" data-target="#detailModal" title="Detail"><i class="fa fa-info-circle"></i></a></td>`
                }
            }
        ]
    });
})

function exportToExcel() {
    var table = $('#historyTable').DataTable();
    table.buttons('excel:name').trigger();
}

function exportToPdf() {
    var table = $('#historyTable').DataTable();
    table.buttons('pdf:name').trigger();
}

function getdatabyID(requestId) {
    console.log(requestId)
    $.ajax({
        url: "https://localhost:44311/Employees/GetOvertime/" + requestId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result[0])
            var reqDate = result[0].requestDate.substr(0, 10);
            var tglMulai = result[0].startDate.substr(0, 10);
            var tglAkhir = result[0].endDate.substr(0, 10);
            var sHours = result[0].startTime.hours;
            var sMinutes = result[0].startTime.minutes;
            var sTime = sHours + ":" + sMinutes + sMinutes;
            var eHours = result[0].endTime.hours;
            var eMinutes = result[0].endTime.minutes;
            var eTime = eHours + ":" + eMinutes + eMinutes;
            var tSecStart = result[0].startTime.totalSeconds;
            var tSecEnd = result[0].endTime.totalSeconds;
            var tHours = (tSecEnd-tSecStart)/3600 + " Hours";
            $('#dataNIK').val(result[0].nik);
            $('#dataRequestDate').val(reqDate);
            $('#dataStartDate').val(tglMulai);
            $('#dataStartTime').val(sTime);
            $('#dataEndTime').val(eTime);
            $('#dataEndDate').val(tglAkhir);
            $('#dataTask').val(result[0].task);
            $('#dataTotal').val(tHours);
            /*$('#dataStatus').val(result[0].approvalStatus);*/
            if (result[0].approvalStatus === 0) {
                $('#dataStatus').val("Accepted");
            } else if (result[0].approvalStatus === 1) {
                $('#dataStatus').val("Pending");
            } else if (result[0].approvalStatus === 2) {
                $('#dataStatus').val("Declined");
            }
            $('#dataCommission').val(result[0].commission);
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
}